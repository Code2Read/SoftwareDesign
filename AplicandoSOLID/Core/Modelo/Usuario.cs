using System;

namespace Core.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaUltimoCambioContrasena { get; set; }
        public bool Bloqueado { get; set; }
    }
}
