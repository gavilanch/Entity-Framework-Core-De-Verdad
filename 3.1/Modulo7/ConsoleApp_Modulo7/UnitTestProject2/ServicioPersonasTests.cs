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
    public class ServicioPersonasTests
    {
        private ApplicationDbContext ConstruirDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName).Options;

            var dbContext = new ApplicationDbContext(options);
            return dbContext;
        }

        [TestMethod]
        public void ObtieneTodasLasPersonas()
        {
            // Preparar
            var databaseName = Guid.NewGuid().ToString();
            var dbContext = ConstruirDbContext(databaseName);
            var persona = new Persona() { Nombre = "Persona1" };
            var persona2 = new Persona() { Nombre = "Persona2" };
            var persona3 = new Persona() { Nombre = "Persona3" };
            dbContext.AddRange(persona, persona2, persona3);
            dbContext.SaveChanges();

            // Es importante no usar la misma instancia del data context
            // durante la prueba
            var dbContext2 = ConstruirDbContext(databaseName);
            var servicioPersonas = new ServicioPersonas(dbContext2);

            // Probar
            var personas = servicioPersonas.ObtenerTodas();

            // Verificar
            Assert.AreEqual(3, personas.Count);
        }

        [TestMethod]
        public void ObtieneTodasLasPersonasConSusDirecciones()
        {
            var databaseName = Guid.NewGuid().ToString();
            var dbContext = ConstruirDbContext(databaseName);
            var persona = new Persona() { Nombre = "Persona1" };
            var direcciones = new List<Direccion>();
            direcciones.Add(new Direccion());
            direcciones.Add(new Direccion());
            persona.Direcciones = direcciones;
            dbContext.Add(persona);
            dbContext.SaveChanges();

            var dbContext2 = ConstruirDbContext(databaseName);
            var servicioPersonas = new ServicioPersonas(dbContext2);

            var personas = servicioPersonas.ObtenerPersonasConDirecciones();

            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(2, personas[0].Direcciones.Count);
        }

    }

}
