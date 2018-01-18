using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQH.Business.Contract;
using SQH.Entities.Models.Alocacao;
using SQH.Entities.Requisicao;
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
        private readonly ITipoAlocacaoService _tipoAlocacaoService;
        private readonly IAlocacaoProjetoService _alocacaoProjetoService;

        public AlocacaoController(IAlocacaoRecursoService alocacaoRecursoService, ITipoAlocacaoService tipoAlocacaoService,
                                    IAlocacaoProjetoService alocacaoProjetoService)
        {
            _alocacaoRecursoService = alocacaoRecursoService;
            _tipoAlocacaoService = tipoAlocacaoService;
            _alocacaoProjetoService = alocacaoProjetoService;
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

        [HttpPost]
        public IActionResult SalvarAlocacaoProjeto(AlocacaoProjetoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var requisicao = new AlocacaoProjetoRequisicao(model.IdProjeto, model.IdTipoAlocacao, model.DataInicio, model.DataFim);

                    var retorno = _alocacaoProjetoService.IncluirAlocacaoProjeto(requisicao);

                    if (retorno.Valido)
                    {
                        ExibirMensagem("Alocação incluída com sucesso.", Alert.success);
                        return RedirectToAction("Edit", "Projeto", new { Id = model.IdProjeto });
                    }
                    else
                    {
                        ExibirMensagem(retorno.Mensagem, Alert.danger);
                        return RedirectToAction("Edit", "Projeto", new { Id = model.IdProjeto });
                    }
                }
                else
                {
                    return RedirectToAction("Edit", "Projeto", new { Id = model.IdProjeto });
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return RedirectToAction("Edit", "Projeto", new { Id = model.IdProjeto });
            }
        }

        [HttpPost]
        public IActionResult EditarPeriodoAlocacao(AlocacaoProjetoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var requisicao = new AlocacaoProjetoRequisicao(model.IdAlocacao, model.DataInicio, model.DataFim);

                    _alocacaoProjetoService.AlterarPeriodoAlocacaoProjeto(requisicao);

                    ExibirMensagem("Período alterado com sucesso.", Alert.success);
                    return RedirectToAction("Edit", "Projeto", new { Id = model.IdProjeto });
                }
                else
                {
                    return RedirectToAction("Edit", "Projeto", new { Id = model.IdProjeto });
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return RedirectToAction("Edit", "Projeto", new { Id = model.IdProjeto });
            }
        }

        public IActionResult Delete(int id, string redirecionar)
        {
            try
            {
                _alocacaoProjetoService.RemoverAlocacao(id);

                ExibirMensagem("Alocação excluída com sucesso.", Alert.success);
                return RedirectToAction("Edit", "Projeto", new { Id = redirecionar });
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return RedirectToAction("Edit", "Projeto", new { Id = redirecionar });
            }
        }

        [HttpGet]
        public PartialViewResult ObtemModalAlocacaoProjeto(int idProjeto)
        {
            var model = new AlocacaoProjetoModel();
            model.TiposAlocacao = ObtemSelectListTipoAlocacao();

            return PartialView("_modalAdicionarTipoAlocacao", model);
        }

        #region Métodos Privados
        private List<SelectListItem> ObtemSelectListTipoAlocacao()
        {
            var tiposAlocacao = _tipoAlocacaoService.ObtemTodos();

            var retorno = new List<SelectListItem>();

            tiposAlocacao.ToList().ForEach(x => retorno.Add(new SelectListItem()
            {
                Text = x.Nome,
                Value = x.IdTipoAlocacao.ToString()
            }));

            return retorno;
        }
        #endregion
    }
}
