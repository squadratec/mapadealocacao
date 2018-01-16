using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.Models.Projeto;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        public IActionResult Index()
        {
            var projetos = _projetoService.ObtemTodos();

            var model = new List<ProjetoModel>();

            projetos.ToList().ForEach(x => model.Add(new ProjetoModel()
            {
                IdProjeto = x.IdProjeto,
                IdRecurso = x.IdRecurso,
                Nome = x.Nome,
                Lider = x.Lider
            }));

            return View(model);
        }
    }
}