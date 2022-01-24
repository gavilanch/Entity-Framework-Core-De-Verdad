using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    //[Index(nameof(Nombre), IsUnique = true)]
    public class Genero
    {
        public int Identificador { get; set; }
        public string Nombre { get; set; }
        public bool EstaBorrado { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
        public string Ejemplo { get; set; }
        //public string Ejemplo2 { get; set; }
    }
}
