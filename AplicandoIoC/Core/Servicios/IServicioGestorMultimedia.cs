using Core.Modelo;

namespace Core.Servicios
{
    public interface IServicioGestorMultimedia
    {
        void Almacenar(Multimedia multimedia);

        Multimedia RecuperarPorIdentificador(string identificador);
    }
}
