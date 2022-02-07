using EFCorePeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Servicios
{
    public class Singleton
    {
        private readonly IServiceProvider serviceProvider;

        public Singleton(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Genero>> ObtenerGeneros()
        {
            await using (var scope = serviceProvider.CreateAsyncScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                return await context.Generos.ToListAsync();
            }
        }
    }
}
