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
    public class ParticipanteNegocio : Participante, IParticipanteNegocio
    {
        IParticipanteDados _dados;

        public ParticipanteNegocio(){
            _dados = new ParticipanteDados();
            
            }
        public void AtualizarNegocio(Participante item)
        {
            throw new NotImplementedException();
        }

        public void CadastrarNegocio(Participante item)
        {
            _dados.CadastrarDados(item);
        }

        public IEnumerable<Participante> ConsultarNegocio()
        {
            throw new NotImplementedException();
        }

        public Participante ConsultarNegocio(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participante> ConsultarNegocio(Participante item)
        {
            throw new NotImplementedException();
        }

        public void DeletarNegocio(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participante> ListarTodos()
        {
            return _dados.ListarTodos();
        }
    }
}
