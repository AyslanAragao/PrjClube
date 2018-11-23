using Clube.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Negocio.Interface
{
    public interface IParticipanteNegocio : IBaseNegocio<Participante>
    {
        IEnumerable<Participante> ListarTodos();
        Participante getByID(int id);
    }
}
