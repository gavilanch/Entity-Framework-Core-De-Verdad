using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using ModelosDeQuery_Concurrencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelosDeQuery_Concurrencia
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-4KBFRF57;Initial Catalog=EFCore_Modulo8_ModelosDeQuery;Integrated Security=True")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Query<EstudianteConCursos>().ToView("EstudiantesConCursosActivos");

            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new { x.CursoId, x.EstudianteId });

            modelBuilder.Query<StudentData>()
            .ToQuery(() => Estudiantes.Select(x => new StudentData { Id = x.Id, Nombre = x.Nombre, FechaNacimiento = x.FechaNacimiento }));

            //modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).IsConcurrencyToken(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbQuery<EstudianteConCursos> EstudianteConCursos { get; set; }

    }
}
