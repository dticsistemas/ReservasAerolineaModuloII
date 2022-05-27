using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Dtos.Pagos;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Dominio.Models.Pagos;
using Reservas.Dominio.Repositories.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId
{
    public class BuscarFacturaPorIdHandler : IRequestHandler<BuscarFacturaPorIdQuery, FacturaDto>
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly ILogger<BuscarFacturaPorIdQuery> _logger;
        public BuscarFacturaPorIdHandler(IFacturaRepository reservaRepository, ILogger<BuscarFacturaPorIdQuery> logger)
        {
            _facturaRepository = reservaRepository;
            _logger = logger;
        }

        public async Task<FacturaDto> Handle(BuscarFacturaPorIdQuery request, CancellationToken cancellationToken)
        {
            FacturaDto result = null;
            try
            {
                Factura objFactura = await _facturaRepository.FindByIdAsync(request.Id);

                result = new FacturaDto()
                {
                    Id = objFactura.Id,
                    ReservaID = objFactura.ReservaId,
                    Monto  = objFactura.Monto,
                    Fecha  = objFactura.Fecha,
                    NroFactura =  objFactura.NroFactura
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Factura con id:... { FacturaId }", request.Id);
            }

            return result;
        }
    }
}
