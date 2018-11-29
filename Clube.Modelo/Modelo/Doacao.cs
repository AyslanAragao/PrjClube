using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Modelo.Modelo
{
    public class Doacao
    {
        public int cdParticipante { get; set; }
        public double Valor { get; set; }
        public DateTime dtDoacao { get; set; }
        public int modoPagamento { get; set; }


        public string nmParticipante { get; set; }
        public string dsTipoPagamento { get; set; }
        public int nrParcelas { get; set; }
    }
}
