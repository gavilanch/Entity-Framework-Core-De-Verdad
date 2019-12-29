using ConsoleApp_Modulo4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo4.CodigoVideos
{
    public class TiposDerivados
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {

                // Trae todos los estudiantes, y sus becas (si aplica)
                var allStudents = context.Estudiantes
                .Include(x => (x as EstudianteBecado).Beca).ToList();

                // Trae sólo los estudiantes becados con sus becas
                var scholarshipStudents = context.Estudiantes.OfType<EstudianteBecado>()
                .Include(x => x.Beca).ToList();
            }

        }
    }
}
