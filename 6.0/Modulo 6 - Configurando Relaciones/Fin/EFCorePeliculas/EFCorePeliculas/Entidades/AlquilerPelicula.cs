namespace EFCorePeliculas.Entidades
{
    public class AlquilerPelicula
    {
        public int Id { get; set; }
        public int PeliculaId { get; set; }
        public DateTime FechaFinAlquiler { get; set; }
        public int PagoId { get; set; }
        public Pago Pago { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
