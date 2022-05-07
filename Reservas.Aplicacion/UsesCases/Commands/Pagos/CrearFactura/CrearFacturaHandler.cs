using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Factories.Pagos;
using Reservas.Dominio.Models.Pagos;
using Reservas.Dominio.Repositories;
using Reservas.Dominio.Repositories.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura
{    
     public class CrearFacturaHandler : INotificationHandler<PagoCompletadoEvent>
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly ILogger<CrearFacturaHandler> _logger;
        private readonly IFacturaService _facturaService;
        private readonly IFacturaFactory _facturaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearFacturaHandler(IFacturaRepository facturaRepository,
            IFacturaService facturaService, IFacturaFactory facturaFactory, IUnitOfWork unitOfWork)
        {
            _facturaRepository = facturaRepository;
            _facturaService = facturaService;
            _facturaFactory = facturaFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(PagoCompletadoEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                string nroFactura = await _facturaService.GenerarNroFacturaAsync();

                Factura objFactura = _facturaFactory.Create(nroFactura);

                objFactura.CrearFactura(notification.ReservaId, notification.Monto);

                await _facturaService.EnviarEmailFactura(objFactura);
                await _facturaRepository.CreateAsync(objFactura);               

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear Factura");
            }
        }

    }
}
