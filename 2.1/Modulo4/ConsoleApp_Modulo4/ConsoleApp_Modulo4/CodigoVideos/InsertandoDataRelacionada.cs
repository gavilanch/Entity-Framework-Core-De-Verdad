using ConsoleApp_Modulo4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo4.CodigoVideos
{
    public class InsertandoDataRelacionada
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                var studentId = context.Estudiantes.Select(x => x.Id).FirstOrDefault();

                var contacto = new Contacto();
                contacto.Nombre = "Yessica Krystal";
                contacto.Relacion = "Hermano/a";
                contacto.EstudianteId = studentId;

                context.Add(contacto);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                var estudiante = context.Estudiantes.FirstOrDefault();

                var contact = new Contacto();
                contact.Nombre = "Anthony Concepción";
                contact.Relacion = "Padre";

                estudiante.Contactos = new List<Contacto>();
                estudiante.Contactos.Add(contact);
                context.SaveChanges();
            }

        }
    }
}
