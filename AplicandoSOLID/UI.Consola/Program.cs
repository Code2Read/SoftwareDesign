using Core.Modelo;
using Core.Repositorios;
using Core.Servicios;
using Infraestructura;
using Infraestructura.Cifrado;
using Infraestructura.Log;
using Infraestructura.Notificacion;
using Infraestructura.Repositorio;

namespace UI.Consola
{
    class Program
    {
        private static void Main(string[] args)
        {
            ICriptografia critografia = new CriptografiaTripleDes("");
            //critografia = new CriptografiaAes();

            IRepositorioConsultaUsuario repositorioConsulta = new RepositorioConsultaUsuarioSql();
            //repositorioConsulta = new RepositorioConsultaUsuarioActiveDirectory();

            ILog log = new LogArchivoTexto();
            //log = new LogSql();

            var servicioAutenticacionCore =
                new ServicioAutenticacion(repositorioConsulta, critografia);

            var servicioAutenticacionLog =
                new ServicioAutenticacionDecoradorLog(servicioAutenticacionCore, log);

            servicioAutenticacionLog.AutenticarUsuario(new Credencial());

            IServicioGeneracionContrasena servicioGeneracionContrasena = new ServicioGeneracionContrasenaRng();
            IRepositorioComandoUsuario repositorioComando = new RepositorioComandoUsuarioSql();

            IServicioCambioContrasena servicioCambioContrasena =
                new ServicioCambioContrasena(
                    repositorioConsulta, critografia,
                    servicioGeneracionContrasena, repositorioComando);

            servicioCambioContrasena.Cambiar(string.Empty, string.Empty,
                new ServicioNotificacioncambioContrasena(new NotificacionCambioContrasena()));
            
            servicioCambioContrasena.Resetear(string.Empty,
                new ServicioNotificacionReseteoContrasena(new NotificacionReseteoContrasena()));
        }
    }
}
