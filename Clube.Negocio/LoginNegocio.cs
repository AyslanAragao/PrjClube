using Clube.Dados;
using Clube.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Negocio
{
    public class LoginNegocio:LoginDados
    {
       
        public bool Logar(Login login)
        {
            return this.LogarDados(login);
        }
         

    }
}
