using Reservas.Dominio.Models.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Factories.Pagos
{
    public class PagoFactory: IPagoFactory
    {
        public Pago Create(string nroComprobante)
        {
            return new Pago(nroComprobante);
        }
    }
}
