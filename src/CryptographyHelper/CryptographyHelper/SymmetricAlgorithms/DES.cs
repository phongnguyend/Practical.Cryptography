using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class DES : SymmetricBase
    {
        public static DES Use(byte[] data, byte[] key)
        {
            return new DES(data, key);
        }

        private DES(byte[] data, byte[] key)
        {
            _data = data;
            _key = key;
        }

        protected override SymmetricAlgorithm GetSymmetricAlgorithm()
        {
            return new DESCryptoServiceProvider();
        }
    }
}
