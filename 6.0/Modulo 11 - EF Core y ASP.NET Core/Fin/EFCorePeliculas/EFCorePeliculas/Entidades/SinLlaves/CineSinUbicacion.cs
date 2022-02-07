using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades.SinLlaves
{
    //[Keyless]
    public class CineSinUbicacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
