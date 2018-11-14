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
        public int Valor { get; set; }
        public DateTime dtDoacao { get; set; }
        public int modoPagamento { get; set; }
    }
}
