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
        IDoacaoNegocio _Servico;

        public HomeController()
        {
            _ServicoParticioante = new ParticipanteNegocio();
            _ServicoPagamento = new TipoPagamentoNegocio();
            _Servico = new DoacaoNegocio();

        }
        public ActionResult Index()
        {
            ViewBags();
            var doacoes = _Servico.ConsultarTodos();
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
            _Servico.Cadastrar(doacao);
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