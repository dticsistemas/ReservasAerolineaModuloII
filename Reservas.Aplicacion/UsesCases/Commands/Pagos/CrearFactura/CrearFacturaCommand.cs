using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura
{
    public class CrearFacturaCommand : IRequest<Guid>
    {
        public Guid ReservaId { get; set; }
        public decimal Monto { get; set; }

        public CrearFacturaCommand(Guid reservaId, decimal monto)
        {
            ReservaId = reservaId;
            Monto = monto;

        }
    }

}
