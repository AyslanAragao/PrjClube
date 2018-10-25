using System;
using System.ComponentModel;

namespace Clube.Modelo.Modelo
{
    public class Login
    {
        [DisplayName("Codigo")]
        public int cdLogin { set; get; }
        [DisplayName("Login")]
        public string nmLogin { set; get; }
        [DisplayName("Senha")]
        public string dsSenha { set; get; }
        [DisplayName("Data Último Login")]
        public DateTime dtUltimoLogin { set; get; }
    }
}
