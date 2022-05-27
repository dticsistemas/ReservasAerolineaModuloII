using MediatR;
using Reservas.Aplicacion.Dtos.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId
{
    public class BuscarFacturaPorIdQuery : IRequest<FacturaDto>
    {
       public Guid Id { get; set; }
        public BuscarFacturaPorIdQuery(Guid id)
        {
            Id = id;
        }
        public BuscarFacturaPorIdQuery() { }

    }
}
