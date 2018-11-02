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

        public LoginController()
        {
            _negocio = new LoginNegocio();
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
                {
                   

                   
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
                //Excecao.LogarErrro(ex, login.cdLogin);
                return View();
            }
        }




    }
}