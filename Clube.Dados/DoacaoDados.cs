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
    public class DoacaoDados : Doacao, IDoacaoDados
    {

        IAcessoDados D;

        public DoacaoDados()
        {

        }
        public void Atualizar(Doacao item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Doacao item)
        {
            D = new AcessoDados();
            D.AddParametro("@cdParticipante", SqlDbType.Int, item.cdParticipante);
            D.AddParametro("@vlDoacao", SqlDbType.Float, item.Valor);
            D.AddParametro("@metodoPagamento", SqlDbType.Int, item.cdTipoPagamento);
            D.AddParametro("@dtDoaca", SqlDbType.SmallDateTime, item.dtDoacao);

            D.ExecProcedure("sp_cadDoacao");

        }

        public IEnumerable<Doacao> ConsultarTodos()
        {
            DataTable tabela;
            D = new AcessoDados();
            tabela = D.GetDataTable("sp_consDoacao");

            return CarregaDados(tabela);
        }

        public IEnumerable<Doacao> ConsultarDados(Doacao item)
        {
            var datas = item.periodoDtDoacao.Split('-');

            DataTable tabela;
            D = new AcessoDados();
            D.AddParametro("@nmParticipante", SqlDbType.Int, item.nmParticipante);
            D.AddParametro("@modoPagamento", SqlDbType.Int, item.cdTipoPagamento);
            D.AddParametro("@dtDoacaoDE", SqlDbType.VarChar, datas[0]);
            D.AddParametro("@dtDoacaoATE", SqlDbType.VarChar, datas[1]);
            tabela = D.GetDataTable("sp_consDoacao");

            return CarregaDados(tabela);
        }

        public Doacao ConsultarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doacao> CarregaDados(DataTable tb)
        {
            foreach (DataRow row in tb.Rows)
            {
                yield return ConverterEmObjeto(row);
            }
        }


        private Doacao ConverterEmObjeto(DataRow row)
        {
            try
            {
                Doacao pp = new Doacao();

                if (!row["cdParticipante"].ToString().Equals(""))
                    pp.cdParticipante = int.Parse(row["cdParticipante"].ToString());
                if (!row["nmParticipante"].ToString().Equals(""))
                    pp.nmParticipante = row["nmParticipante"].ToString();
                if (!row["vlLancamento"].ToString().Equals(""))
                    pp.Valor = double.Parse(row["vlLancamento"].ToString());
                if (!row["dtPagamento"].ToString().Equals(""))
                    pp.dtDoacao = DateTime.Parse(row["dtPagamento"].ToString());
                if (!row["cdTipoPagamento"].ToString().Equals(""))
                    pp.cdTipoPagamento = int.Parse(row["cdTipoPagamento"].ToString());
                if (!row["dstipopagamento"].ToString().Equals(""))
                    pp.dsTipoPagamento = row["dstipopagamento"].ToString();
                if (!row["Parcelas"].ToString().Equals(""))
                    pp.nrParcelas = int.Parse(row["Parcelas"].ToString());
                //Parcelas caso tenha
                //if (!row["cdLancamentoParcelado"].ToString().Equals(""))
                //    pp.parcelas.cdLancamentoParcelado = int.Parse(row["cdLancamentoParcelado"].ToString());
                //if (!row["vlParcela"].ToString().Equals(""))
                //    pp.parcelas.vlParcela = double.Parse(row["vlParcela"].ToString());
                //if (!row["dtMesParcela"].ToString().Equals(""))
                //    pp.parcelas.dtMesParcela = DateTime.Parse(row["dtMesParcela"].ToString());

                return pp;
            }
            catch (Exception)
            { throw; }
        }
    }
}
