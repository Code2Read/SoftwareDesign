namespace Core.Repositorios
{
    public interface IRepositorioComandoUsuario
    {
        void ActualizarContrasena(string id, string nuevaContraseña);
    }
}
