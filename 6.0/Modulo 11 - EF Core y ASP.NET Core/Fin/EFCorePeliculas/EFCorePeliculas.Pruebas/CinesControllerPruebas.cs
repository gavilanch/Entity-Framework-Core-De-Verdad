using EFCorePeliculas.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePeliculas.Pruebas
{
    [TestClass]
    public class CinesControllerPruebas: BasePruebas
    {
        [TestMethod]
        public async Task Get_MandoLatitudYLongitudDeSD_Obtengo2CinesCercanos()
        {
            var latitud = 18.481139;
            var longitud = -69.938950;

            using (var context = LocalDbInicializador.GetDbContextLocalDb())
            {
                var mapper = ConfigurarAutoMapper();
                var controller = new CinesController(context, mapper, 
                        actualizadorObservableCollection: null);
                var respuesta = await controller.Get(latitud, longitud);
                var objectResult = respuesta as ObjectResult;
                var cines = (IEnumerable<object>)objectResult.Value;
                Assert.AreEqual(2, cines.Count());
            }
        }
    }
}
