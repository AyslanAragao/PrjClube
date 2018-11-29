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
        public void AtualizarDados(Doacao item)
        {
            throw new NotImplementedException();
        }

        public void CadastrarDados(Doacao item)
        {
            D = new AcessoDados();
            D.AddParametro("@cdParticipante", SqlDbType.Int, item.cdParticipante);
            D.AddParametro("@vlDoacao", SqlDbType.Float, item.Valor);
            D.AddParametro("@metodoPagamento", SqlDbType.Int, item.modoPagamento);
            D.AddParametro("@dtDoaca", SqlDbType.SmallDateTime, item.dtDoacao);

            D.ExecProcedure("sp_cadDoacao");

        }

        public IEnumerable<Doacao> ConsultarDados()
        {
            DataTable tabela;
            D = new AcessoDados();
            tabela = D.GetDataTable("sp_consDoacao");

            return CarregaDados(tabela);
        }

        public IEnumerable<Doacao> ConsultarDados(Doacao item)
        {
            throw new NotImplementedException();
        }

        public Doacao ConsultarDados(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarDados(int id)
        {
            throw new NotImplementedException();
        }

    

      
        public IEnumerable<Doacao> CarregaDados(DataTable tb)
        {
            foreach (DataRow row in tb.Rows)
            {
                yield return new Doacao
                {
                    
                    nmParticipante = (row["Nome"]).ToString(),
                    Valor = Convert.ToDouble    ((row["Valor"])),
                    dsTipoPagamento = (row["Forma"]).ToString(),
                    dtDoacao = Convert.ToDateTime((row["Data"])),
                    nrParcelas = Convert.ToInt32((row["Parcelas"])),

                };
            }

        }



    }
}
