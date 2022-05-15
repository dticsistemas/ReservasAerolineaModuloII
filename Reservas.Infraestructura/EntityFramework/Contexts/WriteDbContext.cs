using Microsoft.EntityFrameworkCore;
using Reservas.Dominio.Events.Reservas;
using Reservas.Dominio.Models.Clientes;
using Reservas.Dominio.Models.Pagos;
using Reservas.Dominio.Models.Reservas;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Infraestructura.EntityFramework.Config.WriteConfig;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Cliente> Cliente{ get; set; }

        public virtual DbSet<Vuelo> Vuelo { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }


        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var clienteConfig = new ClienteWriteConfig();
            modelBuilder.ApplyConfiguration<Cliente>(clienteConfig);

            var vueloConfig = new VueloWriteConfig();
            modelBuilder.ApplyConfiguration<Vuelo>(vueloConfig);

            var reservaConfig = new ReservaWriteConfig();
            modelBuilder.ApplyConfiguration<Reserva>(reservaConfig);

            var pagoConfig = new PagoWriteConfig();
            modelBuilder.ApplyConfiguration<Pago>(pagoConfig);

            var facturaConfig = new FacturaWriteConfig();
            modelBuilder.ApplyConfiguration<Factura>(facturaConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaCreadaEvent>();
        }
    }
}
