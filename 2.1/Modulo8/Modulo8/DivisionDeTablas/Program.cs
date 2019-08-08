using DivisionDeTablas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DivisionDeTablas
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                // No incluye datos de StudentDetails
                var students = context.Estudiantes.ToList();

                // Incluye datos de StudentDetails
                var studentsWithDetails = context.Estudiantes.Include(x => x.Detalle).ToList();

                var student = new Estudiante();
                student.Nombre = "George Harris";
                var estudianteDetalle = new EstudianteDetalle();
                estudianteDetalle.Cedula = "1987";

                student.Detalle = estudianteDetalle;

                context.Add(student);
                context.SaveChanges();


            }

            using (var context = new ApplicationDbContext())
            {
                var george = context.Estudiantes.First(x => x.Nombre == "George Harris");

                var estudianteDetalle = new EstudianteDetalle();
                estudianteDetalle.Id = george.Id;
                estudianteDetalle.Cedula = "01234567891";
                context.EstudiantesDetalle.Update(estudianteDetalle);
                context.SaveChanges();

            }

        }
    }
}
