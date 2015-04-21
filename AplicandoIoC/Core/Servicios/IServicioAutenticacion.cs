using Core.Modelo;

namespace Core.Servicios
{
    public interface IServicioAutenticacion
    {
        bool AutenticarUsuario(Credencial credencial);
    }
}
