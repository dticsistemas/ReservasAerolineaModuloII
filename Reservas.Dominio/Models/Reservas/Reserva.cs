using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Models.Reservas.ValueObjects;
using Reservas.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Models.Reservas
{
    public class Reserva : AggregateRoot<Guid>
    {

        public CodigoReservaValue CodReserva; 
        public String EstadoReserva;//public EstadoReservaValue EstadoReserva;
        public MontoValue Monto;
        public MontoValue Deuda;
        public DateTime Fecha;
        public String TipoReserva;//public TipoReservaValue TipoReserva;
        public Guid ClienteId;
        public Guid VueloId;

        private Reserva() { }
        internal Reserva(String codReserva)
        {
            Id = Guid.NewGuid();
            CodReserva = codReserva;
            Monto = new MontoValue(0m);
            Deuda = new MontoValue(0m);
            Fecha = DateTime.Now;
            EstadoReserva = "C";
        }
        public void CrearReserva(Guid clienteID, Guid vueloId, decimal monto, String tipoReserva)
        {          
            Monto = monto;
            Deuda = monto;
            ClienteId = clienteID;
            VueloId = vueloId;
            Fecha = DateTime.Now;
            EstadoReserva = "P";
            TipoReserva = tipoReserva;          
        }
        public void ConsolidarReserva()
        {
            AddDomainEvent(new ReservaCreadaEvent(Id, VueloId));           
        }
        public void CancelarReserva()
        {
            EstadoReserva = "C";
            AddDomainEvent(new ReservaCanceladaEvent(Id, VueloId));

        }
        public void ConfirmarVentaReserva()
        {
            EstadoReserva = "F";
            AddDomainEvent(new PagoCompletadoEvent(Id, Monto));
        }
        public void ActualizarSaldoDeuda(decimal Monto)
        {
            Deuda = Deuda - Monto;            
        }
        public void VigenciarEstadoReservas()
        {

        }

    }
}
