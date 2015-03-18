using System.Net.Mail;
using Core.Modelo;
using Core.Servicios;

namespace Infraestructura.Notificacion
{
    public abstract class ServicioNotificacionBase<T> : IServicioNotificacion<T> where T : INotificacion
    {
        protected abstract string CrearMensajeNotificacion(T parametroNotificacion);

        public void Enviar(T parametroNotificacion)
        {
            using (var smtpServer = new SmtpClient())
            {
                var mail = new MailMessage { From = new MailAddress(parametroNotificacion.CorreoDe) };

                mail.To.Add(parametroNotificacion.CorreoPara);

                mail.Subject = parametroNotificacion.Asunto;

                mail.Body = CrearMensajeNotificacion(parametroNotificacion);
                mail.IsBodyHtml = true;

                smtpServer.Send(mail);
            }
        }
    }
}
