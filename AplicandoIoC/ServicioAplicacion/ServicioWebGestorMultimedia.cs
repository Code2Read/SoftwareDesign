using System.ServiceModel;
using Core.Modelo;
using Core.Servicios;

namespace ServicioAplicacion
{
[ServiceContract]
public interface IServicioWebGestorMultimedia
{
    [OperationContract]
    void Almacenar(Multimedia multimedia);

    [OperationContract]
    Multimedia RecuperarPorIdentificador(string identificador);
}

[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
public class ServicioWebGestorMultimedia : IServicioWebGestorMultimedia
{
    private readonly IServicioGestorMultimedia _servicioGestorMultimedia;

    public ServicioWebGestorMultimedia(IServicioGestorMultimedia servicioGestorMultimedia)
    {
        _servicioGestorMultimedia = servicioGestorMultimedia;
    }

    public void Almacenar(Multimedia multimedia)
    {
        _servicioGestorMultimedia.Almacenar(multimedia);
    }

    public Multimedia RecuperarPorIdentificador(string identificador)
    {
        return _servicioGestorMultimedia.RecuperarPorIdentificador(identificador);
    }
}
}