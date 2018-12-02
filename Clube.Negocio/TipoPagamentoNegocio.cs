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
        public void Atualizar(TipoPagamento item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoPagamento item)
        {
            _dados.Cadastrar(item);
        }

        public IEnumerable<TipoPagamento> ConsultarTodos()
        {
           return _dados.ConsultarTodos();
        }

        public TipoPagamento ConsultarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoPagamento> ConsultarNegocio(TipoPagamento item)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
