using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Dados.Interface
{
    public interface IBase<T> where T : class
    {
        T ConsultarDados(int id);

        IEnumerable<T> ConsultarDados(T item);

        IEnumerable<T> ConsultarDados();

        void AtualizarDados(T item);

        void CadastrarDados(T item);

        void DeletarDados(int id);

       
    }
}
