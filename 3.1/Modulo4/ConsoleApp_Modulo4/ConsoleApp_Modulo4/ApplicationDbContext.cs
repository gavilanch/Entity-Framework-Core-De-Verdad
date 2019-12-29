using ConsoleApp_Modulo4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo4
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EFCore_Modulo4;Integrated Security=True")
                .EnableSensitiveDataLogging(true)
                // descomenta la siguiente línea para utilizar Carga Perezosa
                //.UseLazyLoadingProxies()
                .UseLoggerFactory(MyLoggerFactory);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information)
               .AddConsole();
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new { x.CursoId, x.EstudianteId });

            modelBuilder.Entity<Estudiante>()
                .HasDiscriminator<int>("TipoEstudiante")
                .HasValue<Estudiante>(1)
                .HasValue<EstudianteBecado>(2)
                .HasValue<EstudianteNoBecado>(3);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteBecado> EstudiantesBecados { get; set; }
        public DbSet<EstudianteNoBecado> EstudiantesNoBecados { get; set; }
        public DbSet<EstudianteDetalle> EstudianteDetalles { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
    }
}
