using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace SICAFI.ReglasNegocio
{
    /// <summary>
    /// Clase para encriptación y desencriptación de datos
    /// Migrada de VB.NET a C# con .NET 8
    /// </summary>
    public class Criptologia
    {
        #region Contraseñas Hash

        /// <summary>
        /// Convierte una cadena en un array de bytes usando Unicode
        /// </summary>
        /// <param name="cadena">Cadena a convertir</param>
        /// <returns>Array de bytes</returns>
        private static byte[] ConvertirCadenaEnMatrizDeTipoByte(string cadena)
        {
            return new UnicodeEncoding().GetBytes(cadena);
        }

        /// <summary>
        /// Encripta una cadena usando SHA512 y la convierte a Base64
        /// </summary>
        /// <param name="valorAEncriptar">Valor a encriptar</param>
        /// <returns>Cadena encriptada en Base64</returns>
        public string EncriptarHash(string valorAEncriptar)
        {
            byte[] valorToHash = ConvertirCadenaEnMatrizDeTipoByte(valorAEncriptar);
            byte[] valorHash = SHA512.Create().ComputeHash(valorToHash);
            return Convert.ToBase64String(valorHash);
        }

        /// <summary>
        /// Compara un valor sin encriptar con uno encriptado
        /// </summary>
        /// <param name="valorSinEncriptar">Valor sin encriptar</param>
        /// <param name="valorEncriptado">Valor encriptado</param>
        /// <returns>True si coinciden, False en caso contrario</returns>
        public bool Comparar(string valorSinEncriptar, string valorEncriptado)
        {
            return EncriptarHash(valorSinEncriptar) == valorEncriptado;
        }

        #endregion

        #region Encriptar/Desencriptar

        private const string StrClave = "EjemploDeCodigo";

        /// <summary>
        /// Encripta texto usando una clave
        /// </summary>
        /// <param name="cadenaAEncriptar">Cadena a encriptar</param>
        /// <param name="clave">Clave de encriptación</param>
        /// <param name="mantenerMayusculas">Si mantener mayúsculas</param>
        /// <returns>Cadena encriptada</returns>
        public string EncriptarTexto(string cadenaAEncriptar, string clave = StrClave, bool mantenerMayusculas = true)
        {
            if (!mantenerMayusculas)
            {
                clave = clave.ToUpper();
                cadenaAEncriptar = cadenaAEncriptar.ToUpper();
            }

            if (clave.Length > 0)
            {
                StringBuilder cadenaEncriptada = new StringBuilder();
                for (int i = 0; i < cadenaAEncriptar.Length; i++)
                {
                    int c = cadenaAEncriptar[i];
                    c += clave[i % clave.Length];
                    cadenaEncriptada.Append((char)(c & 0xFF));
                }
                return cadenaEncriptada.ToString();
            }
            else
            {
                return cadenaAEncriptar;
            }
        }

        /// <summary>
        /// Desencripta texto usando una clave
        /// </summary>
        /// <param name="cadenaADesencriptar">Cadena a desencriptar</param>
        /// <param name="clave">Clave de desencriptación</param>
        /// <param name="mantenerMayusculas">Si mantener mayúsculas</param>
        /// <returns>Cadena desencriptada</returns>
        public string DesencriptarTexto(string cadenaADesencriptar, string clave = StrClave, bool mantenerMayusculas = true)
        {
            if (!mantenerMayusculas)
            {
                clave = clave.ToUpper();
            }

            if (clave.Length > 0)
            {
                StringBuilder cadenaDesencriptada = new StringBuilder();
                for (int i = 0; i < cadenaADesencriptar.Length; i++)
                {
                    int c = cadenaADesencriptar[i];
                    c -= clave[i % clave.Length];
                    cadenaDesencriptada.Append((char)(c & 0xFF));
                }
                return cadenaDesencriptada.ToString();
            }
            else
            {
                return cadenaADesencriptar;
            }
        }

        #endregion
    }
} 