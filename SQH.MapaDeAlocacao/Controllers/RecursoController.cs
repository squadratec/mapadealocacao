﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SQH.Entities.Models.Recurso;
using SQH.Business.Contract;
using static SQH.Shared.Enums.Alerts;
using System;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class RecursoController : BaseController
    {
        private readonly IRecursoService _recursoService;

        public RecursoController(IRecursoService recursoService)
        {
            _recursoService = recursoService;
        }

        public IActionResult Index()
        {
            var model = new List<RecursoListaModel>();

            var objs = _recursoService.ObtemTodos();

            objs.ToList().ForEach(x => model.Add(new RecursoListaModel()
            {
                Id = x.IdRecurso,
                Nome = x.Nome
            }));

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RecursoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _recursoService.Incluir(model);

                    ExibirMensagem("Registro incluído com Sucesso.", Alert.success);

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var obj = _recursoService.ObterPorId(id);
            var viewModel = new RecursoModel()
            {
                Id = obj.IdRecurso,
                Nome = obj.Nome
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(RecursoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _recursoService.Editar(model);
                    ExibirMensagem("Registro alterado com Sucesso.", Alert.success);

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, Alert.danger);
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _recursoService.Deletar(id);
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