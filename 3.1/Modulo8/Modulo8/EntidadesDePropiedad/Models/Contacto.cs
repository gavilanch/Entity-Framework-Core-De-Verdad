using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesDePropiedad.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Relacion { get; set; }
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public Direccion Casa { get; set; }

    }
}
