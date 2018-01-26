using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.Models.MapaAlocacao;
using SQH.Entities.Response.Alocacao;
using SQH.Entities.Response.Projeto;
using SQH.Entities.Response.Recurso;
using SQH.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SQH.MapaDeAlocacao.Controllers
{
    [Authorize]
    public class MapaAlocacaoController : Controller
    {
        private readonly IRecursoService _recursoService;
        private readonly ITipoAlocacaoService _tipoAlocacaoService;
        private readonly IProjetoService _projetoService;
        private readonly IAlocacaoProjetoService _alocacaoProjetoService;
        private readonly IAlocacaoRecursoService _alocacaoRecursoService;

        public MapaAlocacaoController(IRecursoService recursoService, ITipoAlocacaoService tipoAlocacaoService, IProjetoService projetoService, IAlocacaoProjetoService alocacaoProjetoService, IAlocacaoRecursoService alocacaoRecursoService)
        {
            _recursoService = recursoService;
            _tipoAlocacaoService = tipoAlocacaoService;
            _projetoService = projetoService;
            _alocacaoProjetoService = alocacaoProjetoService;
            _alocacaoRecursoService = alocacaoRecursoService;
        }

        public ActionResult Index(string mesAno)
        {
            MapaAlocacaoModel model = new MapaAlocacaoModel();

            model.Recurso = _recursoService.Find(x => x.Apropriar == 1).ToList();
            model.TipoAlocacao = _tipoAlocacaoService.ObtemTodos().ToList();
            model.Projetos = _projetoService.ObtemTodos().ToList();

            DateTime endDate;
            DateTime startDate;

            if (String.IsNullOrEmpty(mesAno))
            {
                var hoje = DateTime.Now;
                endDate = hoje.GetLastDateFromCurrentMonth();
                startDate = new DateTime(hoje.Year, hoje.Month, 1);
            }
            else
            {
                var arrayValue = mesAno.Split('/');
                var ano = Convert.ToInt32(arrayValue[1]);
                var mes = Convert.ToInt32(arrayValue[0]);
                endDate = DateExtensions.GetLastDateFromCurrentMonth(mes, ano);
                startDate = new DateTime(ano, mes, 1);
            }

            var intervaloDatas = Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));

            model.Datas = new List<DatasProjetos>();

            foreach (DateTime itemData in intervaloDatas)
            {
                DatasProjetos datasProjetos = new DatasProjetos();

                datasProjetos.DiaSemana = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(itemData.DayOfWeek));
                datasProjetos.Data = String.Format("{0:dd/MM/yyyy}", itemData);
                datasProjetos.ProjetoRecurso = new List<ProjetoRecursoAlocacao>();

                var alocacoes = _alocacaoRecursoService.Find(x => (x.DataInicio <= itemData && x.DataFim >= itemData));

                foreach (RecursoResponse itemRecurso in model.Recurso)
                {
                    ProjetoRecursoAlocacao projetoResponse = new ProjetoRecursoAlocacao();
                    projetoResponse.IdRecurso = itemRecurso.Id;

                    if (itemData.DayOfWeek != DayOfWeek.Sunday && itemData.DayOfWeek != DayOfWeek.Saturday)
                    {
                        var projetoRecurso = alocacoes.FirstOrDefault(x => x.IdRecurso == itemRecurso.Id);

                        if (projetoRecurso != null)
                        {
                            AlocacaoProjetoResponse alocacaoProjetoResponse = _alocacaoProjetoService.ObtemProjetoPorAlocacao(projetoRecurso.IdAlocacao);
                            projetoResponse.IdProjeto = ((alocacaoProjetoResponse != null) ? alocacaoProjetoResponse.IdProjeto : 0);
                            projetoResponse.Cor = ((alocacaoProjetoResponse != null) ? _tipoAlocacaoService.ObterPorId(alocacaoProjetoResponse.IdTipoAlocacao).Cor : "#FFF");
                            projetoResponse.NomeProjeto = ((alocacaoProjetoResponse != null) ? alocacaoProjetoResponse.NomeProjeto : "");
                        }
                    }
                    else
                    {
                        projetoResponse.Cor = "#d8d9d9";
                    }
                    datasProjetos.ProjetoRecurso.Add(projetoResponse);
                }

                model.Datas.Add(datasProjetos);

            }
            return View(model);
        }
    }
}