using ConsoleApp_Modulo7;
using ConsoleApp_Modulo7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject2
{
    [TestClass]
    public class ServicioPersonasIntegrationTests : TestInitializer
    {
        [TestCleanup]
        public void CleanUpTest()
        {
            using (var dbContext = ObtenerDataContext(false))
            {
                dbContext.Database.ExecuteSqlRaw("delete Personas");
            }
        }

        [TestMethod]
        public void ObtieneTodasLasPersonas()
        {
            // Preparar
            using (var dbContext = ObtenerDataContext(false))
            {
                var persona = new Persona() { Nombre = "Persona1" };
                var persona2 = new Persona() { Nombre = "Persona2" };
                var persona3 = new Persona() { Nombre = "Persona3" };
                dbContext.AddRange(persona, persona2, persona3);
                dbContext.SaveChanges();
            }

            using (var dbContext2 = ObtenerDataContext(false))
            {
                var servicioPersonas = new ServicioPersonas(dbContext2);
                // Probar
                var personas = servicioPersonas.ObtenerTodas();
                // Verificar
                Assert.AreEqual(3, personas.Count);
            }
        }

        [TestMethod]
        public void ObtieneTodasLasPersonasConSusDirecciones()
        {
            // Preparar
            using (var dbContext = ObtenerDataContext(false))
            {
                var persona = new Persona() { Nombre = "Persona1" };
                var direcciones = new List<Direccion>();
                direcciones.Add(new Direccion());
                direcciones.Add(new Direccion());
                persona.Direcciones = direcciones;
                dbContext.Add(persona);
                dbContext.SaveChanges();
            }

            using (var dbContext2 = ObtenerDataContext(false))
            {
                var servicioPersonas = new ServicioPersonas(dbContext2);
                // Probar
                var personas = servicioPersonas.ObtenerPersonasConDirecciones();
                // Verificar
                Assert.AreEqual(1, personas.Count);
                Assert.IsNotNull(personas[0].Direcciones);
                Assert.AreEqual(2, personas[0].Direcciones.Count);
            }
        }
    }

}
