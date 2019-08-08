using ModelosDeQuery_Concurrencia.Models;
using System;
using System.Linq;

namespace ModelosDeQuery_Concurrencia
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Query<StudentData>().ToList();
                var estudiantesConCursos = context.Query<EstudianteConCursos>().ToList();
                var estudiantesConCursos2 = context.EstudianteConCursos.ToList();
            }

            //using (var context = new ApplicationDbContext())
            //{
            //    var student = context.Estudiantes.First(x => x.Nombre == "Felipe");
            //    student.Nombre += " 2";
            //    context.SaveChanges();
            //}

        }
    }
}
