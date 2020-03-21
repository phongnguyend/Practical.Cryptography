using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public static class ByteExtensions
    {
        public static Hash UseMd5(this byte[] data, byte[] key = null)
        {
            return new Hash(data, null, key == null ? MD5.Create() : (HashAlgorithm)new HMACMD5(key));
        }

        public static Hash UseSha1(this byte[] data, byte[] key = null)
        {
            return new Hash(data, null, key == null ? SHA1.Create() : (HashAlgorithm)new HMACSHA1(key));
        }

        public static Hash UseSha256(this byte[] data, byte[] key = null)
        {
            return new Hash(data, null, key == null ? SHA256.Create() : (HashAlgorithm)new HMACSHA256(key));
        }

        public static Hash UseSha384(this byte[] data, byte[] key = null)
        {
            return new Hash(data, null, key == null ? SHA384.Create() : (HashAlgorithm)new HMACSHA384(key));
        }

        public static Hash UseSha512(this byte[] data, byte[] key = null)
        {
            return new Hash(data, null, key == null ? SHA512.Create() : (HashAlgorithm)new HMACSHA512(key));
        }

        public static PBKDF2 UsePBKDF2(this byte[] password, byte[] salt, int iterations)
        {
            return new PBKDF2(password, salt, iterations);
        }
    }
}
