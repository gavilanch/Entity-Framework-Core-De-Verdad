using ConsoleApp_Modulo4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo4.CodigoVideos
{
    public class MuchosAMuchos
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var curso1 = new Curso();
                curso1.Nombre = "Programación I";

                var curso2 = new Curso();
                curso2.Nombre = "Cálculo";

                var curso3 = new Curso();
                curso3.Nombre = "Estadística";

                context.AddRange(new Curso[] { curso1, curso2, curso3 });
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                var curso1 = context.Cursos.First();
                var estudiante1 = context.Estudiantes.First();

                var estudianteCurso = new EstudianteCurso();
                estudianteCurso.CursoId = curso1.Id;
                estudianteCurso.EstudianteId = estudiante1.Id;

                context.Add(estudianteCurso);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                // Traemos toda la data de EstudiantesCursos
                var allEstudiantesCursos = context.EstudiantesCursos.ToList();

                // Traemos toda la data de EstudiantesCursos incluyendo la información de los estudiantes  
                // y cursos
                var allEstudiantesCursos2 = context.EstudiantesCursos
                                          .Include(x => x.Estudiante).Include(x => x.Curso).ToList();

                var estudianteId = context.Estudiantes.Select(x => x.Id).First();

                // Traemos todos los cursos de un estudiante específico
                var studentCursos = context.EstudiantesCursos.Where(x => x.EstudianteId == estudianteId)
                                    .Include(x => x.Curso).ToList();
            }

            using (var context = new ApplicationDbContext())
            {
                var student = context.Estudiantes.Include(x => x.EstudianteCursos)
                .ThenInclude(c => c.Curso).ToList();
            }
        }
    }
}
