using FuncionesEscalares.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncionesEscalares
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EFCore_Modulo8_FuncionesEscalares;Integrated Security=True")
                .EnableSensitiveDataLogging(true)
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

            var enumToStringConverter = new EnumToStringConverter<CategoriaDePago>();

            modelBuilder.Entity<Estudiante>().Property(x => x.CategoriaDePago).HasConversion(enumToStringConverter);

            var convertidorCadaPalabraMayuscula = new ValueConverter<string, string>
            (valorEntrante => string.Join(' ', valorEntrante.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray()),
             valorDesdeLaBD => valorDesdeLaBD);

            modelBuilder.Entity<Estudiante>()
                .Property(x => x.Nombre)
                .HasConversion(convertidorCadaPalabraMayuscula);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries()
             .Where(e => e.State == EntityState.Deleted &&
             e.Metadata.GetProperties().Any(x => x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }

            return base.SaveChanges();
        }


        [DbFunction]
        public static int Quantity_Of_Active_Courses(int StudentId)
        {
            throw new Exception();
        }

    }
}
