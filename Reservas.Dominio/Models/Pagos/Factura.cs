using Reservas.Dominio.Models.Pagos.ValueObjetcs;
using Reservas.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Models.Pagos
{
    public class Factura : AggregateRoot<Guid>
    {
        public Guid ReservaId { get; private set; }
        public MontoValue Monto { get; private set; }
        public DateTime Fecha { get; private set; }
        public NumeroFacturaValue NroFactura { get; private set; }


        private Factura() { }
        public Factura(String nroFactura)
        {
            Id = Guid.NewGuid();
            Monto = new MontoValue(0m);
            NroFactura = nroFactura;     

        }
        public void CrearFactura(Guid reservaId, decimal monto)
        {
            Monto = monto;
            ReservaId = reservaId;
            Fecha = DateTime.Now;

        }

        public string getNroFactura()
        {
            return NroFactura;
        }

    }
}
