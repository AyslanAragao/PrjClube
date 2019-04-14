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
        LogExcecaoNegocio _LogExcecaoNegocio;

        public FuncoesController()
        {
            _tipoPagamento = new TipoPagamentoNegocio();
            _participante = new ParticipanteNegocio();
            _LogExcecaoNegocio = new LogExcecaoNegocio();
        }
        // GET: Funcoes
        public ActionResult Index()
        {
            return View();
        }

        public string GetModoPagamentos()
        {
            string retorno = "";
            try
            {
                var tp = _tipoPagamento.ConsultarTodos();
                retorno = JsonConvert.SerializeObject(tp);
            }
            catch (System.Exception e)
            {
                string cdLogin = Session["cdLogin"].ToString();
                _LogExcecaoNegocio.Salvar(e, cdLogin.ToString());

                return retorno; ;
            }


            return retorno;
        }

        public string GetParticipantes()
        {
            string retorno = "";
            try
            {
                var tp = _participante.ConsultarTodos();
                retorno = JsonConvert.SerializeObject(tp);
            }
            catch (System.Exception e)
            {
                string cdLogin = Session["cdLogin"].ToString();
                _LogExcecaoNegocio.Salvar(e, cdLogin.ToString());

                return retorno;
            }
            return retorno;
        }
    }
}