namespace EFCorePeliculas.Entidades
{
    public class Mensaje
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int EmisorId { get; set; }
        public Persona Emisor { get; set; }
        public int ReceptorId { get; set; }
        public Persona Receptor { get; set; }
    }
}
