namespace EFCorePeliculas.DTOs
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public ICollection<GeneroDTO> Generos { get; set; } = new List<GeneroDTO>();
        public ICollection<CineDTO> Cines { get; set; }
        public ICollection<ActorDTO> Actores { get; set; }
    }
}
