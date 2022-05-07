using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Events.Reservas
{
     public record PagoCreadoEvent : DomainEvent
    {
        public Guid ReservaId { get; }
        public decimal Monto { get; }
        public PagoCreadoEvent(Guid reservaId, decimal monto
            ) : base(DateTime.Now)
        {
            ReservaId = reservaId;
            Monto = monto;

        }
    }
}
