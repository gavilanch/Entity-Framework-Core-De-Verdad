using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreQueriesEspaciales
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public Point Ubicacion { get; set; }
    }
}
