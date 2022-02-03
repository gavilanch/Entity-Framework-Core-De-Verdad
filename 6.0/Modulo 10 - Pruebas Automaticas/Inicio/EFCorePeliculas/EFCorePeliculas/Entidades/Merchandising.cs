namespace EFCorePeliculas.Entidades
{
    public class Merchandising: Producto
    {
        public bool DisponibleEnInventario { get; set; }
        public double Peso { get; set; }
        public double Volumen { get; set; }
        public bool EsRopa { get; set; }
        public bool EsColeccionable { get; set; }
    }
}
