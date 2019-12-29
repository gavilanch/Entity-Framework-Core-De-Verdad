using ConsoleApp_Modulo7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo7
{
    public interface IServicioValidacionesDeTransferencias
    {
        string RealizarValidaciones(Cuenta origen, Cuenta destino, decimal montoATransferir);
    }

}
