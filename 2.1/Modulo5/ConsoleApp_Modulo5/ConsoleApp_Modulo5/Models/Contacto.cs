using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo5.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Relacion { get; set; }
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        // En caso de utilizar carga perezosa
        //public virtual Estudiante Estudiante { get; set; }

    }
}
