using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SQH.Business.Contract;
using SQH.Entities.SQHoras;
using SQH.MapaDeAlocacao.Models;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SQH.MapaDeAlocacao.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IAutenticacaoService client;

        public HomeController(IAutenticacaoService _client)
        {
            client = _client;
        }

        [HttpGet]
        [Route("~/")]
        [Route("login", Name = "loginget")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(ProjetoController.Index), "Projeto");
            }

            return View();
        }

        [HttpPost, Route("login", Name = "loginpost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Entities.Models.Login model)
        {
            if (ModelState.IsValid)
            {
                AuthRetorno retorno = client.ValidaLoginUsuario(new LoginRequisitor(model.Usuario, model.Senha));

                if (retorno.Authenticated)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                  new ClaimsPrincipal(retorno.Claims),
                                                  new AuthenticationProperties
                                                  {
                                                      IsPersistent = true,
                                                      ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
                                                  });

                    return RedirectToAction(nameof(ProjetoController.Index), "Projeto");
                }
                else
                    ModelState.AddModelError("usuario", retorno.Message);
            }
            return View(model);
        }

        [HttpGet, Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
