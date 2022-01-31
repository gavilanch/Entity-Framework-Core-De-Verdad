using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        //[Unicode(false)]
        public string PosterURL { get; set; }
        public List<Genero> Generos { get; set; }
        public List<SalaDeCine> SalasDeCine { get; set; }
        public List<PeliculaActor> PeliculasActores { get; set; }
    }
}
