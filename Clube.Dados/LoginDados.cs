using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clube.Modelo.Modelo;
using Clube.Dados.Interface;
using System.Data;

namespace Clube.Dados
{
    public class LoginDados: Login 
    {

        IAcessoDados D;


        protected bool LogarDados(Login login)
        {
            if (VericaUsuario(login))
                return true;
            else
                return false;
        }



        #region VericaUsuario
        public bool VericaUsuario(Login login)
        {
            try
            {
                D = new AcessoDados();
                D.AddParametro("@login", SqlDbType.VarChar, login.nmLogin);
                D.AddParametro("@senha", SqlDbType.VarChar, login.dsSenha);
                D.AddParametro("@codigo", SqlDbType.Int, login.cdLogin);

                D.ExecProcedure("sp_verificaLogin");

                if (D.Parametros["@codigo"].Value != null)
                {
                    cdLogin = Convert.ToInt32(D.Parametros["@codigo"].Value);
                    //menu = MontarMenu();
                    return true;
                }
                else

                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

    }
}
