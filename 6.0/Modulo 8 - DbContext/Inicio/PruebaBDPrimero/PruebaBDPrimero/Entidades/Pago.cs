using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Pago
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public int TipoPago { get; set; }
        public string CorreoElectronico { get; set; }
        public string Ultimos4Digitos { get; set; }
    }
}
