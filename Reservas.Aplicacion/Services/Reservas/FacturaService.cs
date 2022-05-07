using Reservas.Dominio.Models.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.Services.Reservas
{
    public class FacturaService : IFacturaService
    {
        public Task<string> EnviarEmailFactura(Factura factura)
        {
            return Task.FromResult("EMAIL RESERVA FACTURADA" + factura.getNroFactura());
        }
        public Task<string> GenerarNroFacturaAsync()
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
