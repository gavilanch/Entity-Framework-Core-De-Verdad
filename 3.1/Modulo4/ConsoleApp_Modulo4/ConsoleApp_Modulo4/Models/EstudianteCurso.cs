using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo4.Models
{
    public class EstudianteCurso
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public bool EstaActivo { get; set; }
        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }

    }
}
