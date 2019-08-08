using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class Filtros
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var students = context.Estudiantes
                .Where(x => x.FechaNacimiento >= DateTime.Today.AddYears(-30)).ToList();
            }

            using (var context = new ApplicationDbContext())
            {
                var student = context.Estudiantes.FirstOrDefault(x => x.Id == 5);
            }
        }
    }
}
