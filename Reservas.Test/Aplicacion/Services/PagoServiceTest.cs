using Reservas.Aplicacion.Services.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Aplicacion.Services
{
    public class PagoServiceTest
    {
        [Theory]
        [InlineData("ABC", false)]
        [InlineData("123", false)]
        [InlineData("456", false)]
        [InlineData("789", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("2022", false)]
        public async void GenerarNroPago_CheckValidData(string expectedNroPago, bool isEqual)
        {
            var pagoService = new PagoService();
            string nroPago = await pagoService.GenerarNroComprobanteAsync();
            if (isEqual)
            {
                Assert.Equal(expectedNroPago, nroPago);
            }
            else
            {
                Assert.NotEqual(expectedNroPago, nroPago);
            }

        }
    }
}
