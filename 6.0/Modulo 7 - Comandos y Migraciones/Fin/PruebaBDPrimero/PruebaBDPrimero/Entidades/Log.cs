using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Log
    {
        public Guid Id { get; set; }
        public string Mensaje { get; set; }
        public string Ejemplo { get; set; }
    }
}
