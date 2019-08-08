using System;
using System.Collections.Generic;
using System.Text;

namespace ModelosDeQuery_Concurrencia.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
