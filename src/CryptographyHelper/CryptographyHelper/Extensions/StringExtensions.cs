using CryptographyHelper.AsymmetricAlgorithms;
using CryptographyHelper.HashAlgorithms;
using CryptographyHelper.SymmetricAlgorithm;
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

        public static DES UseDES(this string data, byte[] key)
        {
            return data.ToBytes().UseDES(key);
        }

        public static TripleDES UseTripleDES(this string data, byte[] key)
        {
            return data.ToBytes().UseTripleDES(key);
        }

        public static AES UseAES(this string data, byte[] key)
        {
            return data.ToBytes().UseAES(key);
        }

        public static RSA UseRSA(this string data, string publicKeyXml)
        {
            return data.ToBytes().UseRSA( publicKeyXml);
        }
    }
}
