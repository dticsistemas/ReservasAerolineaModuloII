using MediatR;
using Reservas.Aplicacion.Dtos.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Reservas.ObtenerReservaId
{
    public class ObtenerReservaIdQuery : IRequest<ReservaDto>
    {
        public Guid Id { get; set; }
        public ObtenerReservaIdQuery(Guid id)
        {
            Id = id;
        }
        public ObtenerReservaIdQuery() { }

    }
}
