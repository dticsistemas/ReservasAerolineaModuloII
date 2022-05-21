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
        public Vuelo(int cantidad,String detalle, decimal precioPasaje)
        {
            Id = Guid.NewGuid();
            Detalle = detalle;
            Cantidad = cantidad;
            PrecioPasaje = precioPasaje;
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
