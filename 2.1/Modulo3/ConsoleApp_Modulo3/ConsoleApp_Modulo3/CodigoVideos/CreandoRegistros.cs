using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp1.Models;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class CreandoRegistros
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                // paso 1: Creamos el objeto
                var student1 = new Estudiante();
                student1.Nombre = "Pedro Stewart";
                student1.FechaNacimiento = new DateTime(1993, 8, 25);

                // paso 2: Notificamos que queremos agregar un estudiante
                context.Estudiantes.Add(student1);

                // paso 3: Guardamos los cambios
                context.SaveChanges();
            }

        }
    }
}
