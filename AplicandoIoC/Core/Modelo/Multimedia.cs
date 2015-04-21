using System;

namespace Core.Modelo
{
    public class Multimedia
    {
        public string Identificador { get; set; }

        public byte[] Contenido { get; set; }

        public Multimedia()
        {
            Identificador = Guid.NewGuid().ToString();
        }
    }
}
