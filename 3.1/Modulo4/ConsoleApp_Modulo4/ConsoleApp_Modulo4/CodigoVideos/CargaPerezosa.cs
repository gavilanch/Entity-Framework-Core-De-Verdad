using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo4.CodigoVideos
{
    public class CargaPerezosa
    {
        public void Codigo()
        {
            // En la carga perezosa las propiedades de navegación deben ser virtuales
            // Debes configurar el código en ApplicationDbContext, Estudiante y
            // Contacto para que lo siguiente funcione
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.FirstOrDefault();

                // La siguiente linea carga los contactos
                estudiantes.Contactos.ToList();

                // Esta es otra manera de cargar los contactos
                foreach (var contact in estudiantes.Contactos)
                {

                }
            }

            // Problema N+1: Peligro! No programar así!
            using (var context = new ApplicationDbContext())
            {
                // Buscamos una lista de estudiantes
                var estudiantes = context.Estudiantes.ToList();

                // Iteramos la lista de estudiantes
                foreach (var estudiante in estudiantes)
                {
                    // Por cada estudiante, hacemos un query
                    // para traer sus contactos
                    var contactos = estudiante.Contactos.ToList();
                }
            }

            // Evitando el problema N+1
            using (var context = new ApplicationDbContext())
            {
                // Se traen todos los estudiantes y sus contactos
                var estudiantes = context.Estudiantes.Include(x => x.Contactos).ToList();

                foreach (var estudiante in estudiantes)
                {
                    // No se ejecuta un query por cada estudiante
                    var contactos = estudiante.Contactos.ToList();
                }
            }



        }

    }
}
