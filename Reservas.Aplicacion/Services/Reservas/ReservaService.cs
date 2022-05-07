using Reservas.Dominio.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.Services.Reservas
{
    public class ReservaService : IReservaService
    {
        public Task<string> GenerarNroReservaAsync()
        {            
            return Task.FromResult(GeneradorCodigo(10));
        } 

        public Task<string> EnviarEmailReserva(Reserva reserva)
        {
            String QRReserva = reserva.CodReserva + "-" + reserva.TipoReserva + "-" + reserva.Monto;
            return Task.FromResult("EMAIL ENVIADO RESERVA REALIZADA" + QRReserva);
            

        }
        public Task<string> EnviarEmailCancelacionReserva(Reserva reserva)
        {
            return Task.FromResult("RESERVA CANCELADA");
        }

        
        public static string GeneradorCodigo(int length)
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        

    }
}
