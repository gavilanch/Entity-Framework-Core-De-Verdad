using ConsoleApp_Modulo3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class BorrandoData
    {
        public void Codigo()
        {
            // Modelo Conectado
            using (var context = new ApplicationDbContext())
            {
                var estudiante1 = context.Estudiantes.FirstOrDefault();
                if (estudiante1 != null)
                {
                    Console.WriteLine($"Estudiante a ser removido: { estudiante1.Nombre}");
                    context.Remove(estudiante1);
                    context.SaveChanges();
                }
            }

            // Modelo Desconectado
            var idEstudiante = 0;

            using (var context = new ApplicationDbContext())
            {
                idEstudiante = context.Estudiantes.Select(x => x.Id).First();
            }

            using (var context = new ApplicationDbContext())
            {
                var student = new Estudiante();
                student.Id = idEstudiante;
                context.Entry(student).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }
    }
}
