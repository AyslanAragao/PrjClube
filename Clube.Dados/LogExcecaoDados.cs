using Clube.Dados.Interface;
using Clube.Modelo.Modelo;
using System;
using System.Data;

namespace Clube.Dados
{
    public class LogExcecaoDados 
    {
        IAcessoDados D;

        public void Salvar(string Usuario, string Mensagem, string Detalhe)
        {
            try
            {
                D = new AcessoDados();
                D.AddParametro("@Usuario", SqlDbType.VarChar, Usuario);
                D.AddParametro("@Mensagem", SqlDbType.VarChar, Mensagem);
                D.AddParametro("@Detalhe", SqlDbType.VarChar, Detalhe);
                //D.AddParametro("@DtRegistro", SqlDbType.SmallDateTime, excecao.DtRegistro); //Esse campo deve ser getdate() na base
                
                D.ExecProcedure("sp_cadException");
            }
            catch (Exception)
            {throw;}
        }
    }
}
