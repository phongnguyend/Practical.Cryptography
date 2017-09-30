using CryptographyHelper.HashAlgorithm;
using CryptographyHelper.SymmetricAlgorithm;

namespace CryptographyHelper
{
    public static class ExtensionMethods
    {
        public static Hash UseHash(this byte[] data)
        {
            return new Hash(data);
        }

        public static HMAC UseHMAC(this byte[] data, byte[] key)
        {
            return new HMAC(data, key);
        }

        public static AES UseAES(this byte[] data, byte[] key, byte[] iv)
        {
            return new AES(data, key, iv);
        }

        public static DES UseDES(this byte[] data, byte[] key, byte[] iv)
        {
            return new DES(data, key, iv);
        }

        public static TripleDES UseTripleDES(this byte[] data, byte[] key, byte[] iv)
        {
            return new TripleDES(data, key, iv);
        }
    }
}
