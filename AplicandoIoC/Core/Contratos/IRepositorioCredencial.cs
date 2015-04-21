using Core.Modelo;

namespace Core.Contratos
{
    public interface IRepositorioCredencial
    {
        void AutenticarUsuario(Credencial credencial);
    }
}
