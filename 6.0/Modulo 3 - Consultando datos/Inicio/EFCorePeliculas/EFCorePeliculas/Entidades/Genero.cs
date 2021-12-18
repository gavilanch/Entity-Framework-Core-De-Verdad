using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    //[Table("TablaGeneros", Schema = "peliculas")]
    public class Genero
    {
        //[Key]
        public int Identificador { get; set; }
        //[StringLength(150)]
        //[MaxLength(150)]
        //[Required]
        //[Column("NombreGenero")]
        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
