using System;
using System.ComponentModel;

namespace Clube.Modelo.Modelo
{
    public class Participante
    {
        [DisplayName("Codigo")]
        public int cdParticipante { set; get; }
        [DisplayName("Nome")]
        public string nmParticipante { set; get; }
        [DisplayName("Apelido")]
        public string dsApelido { set; get; }
        [DisplayName("DDD")]
        public string nrDDD { set; get; }
        [DisplayName("Telefone")]
        public string nrTelefone { set; get; }
        [DisplayName("Indicador")]
        public int cdPartIndicador { set; get; }
        [DisplayName("Data de Entrada")]
        public DateTime dtEntrada { set; get; }
        [DisplayName("Login de Cadastro")]
        public int cdLoginCadastro { set; get; }
        [DisplayName("Data de Cadastro")]
        public DateTime dtCadastro { set; get; }
        [DisplayName("GeraLogin")]
        public bool flGeraLogin { set; get; }
    }
}
