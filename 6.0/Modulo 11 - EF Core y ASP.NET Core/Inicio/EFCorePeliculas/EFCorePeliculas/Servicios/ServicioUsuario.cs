namespace EFCorePeliculas.Servicios
{
    public interface IServicioUsuario
    {
        string ObtenerUsuarioId();
    }

    public class ServicioUsuario: IServicioUsuario
    {
        public string ObtenerUsuarioId()
        {
            return "Felipe";
        }
    }
}
