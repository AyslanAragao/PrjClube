using Clube.Dados.Interface;
using Clube.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Dados
{
    public class DoacaoParcelaDados : DoacaoParcela, IDoacaoParcelaDados
    {
        IAcessoDados D;
        public DoacaoParcelaDados()
        {

        }
        public void Atualizar(DoacaoParcela item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(DoacaoParcela item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoacaoParcela> ConsultarDados(DoacaoParcela item)
        {
            DateTime? data1 = null;
            DateTime? data2 = null;
            //var datas = item.PeriododtMesParcela.Split('-');

            //if (!String.IsNullOrEmpty(datas[0].ToString().Trim()))
            //    data1 = Convert.ToDateTime(datas[0]);

            //if (!String.IsNullOrEmpty(datas[1].ToString().Trim()))
            //    data2 = Convert.ToDateTime(datas[1]);

            DataTable tabela;
            D = new AcessoDados();
            D.AddParametro("@cdLancamentoParcelado", SqlDbType.Int, item.cdLancamentoParcelado);
            D.AddParametro("@cdLancamento", SqlDbType.Int, item.cdLancamento);
            D.AddParametro("@vlParcela", SqlDbType.Int, item.vlParcela);
            D.AddParametro("@dtMesParcelaDE", SqlDbType.SmallDateTime, data1);
            D.AddParametro("@dtMesParcelaATE", SqlDbType.SmallDateTime, data2);
            tabela = D.GetDataTable("sp_consDoacaoParcelada");

            return CarregaDados(tabela);
        }

        public DoacaoParcela ConsultarPorID(int id)
        {
            DataTable tabela;
            D = new AcessoDados();
            D.AddParametro("@cdLancamentoParcelado", SqlDbType.Int, id);
            tabela = D.GetDataTable("sp_consDoacaoParcelada");

            var doacao = CarregaDados(tabela);
            return doacao.ToList()[0];

        }

        public IEnumerable<DoacaoParcela> ConsultarTodasParcelasPorID(int id)
        {
            DataTable dt;
            D = new AcessoDados();
            D.AddParametro(@"idUsuario", SqlDbType.Int, id);
            dt = D.GetDataTable("[ConsultarTodasParcelasPorID]");

            var doacao = CarregaDados(dt);
            return doacao;
        }

        public IEnumerable<DoacaoParcela> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }


        private IEnumerable<DoacaoParcela> CarregaDados(DataTable tb)
        {
            foreach (DataRow row in tb.Rows)
            {
                yield return ConverterEmObjeto(row);
            }
        }
        private DoacaoParcela ConverterEmObjeto(DataRow row)
        {
            try
            {
                DoacaoParcela pp = new DoacaoParcela();

                if (!row["cdLancamentoParcelado"].ToString().Equals(""))
                    pp.cdLancamentoParcelado = int.Parse(row["cdLancamentoParcelado"].ToString());
                if (!row["cdLancamento"].ToString().Equals(""))
                    pp.cdLancamento = int.Parse(row["cdLancamento"].ToString());
                if (!row["vlParcela"].ToString().Equals(""))
                    pp.vlParcela = double.Parse(row["vlParcela"].ToString());
                if (!row["dtMesParcela"].ToString().Equals(""))
                    pp.dtMesParcela = DateTime.Parse(row["dtMesParcela"].ToString());

                return pp;
            }
            catch (Exception)
            { throw; }
        }
    }
}
