using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesDePropiedad.Models
{
    [Owned]
    public class Direccion
    {
        public string Calle { get; set; }
        public string Ciudad { get; set; }
    }
}
