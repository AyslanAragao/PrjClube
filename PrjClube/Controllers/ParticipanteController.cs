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
    public class ParticipanteController : BaseController
    {


        IParticipanteNegocio _participante;

        public ParticipanteController()
        {
            _participante = new ParticipanteNegocio();
        }


        public ActionResult Index()
        {
            try
            {
                if (UsuarioContinuaLogado())
                {
                    return View(_participante.ConsultarTodos());
                }
                else
                    return RedirectToAction("Login","Login");
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public ActionResult Index(Participante participante)
        {
            try
            {
                if (UsuarioContinuaLogado())
                {
                    TempData["cdParticipante"] = participante.cdParticipante;
                    TempData["nmParticipante"] = participante.nmParticipante;
                    TempData["nrDDD"] = participante.nrDDD;
                    TempData["nrTelefone"] = participante.nrTelefone;
                    TempData["periodoDtCadastro"] = participante.periodoDtCadastro;
                    TempData["periodoDtEntrada"] = participante.periodoDtEntrada;
                    TempData["cdPartIndicador"] = participante.cdPartIndicador;

                    return View(_participante.ConsultarNegocio(participante));
                }
                else
                    return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult _mdlCadastrar(int? id)
        {
            if (UsuarioContinuaLogado())
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
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult _mdlCadastrar(Participante part)
        {
            try
            {
                if (UsuarioContinuaLogado())
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
                else
                    return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;
                return RedirectToAction("Index");
            }
        }

        public void RemoverParticipante(int id)
        {
            try
            {
                _participante.Deletar(id);
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;

            }

        }

        //Funções
        public string ListarParticipantes()
        {
            try
            {
                var participantes = _participante.ConsultarTodos();
                var retorno = JsonConvert.SerializeObject(participantes);

                return retorno;
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;
                return "";
            }

        }
    }
}