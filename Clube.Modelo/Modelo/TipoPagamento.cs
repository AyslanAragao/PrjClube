using System;
using System.ComponentModel;

namespace Clube.Modelo.Modelo
{
    public class TipoPagamento
    {
        [DisplayName("Codigo")]
        public int cdTipoPagamento { set; get; }
        [DisplayName("Tipo")]
        public string dsTipoPagamento { set; get; }
       
    }
}
