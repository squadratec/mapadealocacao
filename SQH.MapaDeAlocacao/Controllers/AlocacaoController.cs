using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.Models.Alocacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SQH.Shared.Enums.Alerts;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class AlocacaoController : BaseController
    {

        private readonly IAlocacaoRecursoService _alocacaoRecursoService;

        public AlocacaoController(IAlocacaoRecursoService alocacaoRecursoService)
        {
            _alocacaoRecursoService = alocacaoRecursoService;
        }

        [HttpPost, Route("CreateAlocacaoRecurso", Name = "AlocacaoRecursoPost")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAlocacaoRecurso(RecursoAlocacaoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.IdRecurso == 0)
                    {
                        _alocacaoRecursoService.Incluir(model);

                        ExibirMensagem("Recurso cadastrada com sucesso!!", Alert.success);
                    }
                    else
                    {
                        _alocacaoRecursoService.Editar(model);

                        ExibirMensagem("Recurso alterada com sucesso!!", Alert.success);
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
