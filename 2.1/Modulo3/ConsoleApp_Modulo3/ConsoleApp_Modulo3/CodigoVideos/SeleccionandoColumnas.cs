using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApp1.Models;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class SeleccionandoColumnas
    {
        public void Codigo()
        {
            // Select aplicado a una columna
            using (var context = new ApplicationDbContext())
            {
                var nombres = context.Estudiantes.Select(x => x.Nombre).ToList();
            }

            // Select con varias columnas
            using (var context = new ApplicationDbContext())
            {
                // Proyección a un tipo anónimo
                var estudiantesEnTipoAnonimo = context.Estudiantes.Select(x => new { x.Id, x.Nombre }).ToList();

                // Proyección a una clase
                var estudiantesEnClase = context.Estudiantes.Select(x => new Estudiante { Id = x.Id, Nombre = x.Nombre }).ToList();
            }

        }
    }
}
