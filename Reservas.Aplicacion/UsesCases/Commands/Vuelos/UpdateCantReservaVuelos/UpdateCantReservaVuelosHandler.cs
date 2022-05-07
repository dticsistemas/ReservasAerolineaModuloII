using MediatR;
using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Dominio.Repositories.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Vuelos.UpdateCantReservaVuelos
{
    public class UpdateCantReservaVuelosHandler : INotificationHandler<ReservaCreadaEvent>
    {
        private readonly IVueloRepository _vueloRepository;

        public UpdateCantReservaVuelosHandler(IVueloRepository vueloRepository)
        {
            _vueloRepository = vueloRepository;
        }

        public async Task Handle(ReservaCreadaEvent notification, CancellationToken cancellationToken)
        {
            
            Vuelo objVuelo = await _vueloRepository.FindByIdAsync(notification.VueloId);
            objVuelo.DescontarCantidadVuelo();
            await _vueloRepository.UpdateAsync(objVuelo);
        }
    }
}
