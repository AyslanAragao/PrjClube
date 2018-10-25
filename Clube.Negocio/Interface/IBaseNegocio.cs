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

        IEnumerable<T> ConsultarNegocio();

        T ConsultarNegocio(int id);

        void AtualizarNegocio(T item);

        void CadastrarNegocio(T item);

        void DeletarNegocio(int id);
    }
}
