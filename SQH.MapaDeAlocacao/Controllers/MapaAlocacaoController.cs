﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class MapaAlocacaoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
