using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.Models.Projeto;
using SQH.Entities.Database;
using SQH.Entities.Models.Alocacao;
using SQH.Entities.Response.Alocacao;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;
        private readonly ITipoAlocacaoService _tipoAlocacaoService;
        private readonly IAlocacaoProjetoService _alocacaoProjetoService;

        public ProjetoController(IProjetoService projetoService, ITipoAlocacaoService tipoAlocacaoService, IAlocacaoProjetoService alocacaoProjetoService)
        {
            _projetoService = projetoService;
            _tipoAlocacaoService = tipoAlocacaoService;
            _alocacaoProjetoService = alocacaoProjetoService;
        }

        public IActionResult Index()
        {
            var projetos = _projetoService.ObtemTodos();

            var model = new List<ProjetoListaModel>();

            projetos.ToList().ForEach(x => model.Add(new ProjetoListaModel()
            {
                IdProjeto = x.IdProjeto,
                IdRecurso = x.IdRecurso,
                Nome = x.Nome,
                Lider = x.Lider
            }));

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = PreencheModelProjeto(id);

            return View(model);
        }

        private IEnumerable<AlocacaoProjetoResponse> ObtemAlocacoesProjeto(int idProjeto)
        {
            var alocacoesProjeto = _alocacaoProjetoService.ObtemAlocacoesPorProjeto(idProjeto);

            return alocacoesProjeto;
        }

        private ProjetoModel PreencheModelProjeto(int idProjeto)
        {
            var model = new ProjetoModel();

            var alocacoesProjeto = ObtemAlocacoesProjeto(idProjeto);
            alocacoesProjeto.ToList().ForEach(x => model.Alocacoes.Add(new AlocacaoProjetoModel()
            {
                DataFim = x.DataFim,
                DataInicio = x.DataInicio,
                IdAlocacao = x.IdAlocacao,
                IdProjeto = x.IdProjeto,
                IdTipoAlocacao = x.IdTipoAlocacao,
                TipoAlocacao = x.TipoAlocacao
            }));

            return model;
        }
    }
}