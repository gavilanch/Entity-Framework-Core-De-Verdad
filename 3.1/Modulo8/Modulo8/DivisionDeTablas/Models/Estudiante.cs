using System;
using System.Collections.Generic;
using System.Text;

namespace DivisionDeTablas.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public EstudianteDetalle Detalle { get; set; }
    }

    public class EstudianteDetalle
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public Estudiante Estudiante { get; set; }

    }
}
