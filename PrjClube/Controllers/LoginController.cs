using Clube.Modelo.Modelo;
using Clube.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjClube.Controllers
{
    public class LoginController : Controller
    {
        LoginNegocio _negocio;
        LogExcecaoNegocio _logExcecaoNegocio;

        public LoginController()
        {
            _negocio = new LoginNegocio();
            _logExcecaoNegocio = new LogExcecaoNegocio();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                if (_negocio.Logar(login))
                //if (1 == 1)
                {
                    Session.Add("UsuarioLogado", _negocio);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    return RedirectToAction("Login");
                }

            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Usuario ou Senha incorreta";
                TempData["TipoDialog"] = "error";
                _logExcecaoNegocio.Salvar(ex, login.cdLogin.ToString());
                return View();
            }
        }




    }
}