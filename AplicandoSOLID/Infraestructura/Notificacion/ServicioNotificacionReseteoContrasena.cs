using Core.Modelo;

namespace Infraestructura.Notificacion
{
    public class ServicioNotificacionReseteoContrasena : ServicioNotificacionBase<NotificacionReseteoContrasena>
    {
        public ServicioNotificacionReseteoContrasena(INotificacion notificacion) : base(notificacion)
        {
        }

        protected override string CrearMensajeNotificacion(NotificacionReseteoContrasena parametroNotificacion)
        {
            return string.Empty;
        }
    }
}
