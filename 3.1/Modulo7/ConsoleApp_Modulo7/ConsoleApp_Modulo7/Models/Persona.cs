using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo7.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Direccion> Direcciones { get; set; }
    }

}
