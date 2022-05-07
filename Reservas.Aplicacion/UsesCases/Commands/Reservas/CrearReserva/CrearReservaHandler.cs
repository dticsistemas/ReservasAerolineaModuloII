using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Dominio.Factories.Reservas;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Dominio.Repositories;
using Reservas.Dominio.Repositories.Reservas;
using Reservas.Dominio.Repositories.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva
{
    public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Guid>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IVueloRepository _vueloRepository;
        private readonly ILogger<CrearReservaHandler> _logger;
        private readonly IReservaService _reservaService;
        private readonly IReservaFactory _reservaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearReservaHandler(IReservaRepository reservaRepository, ILogger<CrearReservaHandler> logger,
            IReservaService reservaService, IReservaFactory reservaFactory, IUnitOfWork unitOfWork, IVueloRepository vueloRepository)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
            _reservaService = reservaService;
            _reservaFactory = reservaFactory;
            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;

        }
        public async Task<Guid> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Vuelo objVuelo = await _vueloRepository.FindByIdAsync(request.vueloId);
                if (objVuelo.Cantidad > 0)
                {
                    string nroReserva = await _reservaService.GenerarNroReservaAsync();

                    Reserva objReserva = _reservaFactory.Create(nroReserva);

                    objReserva.CrearReserva(request.clienteId, request.vueloId, objVuelo.PrecioPasaje, request.tipoReserva);
                    objReserva.ConsolidarReserva();

                    await _reservaService.EnviarEmailReserva(objReserva);

                    await _reservaRepository.CreateAsync(objReserva);

                    await _unitOfWork.Commit();

                    return objReserva.Id;
                }
                else
                {
                    Console.WriteLine("No existe asientos Disponibles");
                    return Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear Reserva");
            }
            return Guid.Empty;

        }

        
        
    }
}
