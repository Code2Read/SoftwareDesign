using Core.Contratos;

namespace Infraestructura
{
    public class LogArchivoTexto : ILog
    {
        private readonly string _ruta;

        public LogArchivoTexto(string ruta)
        {
            _ruta = ruta;
        }

        public void RegistrarMensaje(string mensaje)
        {
        }
    }
}
