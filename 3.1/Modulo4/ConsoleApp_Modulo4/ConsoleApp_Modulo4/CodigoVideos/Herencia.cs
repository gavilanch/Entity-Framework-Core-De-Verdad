using ConsoleApp_Modulo4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo4.CodigoVideos
{
    public class Herencia
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                // Trae todo tipo de estudiantes, tanto becados como no becados
                var todos = context.Estudiantes.ToList();

                // Trae sólo los estudiantes becados
                var estudiantesBecados = context.Estudiantes.OfType<EstudianteBecado>().ToList();

                // Trae sólo los estudiantes no becados
                var estudiantesNoBecados = context.Estudiantes.OfType<EstudianteNoBecado>().ToList();
            }

        }
    }
}
