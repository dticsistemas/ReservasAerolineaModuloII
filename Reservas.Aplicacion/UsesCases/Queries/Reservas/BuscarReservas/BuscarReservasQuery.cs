using MediatR;
using Reservas.Aplicacion.Dtos.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.UsesCases.Queries.Reservas.BuscarReservas
{
    public class BuscarReservasQuery : IRequest<ICollection<ReservaDto>>
    {
        public string CodReserva { get; set; }
    }
}
