using System;
using Core.Modelo;

namespace Core.Servicios
{
    public class ServicioAutenticacionDecoradorLog : IServicioAutenticacion
    {
        private readonly IServicioAutenticacion _servicioAutenticacion;
        private readonly ILog _log;

        public ServicioAutenticacionDecoradorLog(IServicioAutenticacion servicioAutenticacion, ILog log)
        {
            _servicioAutenticacion = servicioAutenticacion;
            _log = log;
        }

        public ResultadoAutenticacion AutenticarUsuario(Credencial credencial)
        {
            RegistrarLogAutenticar(credencial);
            var resultadoAutenticacion = _servicioAutenticacion.AutenticarUsuario(credencial);

            return resultadoAutenticacion;
        }

        private void RegistrarLogAutenticar(Credencial credencial)
        {
            string mensaje =
                string.Format("FechaHora:{0} - Usuario:{1}", DateTime.Now, credencial.Usuario);
            _log.RegistrarMensaje(mensaje);

        }
    }
}
