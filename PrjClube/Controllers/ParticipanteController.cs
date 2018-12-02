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


        IParticipanteNegocio _participante;

        public ParticipanteController()
        {
            _participante = new ParticipanteNegocio();
        }


        public ActionResult Index()
        {
           return View(_participante.ConsultarTodos());
        }

        public ActionResult _mdlCadastrar(int? id)
        {
            if (null == id || id == 0)
            {
                Participante parti = new Participante();
                ViewBag.Title = "Novo Participante";
                return PartialView(parti);
            }
            var participante = _participante.ConsultarPorID((int)id);
            ViewBag.Title = "Edição de Participante";
            return PartialView(participante);
        }
        [HttpPost]
        public ActionResult _mdlCadastrar(Participante part)
        {
            try
            {
                if (part.cdParticipante > 0)
                {
                    _participante.Atualizar(part);
                    TempData["Mensagem"] = "Participante atualizado com sucesso";
                }
                else
                {
                    _participante.Cadastrar(part);
                    TempData["Mensagem"] = "Participante cadastrado com sucesso";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = ex.Message;
                return RedirectToAction("Index");

            }
        }

        public void RemoverParticipante(int id)
        {
            _participante.Deletar(id);
        }

        //Funções
        public string ListarParticipantes()
        {
            var participantes = _participante.ConsultarTodos();
            var retorno = JsonConvert.SerializeObject(participantes);

            return retorno;
        }
    }
}