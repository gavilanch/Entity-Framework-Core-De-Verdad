using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Nombre)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.Nombre).HasField("_nombre");

            //builder.Ignore(a => a.Edad);
            //builder.Ignore(a => a.Direccion);

            builder.OwnsOne(a => a.DireccionHogar, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Provincia).HasColumnName("Provincia");
                dir.Property(d => d.Pais).HasColumnName("Pais");
            });
        }
    }
}
