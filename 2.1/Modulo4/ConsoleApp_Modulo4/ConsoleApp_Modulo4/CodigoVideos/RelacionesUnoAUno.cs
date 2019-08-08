using ConsoleApp_Modulo4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo4.CodigoVideos
{
    public class RelacionesUnoAUno
    {
        public void Codigo()
        {
            int idEstudiante;

            using (var context = new ApplicationDbContext())
            {
                idEstudiante = context.Estudiantes.Select(x => x.Id).FirstOrDefault();
            }

            using (var context = new ApplicationDbContext())
            {
                var estudianteDetalle = new EstudianteDetalle();
                estudianteDetalle.Cedula = "123-4567890-1";
                estudianteDetalle.EstudianteId = idEstudiante;

                context.EstudianteDetalles.Add(estudianteDetalle);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.Include(x => x.Detalle).ToList();
            }


        }
    }
}
