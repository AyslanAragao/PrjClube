using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Modelo.Modelo
{
    public class DoacaoParcela
    {
        public int cdLancamento { get; set; }
        public int cdLancamentoParcelado { get; set; }
        public double vlParcela { get; set; }
        public DateTime dtMesParcela { get; set; }
    }
}
