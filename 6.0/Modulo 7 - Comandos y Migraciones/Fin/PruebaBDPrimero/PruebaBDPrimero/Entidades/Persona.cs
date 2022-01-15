using System;
using System.Collections.Generic;

namespace PruebaBDPrimero.Entidades
{
    public partial class Persona
    {
        public Persona()
        {
            MensajeEmisors = new HashSet<Mensaje>();
            MensajeReceptors = new HashSet<Mensaje>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Mensaje> MensajeEmisors { get; set; }
        public virtual ICollection<Mensaje> MensajeReceptors { get; set; }
    }
}
