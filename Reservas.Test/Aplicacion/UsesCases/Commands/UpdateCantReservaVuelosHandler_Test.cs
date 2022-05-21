using Moq;
using Reservas.Aplicacion.UsesCases.Commands.Vuelos.UpdateCantReservaVuelos;
using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Dominio.Repositories.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.UsesCases.Commands
{
    public class UpdateCantReservaVuelosHandler_Test
    {
        private readonly Mock<IVueloRepository> vueloRepository;
        public UpdateCantReservaVuelosHandler_Test()
        {
            vueloRepository = new Mock<IVueloRepository>();

        }
        [Fact]
        public void Handle_Correctly()
        {
            var reservaIdTest = Guid.NewGuid();
            var vueloIdTest = Guid.NewGuid();
            int cantidadVueloTest=125;
            string detalleVueloTest = "LPZ-SC"; 
            decimal precioPasajeTest = new decimal(3.0);

            var vueloTest = new Vuelo(cantidadVueloTest,detalleVueloTest,precioPasajeTest);
            var handler = new UpdateCantReservaVuelosHandler(vueloRepository.Object);
            var tcs = new CancellationTokenSource(1000);
            vueloRepository.Setup(mock => mock.FindByIdAsync(vueloIdTest))
                .Returns(Task.FromResult(vueloTest));

            var objRequest = new ReservaCreadaEvent(reservaIdTest,vueloIdTest);
            var result = handler.Handle(objRequest,tcs.Token);

            Assert.Equal(124,vueloTest.Cantidad);

        }
    }
}
