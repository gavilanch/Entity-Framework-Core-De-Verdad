using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_Modulo7.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }

}
