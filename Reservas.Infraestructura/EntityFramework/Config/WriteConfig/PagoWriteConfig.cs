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
    public class PagoWriteConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pago");
            builder.HasKey(x => x.Id);

            //-------------------------------
            var nroComprobanteConverter = new ValueConverter<CodigoComprobanteValue, string>(
                nroComprobanteValue => nroComprobanteValue.Value,
                nroComprobante => new CodigoComprobanteValue(nroComprobante)
            );
            builder.Property(x => x.CodComprobante)
                .HasColumnName("codComprobante")
                .HasConversion(nroComprobanteConverter)
                .HasMaxLength(25);
            //-------------------------------

            //--------------------------------
            var montoConverter = new ValueConverter<MontoValue, decimal>(
                 precioValue => precioValue.Value,
                 precio => new MontoValue(precio)
             );
            builder.Property(x => x.Monto)                
                .HasConversion(montoConverter)
                .HasColumnName("monto")
                .HasPrecision(12, 2);
         

            builder.Property(x => x.Fecha)
               .HasColumnName("fecha")
               .HasColumnType("datetime");

            //builder.WithOne(x => x.Detalle)
              // .WithOne(x => x.Pedido);

        }
    }
}
