using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesDePropiedad.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Direccion Casa { get; set; }
        public Direccion BillingAddress { get; set; }

    }
}
