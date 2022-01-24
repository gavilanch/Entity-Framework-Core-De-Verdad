using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Collections.ObjectModel;

namespace EFCorePeliculas.Entidades
{
    public class Cine: Notificacion
    {
        public int Id { get; set; }
        private string _nombre;
        public string Nombre { get => _nombre; set => Set(value, ref _nombre); }
        private Point _ubicacion;
        public Point Ubicacion { get => _ubicacion; set => Set(value, ref _ubicacion); }
        private CineOferta _cineOferta;
        public CineOferta CineOferta { get => _cineOferta; set => Set(value, ref _cineOferta); }
        public ObservableCollection<SalaDeCine> SalasDeCine { get; set; }
        private CineDetalle _cineDetalle;
        public CineDetalle CineDetalle { get => _cineDetalle; set => Set(value, ref _cineDetalle); }
        private Direccion _direccion;
        public Direccion Direccion { get => _direccion; set => Set(value, ref _direccion); }
    }
}
