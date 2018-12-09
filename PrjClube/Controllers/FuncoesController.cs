using Clube.Negocio;
using Clube.Negocio.Interface;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace PrjClube.Controllers
{
    public class FuncoesController : Controller
    {
        private readonly ITipoPagamentoNegocio _tipoPagamento;
        private readonly IParticipanteNegocio _participante;
        public FuncoesController()
        {
            _tipoPagamento = new TipoPagamentoNegocio();
            _participante = new ParticipanteNegocio();
        }
        // GET: Funcoes
        public ActionResult Index()
        {
            return View();
        }

        public string GetModoPagamentos()
        {
            var tp = _tipoPagamento.ConsultarTodos();
            string retorno = JsonConvert.SerializeObject(tp);

            return retorno;
        }

        public string GetParticipantes()
        {
            var tp = _participante.ConsultarTodos();
            string retorno = JsonConvert.SerializeObject(tp);

            return retorno;
        }
    }
}