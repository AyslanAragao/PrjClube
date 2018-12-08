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
    public class DoacaoNegocio : Doacao, IDoacaoNegocio
    {
        IDoacaoDados _dados;

        public DoacaoNegocio()
        {
            _dados = new DoacaoDados();

        }
        public void Atualizar(Doacao item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Doacao item)
        {
            _dados.Cadastrar(item);
        }

        public IEnumerable<Doacao> ConsultarTodos()
        {
           return _dados.ConsultarTodos();
        }

        public Doacao ConsultarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doacao> ConsultarNegocio(Doacao item)
        {
            return _dados.ConsultarDados(item);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
