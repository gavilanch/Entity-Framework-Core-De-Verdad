using ConsoleApp_Modulo3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class LeyendoVariosRegistros
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.ToList();
            }

            // Ordenando registros
            using (var context = new ApplicationDbContext())
            {
                // Ordenado por Birthdate ASC
                var students = context.Estudiantes.OrderBy(x => x.FechaNacimiento).ToList();

                // Ordenado por Birthdate ASC, Name ASC
                var students2 = context.Estudiantes
                .OrderBy(x => x.FechaNacimiento).ThenBy(x => x.Nombre).ToList();

                // Ordernado por Birthdate ASC, Name DESC
                var students3 = context.Estudiantes
                .OrderByDescending(x => x.FechaNacimiento).ThenByDescending(x => x.Nombre).ToList();
            }

            // Otras colecciones
            using (var context = new ApplicationDbContext())
            {
                var studentsArray = context.Estudiantes.ToArray();
                var studentsDictionary = context.Estudiantes.ToDictionary(x => x.Id);
                var studentsLookup = context.Estudiantes.ToLookup(x => x.Id % 2 == 0);
                var studentsGrouped = context.Estudiantes.GroupBy(x => x.Id % 2 == 0);
            }
        }

        public List<Estudiante> GetStudents()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.ToList();
                return estudiantes;
            }
        }
    }
}
