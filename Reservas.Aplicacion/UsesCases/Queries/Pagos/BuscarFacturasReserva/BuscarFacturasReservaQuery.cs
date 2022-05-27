using MediatR;
using Reservas.Aplicacion.Dtos.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturasReserva
{
    public class BuscarFacturasReservaQuery : IRequest<ICollection<FacturaDto>>
    {
        public Guid ReservaId { get; set; }

    }
}
