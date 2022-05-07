using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Dominio.Factories.Reservas;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Repositories;
using Reservas.Dominio.Repositories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.CancelarReserva
{
    public class CancelarReservaHandler : IRequestHandler<CancelarReservaCommand, Guid>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<CancelarReservaHandler> _logger;
        private readonly IReservaService _reservaService;
        private readonly IReservaFactory _reservaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CancelarReservaHandler(IReservaRepository reservaRepository, ILogger<CancelarReservaHandler> logger,
            IReservaService reservaService, IReservaFactory reservaFactory, IUnitOfWork unitOfWork)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
            _reservaService = reservaService;
            _reservaFactory = reservaFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CancelarReservaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Reserva objReserva = await _reservaRepository.FindByIdAsync(request.ReservaId);
                objReserva.CancelarReserva();                
                await _reservaRepository.UpdateAsync(objReserva);
                await _reservaService.EnviarEmailCancelacionReserva(objReserva);
                await _unitOfWork.Commit();
                return objReserva.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cancelar la Reserva");
            }
            return Guid.Empty;

        }



    }
}
