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
    public class HomeController : Controller
    {
        IParticipanteNegocio _ServicoParticioante;
        ITipoPagamentoNegocio _ServicoPagamento;
        IDoacaoNegocio _ServicoDoacao;

        public HomeController()
        {
            _ServicoParticioante = new ParticipanteNegocio();
            _ServicoPagamento = new TipoPagamentoNegocio();
            _ServicoDoacao = new DoacaoNegocio();

        }
        public ActionResult Index()
        {
            var doacoes = _ServicoDoacao.ConsultarTodos();
            return View(doacoes);
        }
        [HttpPost]
        public ActionResult Index(Doacao doacao)
        {
            TempData["nmParticipante"] = doacao.nmParticipante;
            TempData["modoPagamento"] = doacao.cdTipoPagamento;
            TempData["periodoDtDoacao"] = doacao.periodoDtDoacao;
            
            var doacoes = _ServicoDoacao.ConsultarNegocio(doacao);
            return View(doacoes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _mdlNovaDoacao()
        {
            ViewBags();
            return PartialView();
        }
        [HttpPost]
        public ActionResult _mdlNovaDoacao(Doacao doacao)
        {
            _ServicoDoacao.Cadastrar(doacao);
            TempData["Mensagem"] = "Doação cadastrado com sucesso";
            return RedirectToAction("Index");
        }


        public void ViewBags()
        {
            ViewBag.Participantes = _ServicoParticioante.ConsultarTodos();
            ViewBag.Pagamentos = _ServicoPagamento.ConsultarTodos();
        }


    }
}