using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Genero
    {
        public Genero()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int Identificador { get; set; }
        public string Nombre { get; set; }
        public bool? EstaBorrado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Ejemplo { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
