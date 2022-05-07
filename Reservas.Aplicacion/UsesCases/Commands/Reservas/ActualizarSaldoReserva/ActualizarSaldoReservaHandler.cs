using MediatR;
using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Repositories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Commands.Reservas.ActualizarSaldoReserva
{
    public class ActualizarSaldoReservaHandler : INotificationHandler<PagoCreadoEvent>
    {
        private readonly IReservaRepository _reservaRepository;

        public ActualizarSaldoReservaHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task Handle(PagoCreadoEvent notification, CancellationToken cancellationToken)
        {
            try
            { 

                Reserva objReserva = await _reservaRepository.FindByIdAsync(notification.ReservaId);
                objReserva.ActualizarSaldoDeuda(notification.Monto);

                await _reservaRepository.UpdateAsync(objReserva);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " Error al actualizar Saldo Deuda");
            }
        }
    }
}
