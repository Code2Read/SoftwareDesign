using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Core.Servicios;

namespace Infraestructura.Cifrado
{
    public class CriptografiaTripleDes : ICriptografia
    {
        private readonly string _llaveCifrado;

        public CriptografiaTripleDes(string llaveCifrado)
        {
            _llaveCifrado = llaveCifrado;
        }

        public string Cifrar(string textoPlano)
        {
            using (var tDeSalg = new AesCryptoServiceProvider())
            {
                tDeSalg.Key = new ASCIIEncoding().GetBytes(_llaveCifrado.Substring(0, 16));
                tDeSalg.IV = new ASCIIEncoding().GetBytes(_llaveCifrado.Substring(8, 16));

                byte[] encryptedBinary = EncriptarTextoEnMemoria(textoPlano, tDeSalg.Key, tDeSalg.IV);
                return Convert.ToBase64String(encryptedBinary);
            }
        }

        private static byte[] EncriptarTextoEnMemoria(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream())
            {
                using (
                    var cs = new CryptoStream(ms, new AesCryptoServiceProvider().CreateEncryptor(key, iv),
                        CryptoStreamMode.Write))
                {
                    byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }

    }
}
