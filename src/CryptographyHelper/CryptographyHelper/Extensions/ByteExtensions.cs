using CryptographyHelper.HashAlgorithms;
using CryptographyHelper.SymmetricAlgorithm;
using System;

namespace CryptographyHelper
{
    public static class ByteExtensions
    {
        public static byte[] Combine(this byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        public static string ToHashedString(this byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        public static string ToBase64String(this byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        public static Hash UseHash(this byte[] data, Algorithm algorithm)
        {
            return new Hash(data, algorithm);
        }

        public static PBKDF2 UsePBKDF2(this byte[] password, byte[] salt, int iterations)
        {
            return new PBKDF2(password, salt, iterations);
        }

        public static HMAC UseHMAC(this byte[] data, byte[] key, Algorithm algorithm)
        {
            return new HMAC(data, key, algorithm);
        }

        public static DES UseDES(this byte[] data, byte[] key, byte[] iv)
        {
            return new DES(data, key, iv);
        }

        public static TripleDES UseTripleDES(this byte[] data, byte[] key, byte[] iv)
        {
            return new TripleDES(data, key, iv);
        }

        public static AES UseAES(this byte[] data, byte[] key, byte[] iv)
        {
            return new AES(data, key, iv);
        }
    }
}
