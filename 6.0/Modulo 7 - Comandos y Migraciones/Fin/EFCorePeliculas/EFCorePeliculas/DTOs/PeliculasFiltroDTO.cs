namespace EFCorePeliculas.DTOs
{
    public class PeliculasFiltroDTO
    {
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public bool EnCartelera { get; set; }
        public bool ProximosEstrenos { get; set; }
    }
}
