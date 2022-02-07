using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class FacturaConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable(name: "Facturas", opciones =>
            {
                opciones.IsTemporal(t =>
                {
                    t.HasPeriodStart("Desde");
                    t.HasPeriodEnd("Hasta");
                    t.UseHistoryTable(name: "FacturasHistorico");
                });
            });

            builder.Property<DateTime>("Desde").HasColumnType("datetime2");
            builder.Property<DateTime>("Hasta").HasColumnType("datetime2");

            builder.HasMany(typeof(FacturaDetalle)).WithOne();

            builder.Property(f => f.NumeroFactura)
                .HasDefaultValueSql("NEXT VALUE FOR factura.NumeroFactura");

            //builder.Property(f => f.Version).IsRowVersion();
        }
    }
}
