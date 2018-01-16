using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class ProjetoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}