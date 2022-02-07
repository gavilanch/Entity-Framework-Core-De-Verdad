using EFCorePeliculas.Entidades;
using EFCorePeliculas.Entidades.Configuraciones;
using EFCorePeliculas.Entidades.Funciones;
using EFCorePeliculas.Entidades.Seeding;
using EFCorePeliculas.Entidades.SinLlaves;
using EFCorePeliculas.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
                : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection", opciones =>
                {
                    opciones.UseNetTopologySuite();
                }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (!Database.IsInMemory())
            {
                SeedingModuloConsulta.Seed(modelBuilder);
                SeedingPersonaMensaje.Seed(modelBuilder);
                SeedingFacturas.Seed(modelBuilder);
            }

            Escalares.RegistrarFunciones(modelBuilder);

            modelBuilder.HasSequence<int>("NumeroFactura", "factura");

            //modelBuilder.Entity<Log>().Property(l => l.Id).ValueGeneratedNever();
            //modelBuilder.Ignore<Direccion>();

            modelBuilder.Entity<CineSinUbicacion>()
                .HasNoKey().ToSqlQuery("Select Id, Nombre FROM Cines").ToView(null);

            modelBuilder.Entity<PeliculaConConteos>().HasNoKey().ToTable(name: null);

            modelBuilder.HasDbFunction(() => PeliculaConConteos(0));

            foreach (var tipoEntidad in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propiedad in tipoEntidad.GetProperties())
                {
                    if (propiedad.ClrType == typeof(string) && propiedad.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        propiedad.SetIsUnicode(false);
                        propiedad.SetMaxLength(500);
                    }
                }
            }

            modelBuilder.Entity<Merchandising>().ToTable("Merchandising");
            modelBuilder.Entity<PeliculaAlquilable>().ToTable("PeliculasAlquilables");

            var pelicula1 = new PeliculaAlquilable()
            {
                Id = 1,
                Nombre = "Spider-Man",
                PeliculaId = 1,
                Precio = 5.99m
            };

            var merch1 = new Merchandising()
            {
                Id = 2,
                DisponibleEnInventario = true,
                EsRopa = true,
                Nombre = "T-Shirt One Piece",
                Peso = 1,
                Volumen = 1,
                Precio = 11
            };

            modelBuilder.Entity<Merchandising>().HasData(merch1);
            modelBuilder.Entity<PeliculaAlquilable>().HasData(pelicula1);

        }

        [DbFunction]
        public int FacturaDetalleSuma(int facturaId)
        {
            return 0;
        }

        public IQueryable<PeliculaConConteos> PeliculaConConteos(int peliculadId)
        {
            return FromExpression(() => PeliculaConConteos(peliculadId));
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CineSinUbicacion> CinesSinUbicacion { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<CineDetalle> CineDetalle { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
