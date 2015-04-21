using Core.Contratos;
using Core.Modelo;

namespace Infraestructura
{
    public class RepositorioMultimediaFileServer : IRepositorioMultimedia
    {
        private readonly string _ruta;

        public RepositorioMultimediaFileServer(string ruta)
        {
            _ruta = ruta;
        }

        public void Almacenar(Multimedia multimedia)
        {
        }

        public Multimedia RecuperarPorIdentificador(string identificador)
        {
            return new Multimedia();
        }
    }
}
