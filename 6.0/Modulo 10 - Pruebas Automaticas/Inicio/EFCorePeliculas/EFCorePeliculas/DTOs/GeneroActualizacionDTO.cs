using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.DTOs
{
    public class GeneroActualizacionDTO
    {
        public int Identificador { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Nombre_Original { get; set; }
    }
}
