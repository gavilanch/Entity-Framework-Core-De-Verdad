using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entidades
{
    public class CineDetalle
    {
        public int Id { get; set; }
        [Required]
        public string Historia { get; set; }
        public string Valores { get; set; }
        public string Misiones { get; set; }
        public string CodigoDeEtica { get; set; }
        public Cine Cine { get; set; }
    }
}
