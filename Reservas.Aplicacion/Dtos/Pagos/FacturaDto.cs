using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.Dtos.Pagos
{
    public class FacturaDto
    {
        public Guid Id { get; set; }
        public Guid ReservaID { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get;  set; }
        public String NroFactura { get; set; }
    }
}
