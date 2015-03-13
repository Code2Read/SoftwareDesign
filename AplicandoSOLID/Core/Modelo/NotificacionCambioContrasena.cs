namespace Core.Modelo
{
    public class NotificacionCambioContrasena : INotificacion
    {
        public string CorreoPara { get; set; }
        public string CorreoDe { get; set; }
        public string Asunto { get; set; }
    }
}
