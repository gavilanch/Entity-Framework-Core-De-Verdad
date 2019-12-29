using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class EjecucionDiferida
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                // Forma 1: Funciones en una linea
                var estudiantes1 = context.Estudiantes
                .Where(x => x.FechaNacimiento.Year < 1990)
                .OrderByDescending(x => x.FechaNacimiento).ToList();

                // Forma 2: Funciones en varias lineas
                var query = context.Estudiantes.AsQueryable();
                query = query.Where(x => x.FechaNacimiento.Year < 1990);
                query = query.OrderByDescending(x => x.FechaNacimiento);
                var students2 = query.ToList();
            }

        }
    }
}
