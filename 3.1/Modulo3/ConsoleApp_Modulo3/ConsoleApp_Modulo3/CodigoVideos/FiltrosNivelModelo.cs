using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class FiltrosNivelModelo
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.ToList();
            }

            // Ignorando los filtros a nivel del modelo.
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.IgnoreQueryFilters().ToList();
            }


        }
    }
}
