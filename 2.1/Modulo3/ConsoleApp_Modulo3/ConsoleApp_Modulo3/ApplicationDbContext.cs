using ConsoleApp_Modulo3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo3
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EFCore_Modulo3;Integrated Security=True")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo flexible
            modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).HasField("nombre");
           
            // Filtro a nivel del modelo
            modelBuilder.Entity<Estudiante>().HasQueryFilter(x => x.EstaBorrado == false);
            
            // Data Seeding
            var estudiante1 = new Estudiante() { Id = 7, Nombre = "Robert Seed", FechaNacimiento = new DateTime(1990, 4, 12), EstaBorrado = false };
            modelBuilder.Entity<Estudiante>().HasData(estudiante1);
        }


        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }

    }
}
