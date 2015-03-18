namespace Core.Modelo
{
    public class NotificacionReseteoContrasena : INotificacion
    {
        public Usuario Usuario { get; set; }
        public string CorreoPara { get; set; }

        public string CorreoDe { get; set; }

        public string Asunto { get; set; }
    }
}
