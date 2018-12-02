
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
        public T ConsultarPorID(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<T> ConsultarDados(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(T item)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(T item)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
