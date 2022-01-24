using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EFCorePeliculas.Entidades
{
    public class Notificacion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(T valor, ref T campo, [CallerMemberName] string propiedad = "")
        {
            if (!Equals(valor, campo))
            {
                campo = valor;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}
