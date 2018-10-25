using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clube.Modelo.Modelo;
using Clube.Dados.Interface;
using System.Data;
using Clube.Dados;

namespace Clube.Dados
{
    public class ParticipanteDados : Participante, IParticipanteDados 
    {

        IAcessoDados D;

        public void AtualizarDados(Participante item)
        {
            throw new NotImplementedException();
        }

        public void CadastrarDados(Participante item)
        {
            D = new AcessoDados();
            D.AddParametro("@nmParticipante", SqlDbType.VarChar, item.nmParticipante);
            D.AddParametro("@dsApelido", SqlDbType.VarChar, item.dsApelido);
            D.AddParametro("@nrDDD", SqlDbType.VarChar, item.nrDDD);
            D.AddParametro("@nrTelefone", SqlDbType.VarChar, item.nrTelefone);

            D.ExecProcedure("sp_cadParticipante");




        }

        public IEnumerable<Participante> ConsultarDados()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participante> ConsultarDados(Participante item)
        {
            throw new NotImplementedException();
        }

        public Participante ConsultarDados(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarDados(int id)
        {
            throw new NotImplementedException();
        }
    }
}
