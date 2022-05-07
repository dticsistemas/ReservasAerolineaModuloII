using Reservas.Dominio.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Factories.Reservas
{
    public interface IReservaFactory
    {
        Reserva Create(string nroReserva);
    }
}
