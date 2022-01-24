using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            PeliculasActores = new HashSet<PeliculasActore>();
            GenerosIdentificadors = new HashSet<Genero>();
            SalasDeCines = new HashSet<SalasDeCine>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterUrl { get; set; }

        public virtual ICollection<PeliculasActore> PeliculasActores { get; set; }

        public virtual ICollection<Genero> GenerosIdentificadors { get; set; }
        public virtual ICollection<SalasDeCine> SalasDeCines { get; set; }
    }
}
