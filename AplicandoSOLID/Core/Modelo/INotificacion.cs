namespace Core.Modelo
{
    public interface INotificacion
    {
        string CorreoPara { get; set; }
        string CorreoDe { get; set; }
        string Asunto { get; set; }
    }
}
