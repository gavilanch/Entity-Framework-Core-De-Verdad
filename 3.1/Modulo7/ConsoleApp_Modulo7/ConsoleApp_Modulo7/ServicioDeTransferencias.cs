using ConsoleApp_Modulo7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo7
{
    public class ServicioDeTransferencias
    {
        private readonly IServicioValidacionesDeTransferencias _servicioValidaciones;

        public ServicioDeTransferencias(IServicioValidacionesDeTransferencias servicioValidaciones)
        {
            _servicioValidaciones = servicioValidaciones;
        }

        public void TransferirEntreCuentas(Cuenta origen, Cuenta destino, decimal montoATransferir)
        {
            var mensajeError = _servicioValidaciones.RealizarValidaciones(origen, destino, montoATransferir);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                throw new ApplicationException(mensajeError);
            }

            origen.Fondos -= montoATransferir;
            destino.Fondos += montoATransferir;
        }
    }

    public class ServicioValidacionesDeTransferencias : IServicioValidacionesDeTransferencias
    {
        public string RealizarValidaciones(Cuenta origen, Cuenta destino, decimal montoATransferir)
        {
            if (montoATransferir > origen.Fondos)
            {
                return "La cuenta origen no tiene fondos suficientes para realizar la operación";
            }

            // ... otras validaciones

            return string.Empty;
        }
    }


}
