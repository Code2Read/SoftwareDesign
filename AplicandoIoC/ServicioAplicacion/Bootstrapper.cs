using System;
using Core.Contratos;
using Core.Servicios;
using Infraestructura;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;

namespace ServicioAplicacion
{
    public class Bootstrapper
    {
        private static Container _contenedor;

        public static object GetInstance(Type serviceType)
        {
            return _contenedor.GetInstance(serviceType);
        }

        public static T GetInstance<T>() where T : class
        {
            return _contenedor.GetInstance<T>();
        }

        public static void Bootstrap()
        {
            _contenedor = new Container();

            SimpleInjectorServiceHostFactory.SetContainer(_contenedor);
            RegistrarWcfDependencias();

            _contenedor.Verify();
        }

        private static void RegistrarWcfDependencias()
        {
            string rutaLog = string.Empty;
            string rutaFileServer = string.Empty;
            string rutaActiveDirectory = string.Empty;

            _contenedor.RegisterPerWcfOperation(()=>(ILog)new LogArchivoTexto(rutaLog));

            _contenedor.RegisterPerWcfOperation(() =>
                (IServicioAutenticacion)new ServicioAutenticacion(
                    _contenedor.GetInstance<ILog>(),
                    new RepositorioCredencialActiveDirectory(rutaActiveDirectory)), true);
            
            _contenedor.RegisterPerWcfOperation(() =>
                (IServicioGestorMultimedia)new ServicioGestorMultimedia(
                    _contenedor.GetInstance<ILog>(),
                    new RepositorioMultimediaFileServer(rutaFileServer)), true);
        }
    }
}