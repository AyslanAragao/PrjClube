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

        public ParticipanteDados()
        {

        }

        public void Atualizar(Participante item)
        {
            try
            {
                D = new AcessoDados();
                D.AddParametro("@cdParticipante", SqlDbType.Int, item.cdParticipante);
                D.AddParametro("@nmParticipante", SqlDbType.VarChar, item.nmParticipante);
                D.AddParametro("@dsApelido", SqlDbType.VarChar, item.dsApelido);
                D.AddParametro("@nrDDD", SqlDbType.VarChar, item.nrDDD);
                D.AddParametro("@nrTelefone", SqlDbType.VarChar, item.nrTelefone);
                D.AddParametro("@cdPartIndicador", SqlDbType.Int, item.cdPartIndicador);
                D.ExecProcedure("sp_altParticipante");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Participante item)
        {
            try
            {
                D = new AcessoDados();
                D.AddParametro("@nmParticipante", SqlDbType.VarChar, item.nmParticipante);
                D.AddParametro("@dsApelido", SqlDbType.VarChar, item.dsApelido);
                D.AddParametro("@nrDDD", SqlDbType.VarChar, item.nrDDD);
                D.AddParametro("@nrTelefone", SqlDbType.VarChar, item.nrTelefone);
                D.AddParametro("@cdPartIndicador", SqlDbType.Int, item.cdPartIndicador);

                D.ExecProcedure("sp_cadParticipante");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Participante> ConsultarTodos()
        {
            try
            {
                DataTable tabela;
                D = new AcessoDados();
                tabela = D.GetDataTable("sp_consParticipante");

                return CarregaDados(tabela);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<Participante> ConsultarDados(Participante item)
        {
            var cadastros = item.periodoDtCadastro.Split('-');
            var entradas = item.periodoDtEntrada.Split('-');

            DataTable tabela;
            D = new AcessoDados();
            D.AddParametro("@cdParticipante", SqlDbType.Int, item.cdParticipante);
            D.AddParametro("@nmParticipante", SqlDbType.VarChar, item.nmParticipante);
            D.AddParametro("@dsApelido", SqlDbType.VarChar, item.dsApelido);
            D.AddParametro("@nrDDD", SqlDbType.VarChar, item.nrDDD);
            D.AddParametro("@nrTelefone", SqlDbType.VarChar, item.nrTelefone);
            D.AddParametro("@DtCadastroDE", SqlDbType.VarChar, cadastros[0]);
            D.AddParametro("@DtCadastroATE", SqlDbType.VarChar, cadastros[1]);
            D.AddParametro("@DtEntradaDE", SqlDbType.VarChar, entradas[0]);
            D.AddParametro("@DtEntradaATE", SqlDbType.VarChar, entradas[1]);
            D.AddParametro("@cdPartIndicador", SqlDbType.VarChar, item.cdPartIndicador);
            tabela = D.GetDataTable("sp_consParticipante");

            return CarregaDados(tabela);
        }

        public Participante ConsultarPorID(int id)
        {
            try
            {
                D = new AcessoDados();
                D.AddParametro("@cdParticipante", SqlDbType.Int, id);

                var tabela = D.GetDataTable("sp_consParticipante");

                return ConverterEmObjeto(tabela.Rows[0]);
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(int id)
        {
            try
            {
                D = new AcessoDados();
                D.AddParametro("@cdParticipante", SqlDbType.Int, id);
                D.ExecProcedure("sp_delParticipante");
            }
            catch (Exception)
            { throw; }
        }


        //Funções Internas
        private IEnumerable<Participante> CarregaDados(DataTable tb)
        {
            foreach (DataRow row in tb.Rows)
            {
                yield return ConverterEmObjeto(row);
            }
        }
        private Participante ConverterEmObjeto(DataRow row)
        {
            try
            {
                Participante pp = new Participante();
                if (!row["cdParticipante"].ToString().Equals(""))
                    pp.cdParticipante = int.Parse(row["cdParticipante"].ToString());
                if (!row["nmParticipante"].ToString().Equals(""))
                    pp.nmParticipante = row["nmParticipante"].ToString();
                if (!row["dsApelido"].ToString().Equals(""))
                    pp.dsApelido = row["dsApelido"].ToString();
                if (!row["nrDDD"].ToString().Equals(""))
                    pp.nrDDD = row["nrDDD"].ToString();
                if (!row["nrTelefone"].ToString().Equals(""))
                    pp.nrTelefone = row["nrTelefone"].ToString();
                if (!row["cdPartIndicador"].ToString().Equals(""))
                {
                    pp.cdPartIndicador = int.Parse(row["cdPartIndicador"].ToString());
                    pp.Indicador = new Participante();
                    pp.Indicador.nmParticipante = row["nmIndicador"].ToString();
                }
                if (!row["dtEntrada"].ToString().Equals(""))
                    pp.dtEntrada = DateTime.Parse(row["dtEntrada"].ToString());
                if (!row["dtCadastro"].ToString().Equals(""))
                    pp.dtCadastro = DateTime.Parse(row["dtCadastro"].ToString());
                if (!row["flGeraLogin"].ToString().Equals(""))
                    pp.flGeraLogin = bool.Parse(row["flGeraLogin"].ToString());

                return pp;
            }
            catch (Exception)
            { throw; }
        }
    }
}
