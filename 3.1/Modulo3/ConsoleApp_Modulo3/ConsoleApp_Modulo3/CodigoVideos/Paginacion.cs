using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class Paginacion
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var pagina = 1;
                var muestra = 10;

                var estudiantes = context.Estudiantes
            .Skip((pagina - 1) * muestra).Take(muestra).ToList();
            }

        }
    }
}
