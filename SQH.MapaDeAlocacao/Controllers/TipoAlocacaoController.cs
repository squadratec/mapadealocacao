using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.Models.TipoAlocacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SQH.Shared.Enums.Alerts;

namespace SQH.MapaDeAlocacao.Controllers
{
    
    public class TipoAlocacaoController : BaseController
    {
        private readonly ITipoAlocacaoService _tipoAlocacaoService;


        public TipoAlocacaoController(ITipoAlocacaoService tipoAlocacaoService)
        {
            _tipoAlocacaoService = tipoAlocacaoService;
        }

        [Route("tipoAlocacao")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("tipoalocacao/create", Name = "GetTipoAlocacao")]
        public IActionResult Create()
        {
            TipoAlocacaoModel tipoAlocacao = new TipoAlocacaoModel();
            return View(tipoAlocacao);
        }

        [HttpPost, Route("tipoalocacao/create", Name = "PostTipoAlocacao")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoAlocacaoModel model)
        {
            if (ModelState.IsValid)
            {
                _tipoAlocacaoService.Incluir(model);

                ExibirMensagem("Tipo alocação cadastrada com sucesso!!", Alert.success);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
