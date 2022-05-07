using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Events.Reservas
{
    public record ReservaCanceladaEvent : DomainEvent
    {
        public Guid ReservaId { get; }
        public Guid VueloId { get; }
        public ReservaCanceladaEvent(Guid reservaId, Guid vueloId
            ) : base(DateTime.Now)
        {
            ReservaId = reservaId;
            VueloId = vueloId;

        }
    }
}
