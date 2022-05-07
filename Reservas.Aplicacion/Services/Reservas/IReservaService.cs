using Reservas.Dominio.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.Services.Reservas
{
    public interface IReservaService
    {
        Task<string> GenerarNroReservaAsync();
        Task<string> EnviarEmailReserva(Reserva reserva);
        Task<string> EnviarEmailCancelacionReserva(Reserva reserva);

    }
}
