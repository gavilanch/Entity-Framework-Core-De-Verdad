using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace PruebaBDPrimero.Entidades
{
    public partial class Cine
    {
        public Cine()
        {
            SalasDeCines = new HashSet<SalasDeCine>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public Geometry Ubicacion { get; set; }
        public string CodigoDeEtica { get; set; }
        public string Historia { get; set; }
        public string Misiones { get; set; }
        public string Valores { get; set; }
        public string Calle { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }

        public virtual CinesOferta CinesOferta { get; set; }
        public virtual ICollection<SalasDeCine> SalasDeCines { get; set; }
    }
}
