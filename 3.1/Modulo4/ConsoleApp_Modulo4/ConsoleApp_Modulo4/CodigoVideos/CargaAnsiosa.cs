using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo4.CodigoVideos
{
    public class CargaAnsiosa
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                // Opción 1: Include con expresión lambda
                var estudiantes1 = context.Estudiantes.Include(x => x.Contactos).ToList();

                // Opción 2: Include con string
                var estudiantes2 = context.Estudiantes.Include("Contactos").ToList();

                // Caso hipotético: Cargando dos entidades relacionadas
                //var estudiantes3 = context.Estudiantes
                //    .Include(estudiante => estudiante.Contactos)
                //    .Include(estudiante => estudiante.Direcciones)
                //    .ToList();

                // Caso hipotético: Cargando entidades relacionadas de Contactos
                //var estudiantes4 = context.Estudiantes
                //    .Include(estudiante => estudiante.Contactos)
                //    .ThenInclude(contacto => contacto.Direcciones).ToList();

            }




        }
    }
}
