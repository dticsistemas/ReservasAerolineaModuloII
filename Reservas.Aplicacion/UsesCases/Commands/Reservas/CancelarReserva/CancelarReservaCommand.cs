using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.CancelarReserva
{
    public class CancelarReservaCommand : IRequest<Guid>
    {
        public Guid ReservaId { get; set; }

        public CancelarReservaCommand(Guid reservaId)
        {
            ReservaId = reservaId;
        }
    }
}
