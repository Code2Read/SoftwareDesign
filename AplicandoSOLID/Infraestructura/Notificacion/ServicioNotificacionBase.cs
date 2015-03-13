using System.Net.Mail;
using Core.Modelo;
using Core.Servicios;

namespace Infraestructura.Notificacion
{
    public abstract class ServicioNotificacionBase<T> : IServicioNotificacion<T> where T:INotificacion
    {

        private readonly INotificacion _notificacion;

        protected ServicioNotificacionBase(INotificacion notificacion)
        {
            _notificacion = notificacion;
        }

        protected abstract string CrearMensajeNotificacion(T parametroNotificacion);

        public void Enviar(T parametroNotificacion)
        {
            using (var smtpServer = new SmtpClient())
            {
                var mail = new MailMessage { From = new MailAddress(_notificacion.CorreoDe) };

                mail.To.Add(_notificacion.CorreoPara);

                mail.Subject = _notificacion.Asunto;

                mail.Body = CrearMensajeNotificacion(parametroNotificacion);
                mail.IsBodyHtml = true;

                smtpServer.Send(mail);
            }
        }
    }
}
