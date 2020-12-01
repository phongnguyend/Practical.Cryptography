using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class TripleDES : SymmetricCrypto
    {
        public static TripleDES Use(byte[] data, byte[] key)
        {
            return new TripleDES
            {
                _bytes = data,
                _key = key,
            };
        }

        public static TripleDES Use(Stream data, byte[] key)
        {
            return new TripleDES
            {
                _stream = data,
                _key = key,
            };
        }

        private TripleDES()
        {
        }

        protected override SymmetricAlgorithm GetSymmetricAlgorithm()
        {
            return new TripleDESCryptoServiceProvider();
        }
    }
}
