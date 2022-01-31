using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {

            builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
            
            builder.Property(prop => prop.Nombre)
              .HasMaxLength(150)
              .IsRequired();

            builder.HasOne(c => c.CineOferta)
                .WithOne()
                .HasForeignKey<CineOferta>(co => co.CineId);

            builder.HasMany(c => c.SalasDeCine)
                .WithOne(s => s.Cine)
                .HasForeignKey(s => s.ElCine)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.CineDetalle).WithOne(cd => cd.Cine)
                .HasForeignKey<CineDetalle>(cd => cd.Id);

            builder.OwnsOne(c => c.Direccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Provincia).HasColumnName("Provincia");
                dir.Property(d => d.Pais).HasColumnName("Pais");
            });
        }
    }
}
