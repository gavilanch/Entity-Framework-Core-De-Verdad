using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = string.Join(' ',
                value.Split(' ').Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        }

        public DateTime FechaNacimiento { get; set; }
    }
}
