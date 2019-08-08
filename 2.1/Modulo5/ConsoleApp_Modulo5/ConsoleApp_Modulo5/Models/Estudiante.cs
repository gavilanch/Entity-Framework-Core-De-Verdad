using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Modulo5.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public bool EstaBorrado { get; set; }
        public List<Contacto> Contactos { get; set; }
        public EstudianteDetalle Detalle { get; set; }
        public List<EstudianteCurso> EstudianteCursos { get; set; }


        // En caso de utilizar carga perezosa
        //public virtual List<Contacto> Contactos { get; set; }
    }

    public class EstudianteBecado : Estudiante
    {
        public Beca Beca { get; set; }
    }

    public class EstudianteNoBecado : Estudiante
    {

    }

    public class Beca
    {
        public int Id { get; set; }
        public string InstitucionOtorgaBeca { get; set; }
        public decimal Porcentaje { get; set; }
    }


}
