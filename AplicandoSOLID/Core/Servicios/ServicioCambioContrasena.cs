using System;
using System.Text.RegularExpressions;
using Core.Modelo;
using Core.Repositorios;

namespace Core.Servicios
{
    public class ServicioCambioContrasena : IServicioCambioContrasena
    {
        //Observaciones:
        //Esta clase no es altamente cohesiva tiene dos grupos El cambio y el reseteo
        //si la sdivido no ocurriria ningun problem.
        //Una cosa es que se agruegen ams ametodos. como notificacion en le futuro
        // otras es que se reemplace a la clase  x otra como el repositorio. imple todos los metodos
        private readonly IRepositorioConsultaUsuario _repositorioConsultaUsuario;
        private readonly ICriptografia _criptografia;
        private readonly IRepositorioComandoUsuario _repositorioComandoUsuario;
        
        public IServicioGeneracionContrasena ServicioGeneracionContrasena { get; set; }

        public ServicioCambioContrasena(
            IRepositorioConsultaUsuario repositorioConsultaUsuario, 
            ICriptografia criptografia, 
            IRepositorioComandoUsuario repositorioComandoUsuario)
        {
            _repositorioConsultaUsuario = repositorioConsultaUsuario;
            _criptografia = criptografia;
            _repositorioComandoUsuario = repositorioComandoUsuario;
        }

        const int LongitudMinimaContrasena = 8;
        const string FormatoExpresionRegularContrasena = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{8,20}$";

        public ResultadoCambioContrasena Cambiar(string idUsuario, string nuevaContrasena,
            IServicioNotificacion<NotificacionCambioContrasena> servicioNotificacion)
        {
            Usuario usuario = BuscarUsuario(idUsuario);

            if (ValidarContrasenaEsRepetida(usuario, nuevaContrasena))
            {
                return
                    CrearRespuestaCambioContrasenaInvalida(ErrorCambioContrasena.ContrasenaRepetida);
            }

            if (ValidarContrasenaTieneLongitudMinima(nuevaContrasena))
            {
                return 
                    CrearRespuestaCambioContrasenaInvalida(ErrorCambioContrasena.LongitudMinimaInvalida);
            }
            
            if (ValidarContrasenaEsCompleja(nuevaContrasena))
            {
                return 
                    CrearRespuestaCambioContrasenaInvalida(ErrorCambioContrasena.ComplejidadIncorrecta);
            }

            ActualizarContrasena(idUsuario, nuevaContrasena);

            servicioNotificacion.Enviar(new NotificacionCambioContrasena{Usuario = usuario});

            return new ResultadoCambioContrasena { ContrasenaActualizada = true };
        }
        
        private void ActualizarContrasena(string idUsuario, string nuevaContrasena)
        {
            string nuevaContrasenaCifrada = _criptografia.Cifrar(nuevaContrasena);

            _repositorioComandoUsuario.ActualizarContrasena(idUsuario, nuevaContrasenaCifrada);
        }

        private Usuario BuscarUsuario(string idUsuario)
        {
            Usuario usuario = _repositorioConsultaUsuario.ObtenerPorId(idUsuario);
            if (usuario == null)
            {
                throw new ApplicationException("El usuario no existe");
            }
            return usuario;
        }


        private bool ValidarContrasenaTieneLongitudMinima(string nuevaContrasena)
        {
            return nuevaContrasena.Length >= LongitudMinimaContrasena;
        }

        private bool ValidarContrasenaEsRepetida(Usuario usuario, string nuevaContrasena)
        {
             string nuevaContrasenaCifrada = _criptografia.Cifrar(nuevaContrasena);

             return nuevaContrasenaCifrada.Equals(usuario.Contrasena);
        }

        private bool ValidarContrasenaEsCompleja(string nuevaContrasena)
        {
            var regex = new Regex(FormatoExpresionRegularContrasena);
            return regex.IsMatch(nuevaContrasena);
        }

        private ResultadoCambioContrasena CrearRespuestaCambioContrasenaInvalida(ErrorCambioContrasena error)
        {
            return new ResultadoCambioContrasena
            {
                ContrasenaActualizada = false,
                Respuesta = error
            };
        }

        public void Resetear(string idUsuario, IServicioNotificacion<NotificacionReseteoContrasena> servicioNotificacion)
        {
            Usuario usuario = BuscarUsuario(idUsuario);

            string nuevaContrasena = ServicioGeneracionContrasena.Generar();
            
            ActualizarContrasena(idUsuario, nuevaContrasena);

            servicioNotificacion.Enviar(new NotificacionReseteoContrasena{Usuario = usuario});
        }
        
    }
}
