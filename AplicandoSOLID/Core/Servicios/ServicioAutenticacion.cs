using System;
using Core.Modelo;
using Core.Repositorios;

namespace Core.Servicios
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {

        private readonly IRepositorioConsultaUsuario _repositorioConsultaUsuario;
        private readonly ICriptografia _criptografia;

        public ServicioAutenticacion(IRepositorioConsultaUsuario repositorioConsultaUsuario, 
            ICriptografia criptografia)
        {
            _repositorioConsultaUsuario = repositorioConsultaUsuario;
            _criptografia = criptografia;
        }

const int DiasMaximoCambioContrasena = 15;

public ResultadoAutenticacion AutenticarUsuario(Credencial credencial)
{
    Usuario usuario = 
        _repositorioConsultaUsuario.ObtenerPorNombre(credencial.Usuario);

    if (usuario == null)
    {
        return 
            CrearRespuestaAutenicacionInvalida(ErrorAutenticacion.CredencialesIncorrectas);
    }

    if (ValidarContrasenaEsInvalida(usuario, credencial))
    {
        return
            CrearRespuestaAutenicacionInvalida(ErrorAutenticacion.CredencialesIncorrectas);
    }
            
    if (usuario.Bloqueado)
    {
        return
            CrearRespuestaAutenicacionInvalida(ErrorAutenticacion.UsuarioBloqueado);
    }
            
    return ValidarContrasenaSiExpiro(usuario) ? 
        CrearRespuestaAutenicacionInvalida(ErrorAutenticacion.ContrasenaExpiro) : 
        new ResultadoAutenticacion { Autenticado = true, Usuario = usuario };
}

        private ResultadoAutenticacion CrearRespuestaAutenicacionInvalida(ErrorAutenticacion error)
        {
            return new ResultadoAutenticacion
            {
                Autenticado =  false,
                Respuesta = error
            };
        }
        
        private bool ValidarContrasenaEsInvalida(Usuario usuario, Credencial credencial)
        {
            string credencialCifrada = _criptografia.Cifrar(credencial.Contrasena);

            return !credencialCifrada.Equals(usuario.Contrasena);
        }


        public bool ValidarContrasenaSiExpiro(Usuario usuario)
        {
            int nroDiasUltimoCambioContrasena =
                DateTime.Now.Subtract(usuario.FechaUltimoCambioContrasena).Days;
            return nroDiasUltimoCambioContrasena <= DiasMaximoCambioContrasena;
        }

    }
}
