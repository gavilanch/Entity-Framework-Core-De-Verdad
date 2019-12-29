using System;
using System.Linq;

namespace FuncionesEscalares
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantesConCursosActivos = context
                    .Estudiantes
                    .Where(x => ApplicationDbContext.Quantity_Of_Active_Courses(x.Id) > 0)
                    .ToList();
            }
        }
    }
}
