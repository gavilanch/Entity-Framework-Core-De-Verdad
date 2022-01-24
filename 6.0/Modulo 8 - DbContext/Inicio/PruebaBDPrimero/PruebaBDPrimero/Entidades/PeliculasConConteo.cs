using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class PeliculasConConteo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? CantidadGeneros { get; set; }
        public int? CantidadCines { get; set; }
        public int? CantidadActores { get; set; }
    }
}
