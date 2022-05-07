using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Dominio.Models.Pagos;
using Reservas.Dominio.Models.Pagos.ValueObjetcs;
using Reservas.Dominio.Models.ValueObjects;
using Reservas.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.Config.WriteConfig
{
    public class FacturaWriteConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroFactura)
                .HasColumnName("nroFactura")
                .HasMaxLength(25);
            //-------------------------------
            var nroFacturaConverter = new ValueConverter<NumeroFacturaValue, string>(
                nroFacturaValue => nroFacturaValue.Value,
                nroFactura => new NumeroFacturaValue(nroFactura)
            );
            builder.Property(x => x.NroFactura)
                .HasColumnName("nroFactura")
                .HasConversion(nroFacturaConverter)
                .HasMaxLength(25);
            //-------------------------------


            var montoConverter = new ValueConverter<MontoValue, decimal>(
                 precioValue => precioValue.Value,
                 precio => new MontoValue(precio)
             );
            builder.Property(x => x.Monto)
                .HasColumnName("monto")
                .HasConversion(montoConverter)
                .HasPrecision(12, 2);
            //-----------------------------------

            builder.Property(x => x.Fecha)
               .HasColumnName("fecha")
               .HasColumnType("datetime");

            //builder.WithOne(x => x.Detalle)
            // .WithOne(x => x.Pedido);

        }
    }
}
