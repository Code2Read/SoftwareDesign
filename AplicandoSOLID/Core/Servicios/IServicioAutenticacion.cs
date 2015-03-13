using Core.Modelo;

namespace Core.Servicios
{
    public interface IServicioAutenticacion
    {
        ResultadoAutenticacion AutenticarUsuario(Credencial credencial);
    }
}
