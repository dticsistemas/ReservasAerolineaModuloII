using Reservas.Aplicacion.Services.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.Services
{
    public class ReservaServiceTest
    {
        [Theory]
        [InlineData("ABC",false)]
        [InlineData("123", false)]
        [InlineData("456", false)]
        [InlineData("789", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("2022", false)]
        public async void GenerarNroReserva_CheckValidData(string expectedNroReserva, bool isEqual)
        {
            var reservaService = new ReservaService();
            string nroReserva = await reservaService.GenerarNroReservaAsync();
            if(isEqual)
            {
                Assert.Equal(expectedNroReserva,nroReserva);
            }
            else
            {
                Assert.NotEqual(expectedNroReserva, nroReserva);
            }

        }
    }
}
