using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Actore
    {
        public Actore()
        {
            PeliculasActores = new HashSet<PeliculasActore>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string FotoUrl { get; set; }
        public string BillingAddressCalle { get; set; }
        public string BillingAddressPais { get; set; }
        public string BillingAddressProvincia { get; set; }
        public string Calle { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }

        public virtual ICollection<PeliculasActore> PeliculasActores { get; set; }
    }
}
