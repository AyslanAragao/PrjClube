using Clube.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Dados.Interface
{
    public interface IParticipanteDados : IBase<Participante>
    {
        IEnumerable<Participante> ListarTodos();
        Participante getByID(int id);
    }
}
