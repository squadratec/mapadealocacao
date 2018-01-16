using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
            var model = new List<TipoAlocacaoModel>();

            var objs = _tipoAlocacaoService.ObtemTodos();

            objs.ToList().ForEach(x => model.Add(new TipoAlocacaoModel()
            {
                IdTipoAlocacao = x.IdTipoAlocacao,
                Nome = x.Nome,
                Cor = x.Cor,
                Sigla = x.Sigla
            }));
            return View(model);
        }

        [Route("tipoalocacao/create/{Id=0}", Name = "GetTipoAlocacao")]
        public IActionResult Create(Int32 Id)
        {
            var tipoAlocacao = _tipoAlocacaoService.ObterPorId(Id);
            TipoAlocacaoModel tipoAlocacaoModel = new TipoAlocacaoModel();

            if (tipoAlocacao != null)
            {

                tipoAlocacaoModel = new TipoAlocacaoModel()
                {
                    Cor = tipoAlocacao.Cor,
                    DataCadastro = tipoAlocacao.DataCadastro,
                    IdTipoAlocacao = tipoAlocacao.IdTipoAlocacao,
                    Nome = tipoAlocacao.Nome,
                    Sigla = tipoAlocacao.Sigla
                };
            }

            return View(tipoAlocacaoModel);
        }

        [HttpPost, Route("tipoalocacao/create/{id=0}", Name = "PostTipoAlocacao")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoAlocacaoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.IdTipoAlocacao == 0)
                    {
                        _tipoAlocacaoService.Incluir(model);

                        ExibirMensagem("Tipo alocação cadastrada com sucesso!!", Alert.success);
                    }
                    else
                    {
                        _tipoAlocacaoService.Editar(model);

                        ExibirMensagem("Tipo alocação alterada com sucesso!!", Alert.success);
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

        public IActionResult Delete(int id)
        {
            try
            {
                _tipoAlocacaoService.Deletar(id);

                ExibirMensagem("Registro excluído com Sucesso.", Alert.success);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return RedirectToAction("Index");
            }
        }
    }
}
