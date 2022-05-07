using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.ReadModel
{
    public class FacturaReadModel
    {
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public String NroFactura { get; set; }
        public ReservaReadModel Reserva { get; set; }

    }
}
