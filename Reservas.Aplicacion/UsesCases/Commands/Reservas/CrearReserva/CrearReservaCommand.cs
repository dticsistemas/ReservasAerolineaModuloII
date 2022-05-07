using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva
{
    public class CrearReservaCommand : IRequest<Guid>
    {
        public Guid clienteId { get; set; }
        public Guid vueloId { get; set; }
        public String tipoReserva { get; set; }

        public CrearReservaCommand(Guid clienteId, Guid vueloId, String tipoReserva)
        {
            this.clienteId = clienteId;
            this.vueloId = vueloId;
            this.tipoReserva = tipoReserva;
        }
    }
}
