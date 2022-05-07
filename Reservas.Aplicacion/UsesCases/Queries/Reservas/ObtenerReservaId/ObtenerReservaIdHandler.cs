using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Repositories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Reservas.ObtenerReservaId
{
    public class ObtenerReservaIdHandler : IRequestHandler<ObtenerReservaIdQuery,ReservaDto>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<ObtenerReservaIdQuery> _logger;
        public ObtenerReservaIdHandler(IReservaRepository reservaRepository,ILogger<ObtenerReservaIdQuery> logger)
        {
            _reservaRepository=reservaRepository;
            _logger=logger;
        }

        public async Task<ReservaDto> Handle(ObtenerReservaIdQuery request, CancellationToken cancellationToken)
        {
            ReservaDto result=null;            
            try
            {
                Reserva objReserva = await _reservaRepository.FindByIdAsync(request.Id);
               
                result = new ReservaDto()
                {
                    Id = objReserva.Id,
                    ClienteId = objReserva.ClienteId,
                    VueloId = objReserva.VueloId,
                    CodReserva = objReserva.CodReserva,
                    Monto = objReserva.Monto,
                    Fecha = objReserva.Fecha,
                    TipoReserva = objReserva.TipoReserva,
                    EstadoReserva = objReserva.EstadoReserva
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Reserva con id:... { ReservaId }", request.Id);
            }

            return result;
        }
    }
}
