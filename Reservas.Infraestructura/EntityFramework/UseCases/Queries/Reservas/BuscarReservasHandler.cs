using MediatR;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.BuscarReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.UseCases.Queries.Reservas
{
    public class BuscarReservasHandler :
         IRequestHandler<BuscarReservasQuery, ICollection<ReservaDto>>
    {
       // private readonly DbSet<ReservaReadModel> _pedidos;

       // public BuscarReservasHandler(ReadDbContext context)
       // {
       //     _pedidos = context.Reserva;
       // }
        public Task<ICollection<ReservaDto>> Handle(BuscarReservasQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
