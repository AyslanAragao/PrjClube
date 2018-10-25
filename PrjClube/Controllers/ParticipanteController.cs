using Clube.Modelo.Modelo;
using Clube.Negocio;
using Clube.Negocio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjClube.Controllers
{
    public class ParticipanteController : Controller
    {


        IParticipanteNegocio _negocio;

        public ParticipanteController()
        {
            _negocio = new ParticipanteNegocio();
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Participante item)
        {
            try
            {
                _negocio.CadastrarNegocio(item);
                TempData["Mensagem"] = "Participante cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Excecao.LogarErrro(ex, 1);
                TempData["Mensagem"] = ex.Message;
                return View();

            }
        }


    }
}