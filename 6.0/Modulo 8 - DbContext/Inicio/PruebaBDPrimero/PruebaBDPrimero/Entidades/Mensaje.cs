using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Mensaje
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int EmisorId { get; set; }
        public int ReceptorId { get; set; }

        public virtual Persona Emisor { get; set; }
        public virtual Persona Receptor { get; set; }
    }
}
