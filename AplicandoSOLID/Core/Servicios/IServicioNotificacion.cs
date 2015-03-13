using Core.Modelo;

namespace Core.Servicios
{
    public interface IServicioNotificacion<in T> where T: INotificacion
    {
        void Enviar(T parametroNotificacion);
    }
}
