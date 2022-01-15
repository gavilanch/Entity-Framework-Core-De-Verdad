using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaBDPrimero.Entidades
{
    public partial class EFCorePeliculasDBContext : DbContext
    {
        public EFCorePeliculasDBContext()
        {
        }

        public EFCorePeliculasDBContext(DbContextOptions<EFCorePeliculasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actore> Actores { get; set; }
        public virtual DbSet<Cine> Cines { get; set; }
        public virtual DbSet<CinesOferta> CinesOfertas { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Mensaje> Mensajes { get; set; }
        public virtual DbSet<Merchandising> Merchandisings { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<PeliculasActore> PeliculasActores { get; set; }
        public virtual DbSet<PeliculasAlquilable> PeliculasAlquilables { get; set; }
        public virtual DbSet<PeliculasConConteo> PeliculasConConteos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<SalasDeCine> SalasDeCines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actore>(entity =>
            {
                entity.Property(e => e.BillingAddressCalle).HasColumnName("BillingAddress_Calle");

                entity.Property(e => e.BillingAddressPais).HasColumnName("BillingAddress_Pais");

                entity.Property(e => e.BillingAddressProvincia).HasColumnName("BillingAddress_Provincia");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.FotoUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FotoURL");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Cine>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<CinesOferta>(entity =>
            {
                entity.HasIndex(e => e.CineId, "IX_CinesOfertas_CineId")
                    .IsUnique()
                    .HasFilter("([CineId] IS NOT NULL)");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.PorcentajeDescuento).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Cine)
                    .WithOne(p => p.CinesOferta)
                    .HasForeignKey<CinesOferta>(d => d.CineId);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Identificador);

                entity.HasIndex(e => e.Nombre, "IX_Generos_Nombre")
                    .IsUnique()
                    .HasFilter("([EstaBorrado]='false')");

                entity.Property(e => e.EstaBorrado)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasMany(d => d.Peliculas)
                    .WithMany(p => p.GenerosIdentificadors)
                    .UsingEntity<Dictionary<string, object>>(
                        "GeneroPelicula",
                        l => l.HasOne<Pelicula>().WithMany().HasForeignKey("PeliculasId"),
                        r => r.HasOne<Genero>().WithMany().HasForeignKey("GenerosIdentificador"),
                        j =>
                        {
                            j.HasKey("GenerosIdentificador", "PeliculasId");

                            j.ToTable("GeneroPelicula");

                            j.HasIndex(new[] { "PeliculasId" }, "IX_GeneroPelicula_PeliculasId");
                        });
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.HasIndex(e => e.EmisorId, "IX_Mensajes_EmisorId");

                entity.HasIndex(e => e.ReceptorId, "IX_Mensajes_ReceptorId");

                entity.HasOne(d => d.Emisor)
                    .WithMany(p => p.MensajeEmisors)
                    .HasForeignKey(d => d.EmisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Receptor)
                    .WithMany(p => p.MensajeReceptors)
                    .HasForeignKey(d => d.ReceptorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Merchandising>(entity =>
            {
                entity.ToTable("Merchandising");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Merchandising)
                    .HasForeignKey<Merchandising>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(e => e.CorreoElectronico).HasMaxLength(150);

                entity.Property(e => e.FechaTransaccion).HasColumnType("date");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ultimos4Digitos)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.Property(e => e.FechaEstreno).HasColumnType("date");

                entity.Property(e => e.PosterUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PosterURL");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasMany(d => d.SalasDeCines)
                    .WithMany(p => p.Peliculas)
                    .UsingEntity<Dictionary<string, object>>(
                        "PeliculaSalaDeCine",
                        l => l.HasOne<SalasDeCine>().WithMany().HasForeignKey("SalasDeCineId"),
                        r => r.HasOne<Pelicula>().WithMany().HasForeignKey("PeliculasId"),
                        j =>
                        {
                            j.HasKey("PeliculasId", "SalasDeCineId");

                            j.ToTable("PeliculaSalaDeCine");

                            j.HasIndex(new[] { "SalasDeCineId" }, "IX_PeliculaSalaDeCine_SalasDeCineId");
                        });
            });

            modelBuilder.Entity<PeliculasActore>(entity =>
            {
                entity.HasKey(e => new { e.PeliculaId, e.ActorId });

                entity.HasIndex(e => e.ActorId, "IX_PeliculasActores_ActorId");

                entity.Property(e => e.Personaje).HasMaxLength(150);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.PeliculasActores)
                    .HasForeignKey(d => d.ActorId);

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.PeliculasActores)
                    .HasForeignKey(d => d.PeliculaId);
            });

            modelBuilder.Entity<PeliculasAlquilable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PeliculasAlquilable)
                    .HasForeignKey<PeliculasAlquilable>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PeliculasConConteo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PeliculasConConteos");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SalasDeCine>(entity =>
            {
                entity.ToTable("SalasDeCine");

                entity.HasIndex(e => e.ElCine, "IX_SalasDeCine_ElCine");

                entity.Property(e => e.Moneda)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Precio).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.TipoSalaDeCine)
                    .IsRequired()
                    .HasDefaultValueSql("(N'DosDimensiones')");

                entity.HasOne(d => d.ElCineNavigation)
                    .WithMany(p => p.SalasDeCines)
                    .HasForeignKey(d => d.ElCine)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
