using Moq;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.ActualizarSaldoReserva;
using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Repositories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands
{
    public class ActualizarSaldoReservaHandler_Test
    {
        private readonly Mock<IReservaRepository> reservaRepository;
        public ActualizarSaldoReservaHandler_Test()
        {
            reservaRepository = new Mock<IReservaRepository>();

        }
        [Fact]
        public void Handle_Correctly()
        {
            var reservaIdTest = Guid.NewGuid();
            var clienteId = Guid.NewGuid();
            var vueloId = Guid.NewGuid();
            decimal monto = new decimal(125.0);
            decimal montoPagado = new decimal(75.0);

            var reservaTest = new Reserva("ABC");
            reservaTest.CrearReserva(clienteId, vueloId, monto, "R");
            var handler = new ActualizarSaldoReservaHandler(reservaRepository.Object);
            var tcs = new CancellationTokenSource(1000);
            reservaRepository.Setup(mock => mock.FindByIdAsync(reservaIdTest))
                .Returns(Task.FromResult(reservaTest));

            var objRequest = new PagoCreadoEvent(reservaIdTest,montoPagado);
            var result = handler.Handle(objRequest, tcs.Token);

            Assert.Equal(50, reservaTest.Deuda);

        }
    }
}
