using System.CodeDom;

namespace Core.Modelo
{
    public class NotificacionCambioContrasena : INotificacion
    {
        public Usuario Usuario { get; set; }


        public string CorreoPara { get; set; }

        public string CorreoDe { get; set; }

        public string Asunto { get; set; }
    }
}
