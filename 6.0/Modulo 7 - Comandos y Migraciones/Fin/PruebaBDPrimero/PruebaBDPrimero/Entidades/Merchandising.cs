using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Merchandising
    {
        public int Id { get; set; }
        public bool DisponibleEnInventario { get; set; }
        public double Peso { get; set; }
        public double Volumen { get; set; }
        public bool EsRopa { get; set; }
        public bool EsColeccionable { get; set; }

        public virtual Producto IdNavigation { get; set; }
    }
}
