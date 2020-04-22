using EntidadesDePropiedad.Models;
using Microsoft.EntityFrameworkCore;
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
                var estudiantes = context.Estudiantes.ToList();

                var billingAddresses = context.Estudiantes
                    .AsNoTracking()
                    .Select(x => x.BillingAddress).ToList();

                var student = context.Estudiantes.First();

                var domicilio = new Direccion();
                domicilio.Ciudad = "Los Mina City";
                domicilio.Calle = "Av. Venezuela";
                student.Casa = domicilio;

                var billingAddress = new Direccion();
                billingAddress.Ciudad = "Santo Domingo";
                billingAddress.Calle = "Winston Churchill";
                student.BillingAddress = billingAddress;

                context.SaveChanges();
            }
        }
    }
}
