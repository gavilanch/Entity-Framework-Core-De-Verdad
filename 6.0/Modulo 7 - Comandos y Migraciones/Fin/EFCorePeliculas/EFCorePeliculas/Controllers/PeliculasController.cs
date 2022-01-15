using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using EFCorePeliculas.Entidades.SinLlaves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("PeliculasConConteos")]
        public async Task<ActionResult<IEnumerable<PeliculaConConteos>>> GetPeliculasConConteos()
        {
            return await context.Set<PeliculaConConteos>().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Generos.OrderByDescending(g => g.Nombre))
                .Include(p => p.SalasDeCine)
                    .ThenInclude(s => s.Cine)
                .Include(p => p.PeliculasActores.Where(pa => pa.Actor.FechaNacimiento.Value.Year >= 1980))
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null)
            {
                return NotFound();
            }

            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);

            peliculaDTO.Cines = peliculaDTO.Cines.DistinctBy(x => x.Id).ToList();

            return peliculaDTO;
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult<List<PeliculaDTO>>> Filtrar(
                [FromQuery] PeliculasFiltroDTO peliculasFiltroDTO)
        {
            var peliculasQueryable = context.Peliculas.AsQueryable();

            if (!string.IsNullOrEmpty(peliculasFiltroDTO.Titulo))
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.Titulo.Contains(peliculasFiltroDTO.Titulo));
            }

            if (peliculasFiltroDTO.EnCartelera)
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.EnCartelera);
            }

            if (peliculasFiltroDTO.ProximosEstrenos)
            {
                var hoy = DateTime.Today;
                peliculasQueryable = peliculasQueryable.Where(p => p.FechaEstreno > hoy);
            }

            if (peliculasFiltroDTO.GeneroId != 0)
            {
                peliculasQueryable = peliculasQueryable.Where(p => 
                    p.Generos.Select(g => g.Identificador)
                            .Contains(peliculasFiltroDTO.GeneroId));
            }

            var peliculas = await peliculasQueryable.Include(p => p.Generos).ToListAsync();

            return mapper.Map<List<PeliculaDTO>>(peliculas);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);
            pelicula.Generos.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
            pelicula.SalasDeCine.ForEach(s => context.Entry(s).State = EntityState.Unchanged);

            if (pelicula.PeliculasActores is not null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
