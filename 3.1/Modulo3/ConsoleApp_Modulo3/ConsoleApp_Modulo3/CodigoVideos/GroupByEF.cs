using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class GroupByEF
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var report = context.Estudiantes.IgnoreQueryFilters()
                .GroupBy(x => new { x.EstaBorrado })
                .Select(x => new { x.Key, Count = x.Count() }).ToList();
            }

            // GroupBy con Having
            using (var context = new ApplicationDbContext())
            {
                var report = context.Estudiantes.IgnoreQueryFilters()
                            .GroupBy(x => new { x.FechaNacimiento.Year })
                             .Where(x => x.Count() >= 2)
                             .Select(x => new { x.Key, Count = x.Count() })
                            .ToList();
            }


        }
    }
}
