using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Negocio.Interface
{
    public interface IBaseNegocio<T> where T : class
    {
        IEnumerable<T> ConsultarNegocio(T item);

        IEnumerable<T> ConsultarTodos();

        T ConsultarPorID(int id);

        void Atualizar(T item);

        void Cadastrar(T item);

        void Deletar(int id);
    }
}
