
using Clube.Dados.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Dados
{
    public class Base<T>: IBase<T> where T : class
    {
        IAcessoDados D;

        #region Métodos
        public T ConsultarDados(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<T> ConsultarDados(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ConsultarDados()
        {
            throw new NotImplementedException();
        }

        public void AtualizarDados(T item)
        {
            throw new NotImplementedException();
        }

        public void DeletarDados(int id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarDados(T item)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
