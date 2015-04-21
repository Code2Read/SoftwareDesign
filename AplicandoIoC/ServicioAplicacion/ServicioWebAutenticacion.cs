using System.ServiceModel;
using Core.Modelo;
using Core.Servicios;

namespace ServicioAplicacion
{
    [ServiceContract]
    public interface IServicioWebAutenticacion
    {
        [OperationContract]
        void Autenticar(Credencial credencial);
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServicioWebAutenticacion : IServicioWebAutenticacion
    {
        private readonly IServicioAutenticacion _servicioAutenticacion;

        public ServicioWebAutenticacion(IServicioAutenticacion servicioAutenticacion)
        {
            _servicioAutenticacion = servicioAutenticacion;
        }

        public void Autenticar(Credencial credencial)
        {
            _servicioAutenticacion.AutenticarUsuario(credencial);
        }
    }
}