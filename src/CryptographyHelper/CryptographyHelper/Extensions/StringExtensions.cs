using CryptographyHelper.HashAlgorithms;
using System.IO;
using System.Text;

namespace CryptographyHelper
{
    public static class StringExtensions
    {
        public static byte[] ToBytes(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static Hash UseHash(this string data, Algorithm algorithm)
        {
            return new Hash(data.ToBytes(), algorithm);
        }

        public static PBKDF2 UsePBKDF2(this string password, int saltSize, int iterations)
        {
            return new PBKDF2(password, saltSize, iterations);
        }

        public static PBKDF2 UsePBKDF2(this string password, byte[] salt, int iterations)
        {
            return new PBKDF2(password, salt, iterations);
        }

        public static FileInfo ToFileInfo(this string filePath)
        {
            return new FileInfo(filePath);
        }
    }
}
