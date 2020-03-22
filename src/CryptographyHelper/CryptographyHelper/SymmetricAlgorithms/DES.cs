using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class DES : SymmetricCrypto
    {
        public static DES Use(byte[] data, byte[] key)
        {
            return new DES
            {
                _data = data,
                _key = key,
            };
        }

        private DES()
        {
        }

        protected override SymmetricAlgorithm GetSymmetricAlgorithm()
        {
            return new DESCryptoServiceProvider();
        }
    }
}
