using ConsoleApp_Modulo3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class MapeoFlexible
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiante1 = new Estudiante();
                estudiante1.Nombre = "juAn VAldeZ";
                estudiante1.FechaNacimiento = new DateTime(1987, 2, 5);

                context.Estudiantes.Add(estudiante1);

                context.SaveChanges();
            }

        }
    }
}
