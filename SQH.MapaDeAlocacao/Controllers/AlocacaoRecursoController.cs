using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SQH.Entities.Models.Alocacao;
using static SQH.Shared.Enums.Alerts;
using SQH.Business.Contract;

namespace SQH.MapaDeAlocacao.Controllers
{
    [Authorize]
    public class AlocacaoRecursoController : BaseController
    {
        private readonly IAlocacaoRecursoService _alocacaoRecursoService;

        public AlocacaoRecursoController(IAlocacaoRecursoService alocacaoRecursoService)
        {
            _alocacaoRecursoService = alocacaoRecursoService;
        }

        public IActionResult Incluir(AlocacaoRecursoModel model)
        {
            try
            {
                var retorno = _alocacaoRecursoService.Incluir(model);

                if (retorno.Valido)
                {
                    //ExibirMensagem("Alocação de recurso salvo com sucesso.", Alert.success);
                    return Json(new { valido = true, mensagem = "Alocação de recurso salvo com sucesso." });
                }
                else
                {
                    return Json(new { valido = false, mensagem = retorno.Mensagem });
                }
            }
            catch (Exception ex)
            {
                return Json(new { valido = false, mensagem = ex.Message });
            }
        }

        public IActionResult Editar(AlocacaoRecursoModel model)
        {
            try
            {
                var retorno = _alocacaoRecursoService.Editar(model);

                if (retorno.Valido)
                {
                    //ExibirMensagem("Alocação de recurso editado com sucesso.", Alert.success);
                    return Json(new { valido = true, mensagem = "Alocação de recurso editado com sucesso." });
                }
                else
                {
                    return Json(new { valido = false, mensagem = retorno.Mensagem });
                }
            }
            catch (Exception ex)
            {
                return Json(new { valido = false, mensagem = ex.Message });
            }
        }

        public IActionResult Delete(string id, string redirecionar)
        {
            try
            {
                var ids = id.Split('-');

                _alocacaoRecursoService.Deletar(Convert.ToInt32(ids[1]), Convert.ToInt32(ids[0]));

                ExibirMensagem("Alocação de recurso excluída com sucesso.", Alert.success);
                return RedirectToAction("Edit", "Projeto", new { Id = redirecionar });
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return RedirectToAction("Edit", "Projeto", new { Id = redirecionar });
            }
        }
    }
}