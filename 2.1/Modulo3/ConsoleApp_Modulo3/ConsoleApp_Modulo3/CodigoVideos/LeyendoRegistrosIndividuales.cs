using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class LeyendoRegistrosIndividuales
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiante = context.Estudiantes.FirstOrDefault();

                if (estudiante != null)
                {
                    // Procesar el estudiante
                }
            }

        }
    }
}
