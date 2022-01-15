using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class PeliculasAlquilable
    {
        public int Id { get; set; }
        public int PeliculaId { get; set; }

        public virtual Producto IdNavigation { get; set; }
    }
}
