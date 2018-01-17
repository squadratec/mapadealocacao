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

        public MapaAlocacaoController(IRecursoService recursoService)
        {
            _recursoService = recursoService;
        }

        public ActionResult Index()
        {
            MapaAlocacaoModel model = new MapaAlocacaoModel();

            model.Recurso = _recursoService.Find(x => x.Apropriar == 1).ToList();

            return View(model);
        }
    }
}
