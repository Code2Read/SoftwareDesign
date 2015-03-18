using Core.Modelo;

namespace Infraestructura.Notificacion
{
    public class ServicioNotificacioncambioContrasena : ServicioNotificacionBase<NotificacionCambioContrasena>
    {
        protected override string CrearMensajeNotificacion(NotificacionCambioContrasena parametroNotificacion)
        {
            return string.Empty;
        }
    }
}
