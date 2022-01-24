using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class SalasDeCine
    {
        public SalasDeCine()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int Id { get; set; }
        public string TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public int ElCine { get; set; }
        public string Moneda { get; set; }

        public virtual Cine ElCineNavigation { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
