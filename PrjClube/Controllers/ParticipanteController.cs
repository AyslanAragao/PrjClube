using Clube.Modelo.Modelo;
using Clube.Negocio;
using Clube.Negocio.Interface;
using Newtonsoft.Json;
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
            var grid = Session["Grid"] != null ? (List<Participante>)Session["Grid"] : (List<Participante>)_negocio.ListarTodos();

            if (Session["ParticipanteCadastrado"] != null)
            {
                var participante = (Participante)Session["ParticipanteCadastrado"];
                grid.Add(participante);
            }
            
            Session["Grid"] = grid;
            return View(grid);

        }


        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult _mdlCadastrar()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Cadastrar(Participante item)
        {
            try
            {
                var participantes = (List<Participante>)Session["Grid"];

                var participante = participantes.Where(m => m.cdParticipante == item.cdPartIndicador).ToList();

                item.Indicador = participante[0];

                //_negocio.CadastrarNegocio(item);
                Session["ParticipanteCadastrado"] = item;
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

        public string ListarParticipantes()
        {
            var participantes = _negocio.ListarTodos();
            if (Session["Grid"] != null)
            {
                var sessao = (List<Participante>)Session["Grid"];
                participantes.Concat(sessao);
            }
            var retorno = JsonConvert.SerializeObject(participantes);

            return retorno;
        }
    }
}