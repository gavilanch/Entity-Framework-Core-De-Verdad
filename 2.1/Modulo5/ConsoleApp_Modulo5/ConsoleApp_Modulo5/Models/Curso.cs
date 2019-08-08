using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo5.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
