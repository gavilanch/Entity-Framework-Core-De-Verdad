using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        private string _nombre;
        public string Nombre {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = string.Join(' ',
                        value.Split(' ')
                        .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        
        }
        public string Biografia { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime? FechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
        public string FotoURL { get; set; }
        [NotMapped]
        public int? Edad
        {
            get
            {
                if (!FechaNacimiento.HasValue)
                {
                    return null;
                }

                var fechaNacimiento = FechaNacimiento.Value;

                var edad = DateTime.Today.Year - fechaNacimiento.Year;

                if (new DateTime(DateTime.Today.Year, fechaNacimiento.Month, fechaNacimiento.Day) > DateTime.Today)
                {
                    edad--;
                }

                return edad;

            }
        }
        public Direccion DireccionHogar { get; set; }
        public Direccion BillingAddress { get; set; }
    }
}
