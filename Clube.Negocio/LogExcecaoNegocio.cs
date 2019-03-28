using Clube.Dados;
using Clube.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Negocio
{
    public class LogExcecaoNegocio
    {
        private readonly LogExcecaoDados _logExcecaoDados;

        public LogExcecaoNegocio()
        {
            _logExcecaoDados = new LogExcecaoDados();
        }

        public void Salvar(Exception excecao, string idLogin)
        {
            _logExcecaoDados.Salvar(idLogin,excecao.Message,excecao.StackTrace);
        }
    }
}
