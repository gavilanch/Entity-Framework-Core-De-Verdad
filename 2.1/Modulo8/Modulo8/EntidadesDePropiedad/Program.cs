using EntidadesDePropiedad.Models;
using System;
using System.Linq;

namespace EntidadesDePropiedad
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiante = context.Estudiantes.First();

                var casa = new Direccion();
                casa.City = "Los Mina City";
                casa.Street = "Av. Venezuela";
                estudiante.Casa = casa;

                context.SaveChanges();
            }

        }
    }
}
