using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpGet("Merchs")]
        public async Task<ActionResult<IEnumerable<Merchandising>>> GetMerchs()
        {
            return await context.Set<Merchandising>().ToListAsync();
        }

        [HttpGet("Alquileres")]
        public async Task<ActionResult<IEnumerable<PeliculaAlquilable>>> GetAlquileres()
        {
            return await context.Set<PeliculaAlquilable>().ToListAsync();
        }
    }
}
