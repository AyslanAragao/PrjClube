using Clube.Negocio;
using Clube.Negocio.Interface;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace PrjClube.Controllers
{
    public class FuncoesController : Controller
    {
        private readonly ITipoPagamentoNegocio _tipoPagamento;
        public FuncoesController()
        {
            _tipoPagamento = new TipoPagamentoNegocio();
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
    }
}