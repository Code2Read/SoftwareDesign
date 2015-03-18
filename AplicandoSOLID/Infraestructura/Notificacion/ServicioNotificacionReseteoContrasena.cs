using Core.Modelo;

namespace Infraestructura.Notificacion
{
    public class ServicioNotificacionReseteoContrasena : ServicioNotificacionBase<NotificacionReseteoContrasena>
    {
        protected override string CrearMensajeNotificacion(NotificacionReseteoContrasena parametroNotificacion)
        {
            return string.Empty;
        }
    }
}
