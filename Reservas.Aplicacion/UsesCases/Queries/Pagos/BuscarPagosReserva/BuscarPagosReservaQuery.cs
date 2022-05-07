using MediatR;
using Reservas.Aplicacion.Dtos.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarPagosReserva
{
    public class BuscarPagosReservaQuery : IRequest<ICollection<PagoDto>>
    {
        public Guid  ReservaId { get; set; }

    }
}
