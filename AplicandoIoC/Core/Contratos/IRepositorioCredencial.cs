using Core.Modelo;

namespace Core.Contratos
{
    public interface IRepositorioCredencial
    {
        bool AutenticarUsuario(Credencial credencial);
    }
}
