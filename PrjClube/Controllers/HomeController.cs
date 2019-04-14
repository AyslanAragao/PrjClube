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
    public class HomeController : BaseController
    {
        IParticipanteNegocio _ServicoParticioante;
        ITipoPagamentoNegocio _ServicoPagamento;
        IDoacaoNegocio _ServicoDoacao;
        LogExcecaoNegocio _LogExcecaoNegocio;

        public HomeController()
        {
            _ServicoParticioante = new ParticipanteNegocio();
            _ServicoPagamento = new TipoPagamentoNegocio();
            _ServicoDoacao = new DoacaoNegocio();
            _LogExcecaoNegocio = new LogExcecaoNegocio();

        }
        public ActionResult Index()
        {
            try
            {
                if (UsuarioContinuaLogado())
                {
                    var doacoes = _ServicoDoacao.ConsultarTodos();
                    return View(doacoes);
                }
                else
                    return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;
                string cdLogin = Session["cdLogin"].ToString();
                _LogExcecaoNegocio.Salvar(e, cdLogin.ToString());
                return RedirectToAction("Index", "Home");
            }


        }
        [HttpPost]
        public ActionResult Index(Doacao doacao)
        {
            try
            {
                if (UsuarioContinuaLogado())
                {
                    TempData["nmParticipante"] = doacao.nmParticipante;
                    TempData["modoPagamento"] = doacao.cdTipoPagamento;
                    TempData["periodoDtDoacao"] = doacao.periodoDtDoacao;

                    var doacoes = _ServicoDoacao.ConsultarNegocio(doacao);
                    return View(doacoes);
                }
                else
                    return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;
                string cdLogin = Session["cdLogin"].ToString();
                _LogExcecaoNegocio.Salvar(e, cdLogin.ToString());
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult _mdlNovaDoacao()
        {
            if (UsuarioContinuaLogado())
            {
                ViewBags();
            return PartialView();
            }
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult _mdlNovaDoacao(Doacao doacao)
        {
            if (UsuarioContinuaLogado())
            {
                _ServicoDoacao.Cadastrar(doacao);
            TempData["Mensagem"] = "Doação cadastrado com sucesso";
            return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Login");
        }


        public void ViewBags()
        {
            ViewBag.Participantes = _ServicoParticioante.ConsultarTodos();
            ViewBag.Pagamentos = _ServicoPagamento.ConsultarTodos();
        }


        public string ConsultarParcelasDoacoes(int id)
        {
            try
            {
                var doacoes = _ServicoDoacao.ConsultarTodasParcelasPorID(id);
                string retorno = JsonConvert.SerializeObject(doacoes);
                return retorno;
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                TempData["detalhe"] = e.StackTrace;
                string cdLogin = Session["cdLogin"].ToString();
                _LogExcecaoNegocio.Salvar(e, cdLogin.ToString());
                return "Ocorreu um erro";
            }

        }


    }
}