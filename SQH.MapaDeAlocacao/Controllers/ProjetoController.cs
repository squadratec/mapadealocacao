using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.Models.Projeto;
using SQH.Entities.Database;
using SQH.Entities.Models.Alocacao;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;
        private readonly ITipoAlocacaoService _tipoAlocacaoService;

        public ProjetoController(IProjetoService projetoService, ITipoAlocacaoService tipoAlocacaoService)
        {
            _projetoService = projetoService;
            _tipoAlocacaoService = tipoAlocacaoService;
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
            var model = PreencheModelProjeto();

            return View(model);
        }

        private IEnumerable<tipo_alocacao> ObtemTiposAcalocao()
        {
            var tiposAlocacao = _tipoAlocacaoService.ObtemTodos();

            return tiposAlocacao;
        }

        private ProjetoModel PreencheModelProjeto()
        {
            var model = new ProjetoModel();
            var tiposAlocacoes = ObtemTiposAcalocao();

            tiposAlocacoes.ToList().ForEach
                (x => model.Alocacoes.Add(new AlocacaoProjeto()
                {
                    IdTipoAlocacao = x.IdTipoAlocacao,
                    TipoAlocacao = x.Nome
                }));

            return model;
        }
    }
}