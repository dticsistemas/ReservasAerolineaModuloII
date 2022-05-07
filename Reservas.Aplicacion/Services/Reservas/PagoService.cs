using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.Services.Reservas
{
    public class PagoService : IPagoService
    {
        public Task<string> GenerarNroComprobanteAsync()
        {
            return Task.FromResult(GeneradorCodigo(10));
        }
        public static string GeneradorCodigo(int length)
        {
            Random random = new Random();
            const string characters = "0123456789";
            return new string(Enumerable.Repeat(characters, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
