using System;
using Core.Contratos;
using Core.Modelo;

namespace Core.Servicios
{
    public class ServicioGestorMultimedia : IServicioGestorMultimedia
    {

        private readonly ILog _log;
        private readonly IRepositorioMultimedia _repositorioMultimedia;

        public ServicioGestorMultimedia(ILog log, IRepositorioMultimedia repositorioMultimedia)
        {
            _log = log;
            _repositorioMultimedia = repositorioMultimedia;
        }

        public void Almacenar(Multimedia multimedia)
        {
            _log.RegistrarMensaje(string.Format("Almacenar archivo: {0} - Fecha: {1}", multimedia.Identificador, DateTime.Now));

            _repositorioMultimedia.Almacenar(multimedia);
        }

        public Multimedia RecuperarPorIdentificador(string identificador)
        {
            _log.RegistrarMensaje(string.Format("Recuperar archivo: {0} - Fecha: {1}", identificador, DateTime.Now));

            return _repositorioMultimedia.RecuperarPorIdentificador(identificador);
        }
    }
}
