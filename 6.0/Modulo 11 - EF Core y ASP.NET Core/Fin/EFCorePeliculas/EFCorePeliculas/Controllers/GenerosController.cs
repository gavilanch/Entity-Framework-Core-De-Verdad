using AutoMapper;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public GenerosController(ApplicationDbContext context, IMapper mapper,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.context = context;
            this.mapper = mapper;
            this.dbContextFactory = dbContextFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            using (var nuevoContext = dbContextFactory.CreateDbContext())
            {
                nuevoContext.Logs.Add(new Log
                {
                    Id = Guid.NewGuid(),
                    Mensaje = "Ejecutando el método GenerosController.Get"
                });
                await nuevoContext.SaveChangesAsync();
                return await nuevoContext.Generos.OrderByDescending(g => EF.Property<DateTime>(g, "FechaCreacion")).ToListAsync();
            }
        }

        [HttpGet("procedimiento_almacenado/{id:int}")]
        public async Task<ActionResult<Genero>> GetSP(int id)
        {
            var generos = context.Generos
                        .FromSqlInterpolated($"EXEC Generos_ObtenerPorId {id}")
                        .IgnoreQueryFilters()
                        .AsAsyncEnumerable();

            await foreach (var genero in generos)
            {
                return genero;
            }

            return NotFound();
        }

        [HttpPut("modificar_varias_veces")]
        public async Task<ActionResult> ModificarVariasVeces()
        {
            var id = 3;
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Identificador == id);

            genero.Nombre = "Comedia 2";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 3";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 4";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 5";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 6";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia Actual";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            return Ok();
        }


        [HttpPost("Procedimiento_almacenado")]
        public async Task<ActionResult> PostSP(Genero genero)
        {
            var existeGeneroConNombre = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGeneroConNombre)
            {
                return BadRequest("Ya existe un género con ese nombre: " + genero.Nombre);
            }

            var outputId = new SqlParameter();
            outputId.ParameterName = "@id";
            outputId.SqlDbType = System.Data.SqlDbType.Int;
            outputId.Direction = System.Data.ParameterDirection.Output;

            await context.Database
                .ExecuteSqlRawAsync("EXEC Generos_Insertar @nombre = {0}, @id = {1} OUTPUT",
                genero.Nombre, outputId);

            var id = (int)outputId.Value;
            return Ok(id);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            var fechaCreacion = context.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue;
            var periodStart = context.Entry(genero).Property<DateTime>("PeriodStart").CurrentValue;
            var periodEnd = context.Entry(genero).Property<DateTime>("PeriodEnd").CurrentValue;

            return Ok(new
            {
                Id = genero.Identificador,
                Nombre = genero.Nombre,
                fechaCreacion,
                periodStart,
                periodEnd
            });
        }

        [HttpGet("TemporalAll/{id:int}")]
        public async Task<ActionResult> GetTemporalAll(int id)
        {
            var generos = await context.Generos.TemporalAll().AsTracking()
                .Where(g => g.Identificador == id)
                .Select(g => new
                {
                    Id = g.Identificador,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }

        [HttpGet("TemporalAsOf/{id:int}")]
        public async Task<ActionResult> GetTemporalAsOf(int id, DateTime fecha)
        {
            var genero = await context.Generos.TemporalAsOf(fecha).AsTracking()
                .Where(g => g.Identificador == id)
                .Select(g => new
                {
                    Id = g.Identificador,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                }).FirstOrDefaultAsync();

            return Ok(genero);
        }

        [HttpGet("TemporalFromTo/{id:int}")]
        public async Task<ActionResult> GetTemporalFromTo(int id, DateTime desde, DateTime hasta)
        {
            var generos = await context.Generos.TemporalFromTo(desde, hasta).AsTracking()
                .Where(g => g.Identificador == id)
                .Select(g => new
                {
                    Id = g.Identificador,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }

        [HttpGet("TemporalContainedIn/{id:int}")]
        public async Task<ActionResult> GetTemporalContainedIn(int id, DateTime desde, DateTime hasta)
        {
            var generos = await context.Generos.TemporalContainedIn(desde, hasta).AsTracking()
                .Where(g => g.Identificador == id)
                .Select(g => new
                {
                    Id = g.Identificador,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }

        [HttpGet("TemporalBetween/{id:int}")]
        public async Task<ActionResult> GetTemporalBetween(int id, DateTime desde, DateTime hasta)
        {
            var generos = await context.Generos.TemporalBetween(desde, hasta).AsTracking()
                .Where(g => g.Identificador == id)
                .Select(g => new
                {
                    Id = g.Identificador,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }


        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            var existeGeneroConNombre = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGeneroConNombre)
            {
                return BadRequest("Ya existe un género con ese nombre: " + genero.Nombre);
            }

            //context.Add(genero);
            //context.Entry(genero).State = EntityState.Added;

            await context.Database.ExecuteSqlInterpolatedAsync($@"
            INSERT INTO Generos(Nombre)
            VALUES({genero.Nombre})");

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(Genero[] generos)
        {
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(GeneroActualizacionDTO generoActualizacionDTO)
        {
            var genero = mapper.Map<Genero>(generoActualizacionDTO);
            context.Update(genero);
            context.Entry(genero).Property(g => g.Nombre)
                    .OriginalValue = generoActualizacionDTO.Nombre_Original;
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("agregar2")]
        public async Task<ActionResult> Agregar2(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.Nombre += " 2";
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            context.Remove(genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("borradoSuave/{id:int}")]
        public async Task<ActionResult> DeleteSuave(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = true;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Restaurar/{id:int}")]
        public async Task<ActionResult> Restaurar(int id)
        {
            var genero = await context.Generos.AsTracking()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = false;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Restaurar_Borrado/{id:int}")]
        public async Task<ActionResult> RestaurarBorrado(int id, DateTime fecha)
        {
            var genero = await context.Generos.TemporalAsOf(fecha).AsTracking()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(g => g.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            try
            {
                await context.Database.ExecuteSqlInterpolatedAsync($@"

                SET IDENTITY_INSERT Generos ON;

                INSERT INTO Generos (Identificador, Nombre)
                VALUES ({genero.Identificador}, {genero.Nombre})

                SET IDENTITY_INSERT Generos OFF;");
            }
            finally
            {
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Generos OFF;");
            }

            return Ok();
        }

        [HttpPost("concurrency_token")]
        public async Task<ActionResult> ConcurrencyToken()
        {
            var generoId = 1;

            // Felipe lee el registro de la BD.
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Identificador == generoId);
            genero.Nombre = "Felipe estuvo aquí";

            // Claudia actualiza el registro en la BD.
            await context.Database.ExecuteSqlInterpolatedAsync(@$"UPDATE Generos SET Nombre = 'Claudia estuvo aquí' 
                                                        WHERE Identificador = {generoId}");
            // Felipe intenta actualizar.
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
