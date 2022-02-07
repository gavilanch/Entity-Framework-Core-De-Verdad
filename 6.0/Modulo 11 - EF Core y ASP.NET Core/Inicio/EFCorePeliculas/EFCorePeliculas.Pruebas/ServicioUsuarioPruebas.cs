using EFCorePeliculas.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCorePeliculas.Pruebas
{
    [TestClass]
    public class ServicioUsuarioPruebas
    {
        [TestMethod]
        public void ObtenerUsuarioId_NoTraeValorVacioONulo()
        {
            // Preparación
            var servicioUsuario = new ServicioUsuario();

            // Prueba
            var resultado = servicioUsuario.ObtenerUsuarioId();

            // Verificación
            Assert.AreNotEqual("", resultado);
            Assert.IsNotNull(resultado);
        }
    }
}