using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SQH.Shared.Enums.Alerts;

namespace SQH.MapaDeAlocacao.Controllers
{
    public class BaseController : Controller
    {
        public void ExibirMensagem(string Msg, Alert alert)
        {
            TempData["msg"] = Msg;
            TempData["Type"] = Enum.GetName(typeof(Alert), alert);
        }

    }
}
