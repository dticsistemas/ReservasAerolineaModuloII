using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Aplicacion.Dtos.Pagos;
using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarPagosReserva;
using Reservas.Dominio.Models.Pagos;
using Reservas.Infraestructura.EntityFramework.Contexts;
using Reservas.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.UseCases.Queries.Pagos
{    
    public class BuscarPagosReservaHandler :
        IRequestHandler<BuscarPagosReservaQuery, ICollection<PagoDto>>
    {
        private readonly DbSet<PagoReadModel> _pagos;

        public BuscarPagosReservaHandler(ReadDbContext context)
        {
            _pagos = context.Pago;
        }

        public async Task<ICollection<PagoDto>> Handle(BuscarPagosReservaQuery request, CancellationToken cancellationToken)
        {

            var pagosList = await _pagos
                            .AsNoTracking()
                            .Where(x => x.Reserva.Id.Equals(request.ReservaId))
                            .ToListAsync();

            var result = new List<PagoDto>();

            foreach (var objPago in pagosList)
            {
                PagoDto pagoDto = new();
                pagoDto.Id = objPago.Id;
                pagoDto.ReservaId = request.ReservaId;
                pagoDto.Monto = objPago.Monto;
                pagoDto.Fecha = objPago.Fecha;
                pagoDto.CodComprobante = objPago.CodComprobante;


                result.Add(pagoDto);
            }
            
            return result;
        }
    }
}
