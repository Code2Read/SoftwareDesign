using Core.Modelo;

namespace Core.Servicios
{
    public interface IServicioCambioContrasena
    {
        ResultadoCambioContrasena Cambiar(string idUsuario, string nuevaContrasena, IServicioNotificacion<NotificacionCambioContrasena> servicioNotificacion);

        void Resetear(string idUsuario, IServicioNotificacion<NotificacionReseteoContrasena> servicioNotificacion);
    }
}
