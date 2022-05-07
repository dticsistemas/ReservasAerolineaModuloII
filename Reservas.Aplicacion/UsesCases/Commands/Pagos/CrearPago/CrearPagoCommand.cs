using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearPago
{
    public class CrearPagoCommand : IRequest<Guid>
    {       
        public Guid ReservaId { get; set; }
        public decimal Monto { get; set; }

        public CrearPagoCommand(Guid reservaId, decimal monto)
        {
            ReservaId = reservaId;
            Monto = monto;

        }
    }
}
