using Core.Modelo;

namespace Infraestructura.Notificacion
{
    public class ServicioNotificacioncambioContrasena : ServicioNotificacionBase<NotificacionCambioContrasena>
    {
        public ServicioNotificacioncambioContrasena(INotificacion notificacion) : base(notificacion)
        {
        }

        protected override string CrearMensajeNotificacion(NotificacionCambioContrasena parametroNotificacion)
        {
            return string.Empty;
        }

    }
}
