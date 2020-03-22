using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class TripleDES : SymmetricCrypto
    {
        public static TripleDES Use(byte[] data, byte[] key)
        {
            return new TripleDES
            {
                _data = data,
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
