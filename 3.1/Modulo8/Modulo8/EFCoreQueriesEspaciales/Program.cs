using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Linq;

namespace EFCoreQueriesEspaciales
{
    class Program
    {
        static void Main(string[] args)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(-69.938972, 18.481208));

            using (var context = new ApplicationDbContext())
            {
                var restaurantes = context.Restaurantes
                    .OrderBy(x => x.Ubicacion.Distance(miUbicacion))
                    .Where(x => x.Ubicacion.IsWithinDistance(miUbicacion, 2000))
                    .Select(x => new { x.Nombre, x.Ciudad, Distancia = x.Ubicacion.Distance(miUbicacion) })
                    .ToList();

                Console.WriteLine("------------");

                foreach (var restaurante in restaurantes)
                {
                    Console.WriteLine($"{restaurante.Nombre} de {restaurante.Ciudad} ({restaurante.Distancia.ToString("N0")} metros de distancia)");
                }

            }

        }
    }
}
