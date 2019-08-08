using ConsoleApp_Modulo5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo5
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EFCore_Modulo5;Integrated Security=True")
                .EnableSensitiveDataLogging(true)
                // descomenta la siguiente línea para utilizar Carga Perezosa
                //.UseLazyLoadingProxies()
                .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).HasField("_Name");

            modelBuilder.Entity<Estudiante>().HasQueryFilter(x => x.EstaBorrado == false);

            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new { x.CursoId, x.EstudianteId });

            var student1 = new Estudiante() { Id = 7, Nombre = "Robert Seed", FechaNacimiento = new DateTime(1990, 4, 12), EstaBorrado = false };
            modelBuilder.Entity<Estudiante>().HasData(student1);

            // Cambia el nombre de la tabla del modelo Estudiante a Estudiantes
            modelBuilder.Entity<Estudiante>().ToTable("Estudiantes");

            // Cambia el nombre y define el esquema como "ed"
            modelBuilder.Entity<Estudiante>().ToTable("Estudiantes", "ed");

            modelBuilder.Entity<Estudiante>().HasIndex(estudiante => new { estudiante.Nombre, estudiante.EstaBorrado });

            // Llave primaria simple
            modelBuilder.Entity<Estudiante>().HasKey(x => x.Id);
            // Llave primaria compuesta
            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new { x.CursoId, x.EstudianteId });

            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).IsRequired();
            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).HasDefaultValue("DESCONOCIDO");
            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).HasDefaultValueSql("Left('Felipe',2)");
            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).HasColumnType("char(30)");
            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).IsConcurrencyToken();

            modelBuilder.Entity<Estudiante>()
              .HasMany(x => x.Contactos)
              .WithOne(x => x.Estudiante)
              .HasForeignKey(x => x.EstudianteId);

            modelBuilder.Entity<Estudiante>()
           .HasOne(x => x.Detalle)
           .WithOne();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteBecado> EstudiantesBecados { get; set; }
        public DbSet<EstudianteNoBecado> EstudiantesNoBecados { get; set; }
        public DbSet<EstudianteDetalle> EstudianteDetalles { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Contacto> ContactOs { get; set; }
    }
}
