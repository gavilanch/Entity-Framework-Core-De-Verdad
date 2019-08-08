using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionesEscalares.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public CategoriaDePago CategoriaDePago { get; set; }
        public bool EstaBorrado { get; set; }
        public List<EstudianteCurso> EstudianteCursos { get; set; }
    }

    public enum CategoriaDePago
    {
        Desconocida = 0,
        BuenaPaga = 1,
        MalaPaga = 2
    }

}
