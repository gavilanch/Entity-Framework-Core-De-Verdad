using EFCorePeliculas.Entidades;

namespace EFCorePeliculas.DTOs
{
    public class SalaDeCineCreacionDTO
    {
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
    }
}
