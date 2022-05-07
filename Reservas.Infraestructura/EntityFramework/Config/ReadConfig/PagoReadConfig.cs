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
    public class PagoReadConfig : IEntityTypeConfiguration<PagoReadModel>
    {
    public void Configure(EntityTypeBuilder<PagoReadModel> builder)
    {
        builder.ToTable("Pago");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CodComprobante)
            .HasColumnName("codComprobante")
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
