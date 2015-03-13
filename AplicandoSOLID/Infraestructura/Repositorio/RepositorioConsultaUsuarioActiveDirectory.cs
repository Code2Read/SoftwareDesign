using Core.Modelo;
using Core.Repositorios;

namespace Infraestructura.Repositorio
{
    public class RepositorioConsultaUsuarioActiveDirectory : IRepositorioConsultaUsuario
    {
        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            return new Usuario();
        }

        public Usuario ObtenerPorId(string id)
        {
            return new Usuario();
        }
    }
}
