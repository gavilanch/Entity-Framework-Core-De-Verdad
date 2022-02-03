using EFCorePeliculas.Entidades.Conversiones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);

            builder.Property(prop => prop.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones)
                .HasConversion<string>();

            builder.Property(prop => prop.Moneda)
                .HasConversion<MonedaASimboloConverter>();
        }
    }
}
