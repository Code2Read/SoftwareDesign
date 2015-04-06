using System;
using Core.Modelo;
using Core.Repositorios;
using Core.Servicios;
using Infraestructura.Cifrado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class ServicioAutenticacionTest
    {
        [TestMethod]
        public void AutenticarUsuario_UsuarioNoExiste_RetornaCredencialesIncorrectas()
        {
            //Arrange
            var repositorioConsultaUsuario = new Mock<IRepositorioConsultaUsuario>();
            repositorioConsultaUsuario.Setup(x => x.ObtenerPorNombre(It.IsAny<string>())).Returns((Usuario) null);

            var criptografia = new CriptografiaAes();


            //Act
            var servicioAutenticacion = new ServicioAutenticacion(repositorioConsultaUsuario.Object, criptografia);
            var resultado = servicioAutenticacion.AutenticarUsuario(new Credencial {Usuario = string.Empty});

            //Assert
            Assert.IsFalse(resultado.Autenticado);
            Assert.AreEqual(ErrorAutenticacion.CredencialesIncorrectas, resultado.Respuesta);
            Assert.IsNull(resultado.Usuario);
        }

[TestMethod]
public void AutenticarUsuario_ContrasenaInvalida_RetornaCredencialesIncorrectas()
{
    //Arrange
    var repositorioConsultaUsuario = new Mock<IRepositorioConsultaUsuario>();
    repositorioConsultaUsuario.Setup(
        x => x.ObtenerPorNombre(It.IsAny<string>())).Returns(new Usuario
        {
            Contrasena = "123"
        });

    var criptografia = new CriptografiaAes();


    //Act
    var servicioAutenticacion = new ServicioAutenticacion(repositorioConsultaUsuario.Object, criptografia);
    var resultado = servicioAutenticacion.AutenticarUsuario(new Credencial {Contrasena = "1234"});

    //Assert
    Assert.IsFalse(resultado.Autenticado);
    Assert.AreEqual(ErrorAutenticacion.CredencialesIncorrectas, resultado.Respuesta);
    Assert.IsNull(resultado.Usuario);
}
[TestMethod]
public void AutenticarUsuario_UsuarioBLoqueado_RetornaUsuarioBloqueado()
{
    //Arrange
    var repositorioConsultaUsuario = new Mock<IRepositorioConsultaUsuario>();
    repositorioConsultaUsuario.Setup(
        x => x.ObtenerPorNombre(It.IsAny<string>())).Returns(new Usuario
        {
            Contrasena = "123",
            Bloqueado = true
        });

    var criptografia = new CriptografiaAes();
    
    //Act
    var servicioAutenticacion = new ServicioAutenticacion(repositorioConsultaUsuario.Object, criptografia);
    var resultado = servicioAutenticacion.AutenticarUsuario(new Credencial { Contrasena = "123" });

    //Assert
    Assert.IsFalse(resultado.Autenticado);
    Assert.AreEqual(ErrorAutenticacion.UsuarioBloqueado, resultado.Respuesta);
    Assert.IsNull(resultado.Usuario);
}

[TestMethod]
public void AutenticarUsuario_ContrasenaExpiro_RetornaContrasenaExpiro()
{
    //Arrange
    var repositorioConsultaUsuario = new Mock<IRepositorioConsultaUsuario>();
    repositorioConsultaUsuario.Setup(
        x => x.ObtenerPorNombre(It.IsAny<string>())).Returns(new Usuario
        {
            Contrasena = "123",
            Bloqueado = false,
            FechaUltimoCambioContrasena = DateTime.Now.AddDays(-30)
        });

    var criptografia = new CriptografiaAes();

    //Act
    var servicioAutenticacion = new ServicioAutenticacion(repositorioConsultaUsuario.Object, criptografia);
    var resultado = servicioAutenticacion.AutenticarUsuario(new Credencial { Contrasena = "123" });

    //Assert
    Assert.IsFalse(resultado.Autenticado);
    Assert.AreEqual(ErrorAutenticacion.ContrasenaExpiro, resultado.Respuesta);
    Assert.IsNull(resultado.Usuario);
}

[TestMethod]
public void AutenticarUsuario_UsuarioValido_RetornaUsuarioAutenticado()
{
    //Arrange
    var repositorioConsultaUsuario = new Mock<IRepositorioConsultaUsuario>();
    repositorioConsultaUsuario.Setup(
        x => x.ObtenerPorNombre(It.IsAny<string>())).Returns(new Usuario
        {
            Contrasena = "123",
            Bloqueado = false,
            FechaUltimoCambioContrasena = DateTime.Now.AddDays(-5)
        });

    var criptografia = new CriptografiaAes();

    //Act
    var servicioAutenticacion = new ServicioAutenticacion(repositorioConsultaUsuario.Object, criptografia);
    var resultado = servicioAutenticacion.AutenticarUsuario(new Credencial { Contrasena = "123" });

    //Assert
    Assert.IsTrue(resultado.Autenticado);
    Assert.IsNotNull(resultado.Usuario);
}

    }
}
