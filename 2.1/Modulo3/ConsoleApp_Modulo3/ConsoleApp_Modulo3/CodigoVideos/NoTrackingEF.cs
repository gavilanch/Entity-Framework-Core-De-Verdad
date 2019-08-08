using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class NoTrackingEF
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.AsNoTracking().ToList();
            }

            using (var context = new ApplicationDbContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                var students = context.Estudiantes.ToList();
                var course = context.Cursos.FirstOrDefault();
            }

            using (var context = new ApplicationDbContext())
            {
                // No se les dará seguimiento
                var idsEstudiantes = context.Estudiantes.Select(x => x.Id).ToList();
                var datosBasicosDeEstudiantes = context.Estudiantes.Select(x => new { x.Id, x.Nombre }).ToList();
            }


        }
    }
}
