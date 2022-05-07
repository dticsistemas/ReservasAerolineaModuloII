using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.Config.ReadConfig
{
    public class FacturaReadConfig : IEntityTypeConfiguration<FacturaReadModel>
    {
        public void Configure(EntityTypeBuilder<FacturaReadModel> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroFactura)
                .HasColumnName("nroFactura")
                .HasMaxLength(25);


            builder.Property(x => x.Monto)
                .HasColumnName("monto")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.Fecha)
               .HasColumnName("fecha")
               .HasColumnType("datetime");

            //builder.WithOne(x => x.Detalle)
            // .WithOne(x => x.Pedido);

        }
    }
}