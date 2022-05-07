using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Dominio.Factories.Pagos;
using Reservas.Dominio.Models.Pagos;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Repositories;
using Reservas.Dominio.Repositories.Pagos;
using Reservas.Dominio.Repositories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearPago
{
     public class CrearPagoHandler : IRequestHandler<CrearPagoCommand, Guid>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<CrearPagoHandler> _logger;
        private readonly IPagoService _pagoService;
        private readonly IPagoFactory _pagoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPagoHandler(IPagoRepository pagoRepository, ILogger<CrearPagoHandler> logger,
            IPagoService pagoService, IPagoFactory pagoFactory, IUnitOfWork unitOfWork, IReservaRepository reservaRepository
            )
        {
            _pagoRepository = pagoRepository;
            _logger = logger;
            _pagoService = pagoService;
            _pagoFactory = pagoFactory;
            _unitOfWork = unitOfWork;
            _reservaRepository = reservaRepository;
        }
        public async Task<Guid> Handle(CrearPagoCommand request, CancellationToken cancellationToken)
        {

            try
            {

                Reserva objReserva = await _reservaRepository.FindByIdAsync(request.ReservaId);
                decimal monto = request.Monto;
                if (request.Monto >= objReserva.Deuda)
                {
                    Console.WriteLine(" Monto Pagado Excede la Deuda, solo se descontara lo pendiente");
                    monto = objReserva.Deuda;
                }
                string nroComprobante = await _pagoService.GenerarNroComprobanteAsync();
                Pago objPago = _pagoFactory.Create(nroComprobante);
                objPago.CrearPago(request.ReservaId, monto);
                objPago.ConsolidarPago();
                await _pagoRepository.CreateAsync(objPago);
                if (request.Monto >= objReserva.Deuda)
                    objReserva.ConfirmarVentaReserva();
                await _unitOfWork.Commit();
                return objPago.Id;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " Error al registrar el Pago - Deuda");

            }
            return Guid.Empty;

        }

        
    }
}
