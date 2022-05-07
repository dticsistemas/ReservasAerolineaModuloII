using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Events.Reservas
{
    public record PagoCompletadoEvent : DomainEvent
    {
        public Guid ReservaId { get; }
        public decimal Monto { get; }
        public PagoCompletadoEvent(Guid reservaId, decimal monto
            ) : base(DateTime.Now)
        {
            ReservaId = reservaId;
            Monto = monto;

        }
    }
}
