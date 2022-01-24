using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class CinesOferta
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public int? CineId { get; set; }

        public virtual Cine Cine { get; set; }
    }
}
