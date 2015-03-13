namespace Core.Modelo
{
    public enum ErrorAutenticacion
    {
        CredencialesIncorrectas,
        UsuarioBloqueado,
        ContrasenaExpiro
    }

    public class ResultadoAutenticacion
    {
        public bool Autenticado { get; set; }
        public ErrorAutenticacion Respuesta { get; set; }
        public Usuario Usuario { get; set; }
    }
}
