using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Dados.Interface
{
    public interface IBase<T> where T : class
    {
        T ConsultarPorID(int id);

        IEnumerable<T> ConsultarDados(T item);

        IEnumerable<T> ConsultarTodos();

        void Atualizar(T item);

        void Cadastrar(T item);

        void Deletar(int id);

       
    }
}
