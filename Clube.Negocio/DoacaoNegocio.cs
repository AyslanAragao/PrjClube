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
        public void AtualizarNegocio(Doacao item)
        {
            throw new NotImplementedException();
        }

        public void CadastrarNegocio(Doacao item)
        {
            _dados.CadastrarDados(item);
        }

        public IEnumerable<Doacao> ConsultarNegocio()
        {
           return _dados.ConsultarDados();
        }

        public Doacao ConsultarNegocio(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doacao> ConsultarNegocio(Doacao item)
        {
            throw new NotImplementedException();
        }

        public void DeletarNegocio(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
