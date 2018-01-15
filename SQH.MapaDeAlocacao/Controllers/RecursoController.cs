using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SQH.Entities.Models.Recurso;
using SQH.Business.Contract;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class RecursoController : Controller
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
            _recursoService.Incluir(model);

            return Json(new { sucesso = true, mensagem = "Registro incluído com Sucesso." });
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
            _recursoService.Editar(model);

            return Json(new { sucesso = true, mensagem = "Registro alterado com Sucesso." });
        }
    }
}