using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class AES : SymmetricCrypto
    {
        public static AES Use(byte[] data, byte[] key)
        {
            return new AES
            {
                _data = data,
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
