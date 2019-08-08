using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelosDeQuery_Concurrencia.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<EstudianteCurso> EstudianteCursos { get; set; }

    }
}
