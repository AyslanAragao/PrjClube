using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjClube.Controllers
{
    public class BaseController : Controller
    {
        public bool UsuarioContinuaLogado()
        {
            try
            {
                if (Session["UsuarioLogado"] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Desconectar() {
            Session["UsuarioLogado"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}