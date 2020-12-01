using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class AES : SymmetricCrypto
    {
        public static AES Use(byte[] data, byte[] key)
        {
            return new AES
            {
                _bytes = data,
                _key = key,
            };
        }

        public static AES Use(Stream data, byte[] key)
        {
            return new AES
            {
                _stream = data,
                _key = key,
            };
        }

        private AES()
        {
        }

        protected override SymmetricAlgorithm GetSymmetricAlgorithm()
        {
            return new AesCryptoServiceProvider();
        }
    }
}
