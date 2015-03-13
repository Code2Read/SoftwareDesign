using Core.Modelo;

namespace Core.Repositorios
{
public interface IRepositorioConsultaUsuario
{
    Usuario ObtenerPorNombre(string nombreUsuario);
    Usuario ObtenerPorId(string id);
}
}