using ConsoleApp_Modulo3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class InsertandoVariosRegistros
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                // paso 1
                var estudiante1 = new Estudiante();
                estudiante1.Nombre = "Martina Griffin";
                estudiante1.FechaNacimiento = new DateTime(1989, 10, 2);

                var estudiante2 = new Estudiante();
                estudiante2.Nombre = "Wilbur Berto";
                estudiante2.FechaNacimiento = new DateTime(1995, 7, 9);

                // paso 2
                context.Estudiantes.Add(estudiante1);
                context.Add(estudiante2);

                // paso 3
                context.SaveChanges();
            }

            // Método 2: Utilizando AddRange
            using (var context = new ApplicationDbContext())
            {
                var estudiante1 = new Estudiante();
                estudiante1.Nombre = "Martina Griffin";
                estudiante1.FechaNacimiento = new DateTime(1989, 10, 2);

                var estudiante2 = new Estudiante();
                estudiante2.Nombre = "Wilbur Berto";
                estudiante2.FechaNacimiento = new DateTime(1995, 7, 9);

                var students = new List<Estudiante>() { estudiante1, estudiante2 };

                // step 2
                context.Estudiantes.AddRange(students);
                // step 3
                context.SaveChanges();

            }


        }
    }
}
