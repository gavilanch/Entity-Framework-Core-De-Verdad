using ConsoleApp_Modulo3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class Transacciones
    {
        public static void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var estudiante1 = new Estudiante();
                    estudiante1.Nombre = "Robert Fatou";
                    context.Add(estudiante1);
                    context.SaveChanges();
                    // El Id tendrá un valor válido
                    Console.WriteLine(estudiante1.Id);
                    // Vamos a revertir la operación realizada
                    transaction.Rollback();
                }
            }

        }
    }
}
