using System;
using Core.Contratos;
using Core.Modelo;

namespace Core.Servicios
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {
        private readonly ILog _log;
        private readonly IRepositorioCredencial _repositorioCredencial;

        public ServicioAutenticacion(ILog log, IRepositorioCredencial repositorioCredencial)
        {
            _log = log;
            _repositorioCredencial = repositorioCredencial;
        }

        public bool AutenticarUsuario(Credencial credencial)
        {
            _log.RegistrarMensaje(string.Format("Autenticacion usuario: {0} - Fecha: {1}",credencial.Usuario, DateTime.Now));

            try
            {
                _repositorioCredencial.AutenticarUsuario(credencial);

                return true;
            }
            catch (Exception ex)
            {
                _log.RegistrarMensaje(ex.Message);
            }

            return false;
        }
    }
}
