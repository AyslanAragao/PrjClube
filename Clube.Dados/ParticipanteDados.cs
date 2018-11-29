﻿using System;
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
        List<Participante> participantes;
        public ParticipanteDados()
        {

            participantes = new List<Participante>();
            Participante Sidnei = new Participante()
            {
                cdLoginCadastro = 1,
                cdParticipante = 1,
                cdPartIndicador = 0,
                dsApelido = "Sidnei Coach",
                dtCadastro = DateTime.Parse("10/10/2018"),
                dtEntrada = DateTime.Today,
                flGeraLogin = false,
                nmParticipante = "Sidnei",
                nrDDD = "79",
                nrTelefone = "888888888",
                Indicador = null
            }; participantes.Add(Sidnei);
            Participante Edenir = new Participante()
            {
                cdLoginCadastro = 2,
                cdParticipante = 2,
                cdPartIndicador = 0,
                dsApelido = "Edenir não Coach",
                dtCadastro = DateTime.Parse("11/10/2018"),
                dtEntrada = DateTime.Today,
                flGeraLogin = false,
                nmParticipante = "Edenir",
                nrDDD = "80",
                nrTelefone = "999999999",
                Indicador = null
            }; participantes.Add(Edenir);

        }
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
            DataTable tabela;
            D = new AcessoDados();
            tabela = D.GetDataTable("sp_consParticipante");

            return CarregaDados(tabela);
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

        public IEnumerable<Participante> ListarTodos()
        {

            return participantes;
        }

        public Participante getByID(int id)
        {
            return participantes.Find(model => model.cdParticipante == id);
        }

        public IEnumerable<Participante> CarregaDados(DataTable tb)
        {
            foreach (DataRow row in tb.Rows)
            {
                yield return new Participante
                {
                    cdParticipante = Convert.ToInt32((row["cdParticipante"])),
                    dsApelido = (row["dsApelido"]).ToString(),
                  
                };
            }

        }



    }
}
