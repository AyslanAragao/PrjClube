using Clube.Dados;
using Clube.Dados.Interface;
using Clube.Modelo.Modelo;
using Clube.Negocio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Negocio
{
    public class TipoPagamentoNegocio : TipoPagamento, ITipoPagamentoNegocio
    {
        ITipoPagamento _dados;

        public TipoPagamentoNegocio()
        {
            _dados = new TipoPagamentoDados();

        }
        public void AtualizarNegocio(TipoPagamento item)
        {
            throw new NotImplementedException();
        }

        public void CadastrarNegocio(TipoPagamento item)
        {
            _dados.CadastrarDados(item);
        }

        public IEnumerable<TipoPagamento> ConsultarNegocio()
        {
           return _dados.ConsultarDados();
        }

        public TipoPagamento ConsultarNegocio(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoPagamento> ConsultarNegocio(TipoPagamento item)
        {
            throw new NotImplementedException();
        }

        public void DeletarNegocio(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
