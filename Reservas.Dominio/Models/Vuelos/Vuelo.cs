using Reservas.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Models.Vuelos
{
    public class Vuelo : AggregateRoot<Guid>
    {
        public int Cantidad { get; private set; }
        public String Detalle { get; private set; }
        public MontoValue PrecioPasaje { get; private set; }
        public Vuelo()
        {
            Id = Guid.NewGuid();
        }
        public void DescontarCantidadVuelo()
        {
            Cantidad--;
        }
        public void AdicionarCantidadVuelo()
        {
            Cantidad++;
        }


    }
}
