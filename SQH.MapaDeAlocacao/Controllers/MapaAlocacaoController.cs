using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.Models.MapaAlocacao;
using SQH.Entities.Response.Recurso;
using System;
using System.Collections.Generic;
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

        public MapaAlocacaoController(IRecursoService recursoService, ITipoAlocacaoService tipoAlocacaoService, IProjetoService projetoService)
        {
            _recursoService = recursoService;
            _tipoAlocacaoService = tipoAlocacaoService;
            _projetoService = projetoService;
        }

        public ActionResult Index()
        {
            MapaAlocacaoModel model = new MapaAlocacaoModel();

            model.Recurso = _recursoService.Find(x => x.Apropriar == 1).ToList();
            model.TipoAlocacao = _tipoAlocacaoService.ObtemTodos().ToList();
            model.Projetos = _projetoService.ObtemTodos().ToList();
            return View(model);
        }
    }
}
