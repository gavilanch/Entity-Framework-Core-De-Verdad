using ConsoleApp_Modulo3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class TransaccionAmbiente
    {
        public void Codigo()
        {
            using (var scope = new TransactionScope())
            {
                CrearEstudiante();
                CrearCurso();
                // Descomenta la siguiente linea de código si quieres que
                // las operaciones sean persistidas en la base de datos
                //scope.Complete();
            }
        }

        private static void CrearCurso()
        {
            using (var context = new ApplicationDbContext())
            {
                var curso = new Curso();
                curso.Nombre = "Programación I";
                context.Add(curso);
                context.SaveChanges();
            }
        }

        private static void CrearEstudiante()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiante1 = new Estudiante();
                estudiante1.Nombre = "Transaction Scope";
                context.Add(estudiante1);
                context.SaveChanges();
            }
        }
    }
}
