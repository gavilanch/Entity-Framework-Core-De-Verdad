using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreQueriesEspaciales
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCoreEspacial;Integrated Security=True",
                    x => x.UseNetTopologySuite())
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(MyLoggerFactory);

            base.OnConfiguring(optionsBuilder);
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

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            modelBuilder.Entity<Restaurante>()
                .HasData(
                new List<Restaurante>()
            {
                new Restaurante(){Id = 1, Nombre = "Agora", Ciudad = "Santo Domingo", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233))},
                new Restaurante(){Id = 2, Nombre = "Sambil", Ciudad = "Santo Domingo", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9118804, 18.4826214))},
                new Restaurante(){Id = 3, Nombre = "Adrian Tropical", Ciudad = "Santo Domingo", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9334673, 18.4718075))},
                new Restaurante(){Id = 4, Nombre = "Restaurante El Cardenal", Ciudad = "Ciudad de México", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-99.1353659,19.4336164))}
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}
