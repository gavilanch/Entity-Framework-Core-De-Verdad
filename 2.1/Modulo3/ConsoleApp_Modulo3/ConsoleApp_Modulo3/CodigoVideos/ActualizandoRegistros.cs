using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApp1.Models;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class ActualizandoRegistros
    {
        public void Codigo()
        {
            // Modelo Conectado
            using (var context = new ApplicationDbContext())
            {
                var student = context.Estudiantes.First(x => x.Nombre.StartsWith("Juan"));
                student.Nombre += " Robles";
                context.SaveChanges();
            }

            // Modelo Desconectado: Actualizando todos los campos
            Estudiante madeleine;

            using (var context = new ApplicationDbContext())
            {
                madeleine = context.Estudiantes.First(x => x.Nombre.StartsWith("Madeleine"));
            }

            madeleine.Nombre += " Purcell";

            using (var context = new ApplicationDbContext())
            {
                context.Entry(madeleine).State = EntityState.Modified;
                context.SaveChanges();
            }

            // Modelo Desconectado: Actualización parcial
            Estudiante august;

            using (var context = new ApplicationDbContext())
            {
                august = context.Estudiantes.Select(x => new Estudiante() { Id = x.Id, Nombre = x.Nombre }).First(x => x.Nombre.StartsWith("August"));
            }

            august.Nombre += " Schwarz";

            using (var context = new ApplicationDbContext())
            {
                var entityEntry = context.Attach(august);
                entityEntry.Property(x => x.Nombre).IsModified = true;
                context.SaveChanges();
            }


        }
    }
}
