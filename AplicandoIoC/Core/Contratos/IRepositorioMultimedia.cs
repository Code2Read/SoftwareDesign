using Core.Modelo;

namespace Core.Contratos
{
    public interface IRepositorioMultimedia
    {
        void Almacenar(Multimedia multimedia);

        Multimedia RecuperarPorIdentificador(string identificador);

    }
}