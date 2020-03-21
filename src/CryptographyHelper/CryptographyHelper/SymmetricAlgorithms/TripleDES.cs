using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class TripleDES : SymmetricBase
    {
        public static TripleDES Use(byte[] data, byte[] key)
        {
            return new TripleDES(data, key);
        }

        private TripleDES(byte[] data, byte[] key)
        {
            _data = data;
            _key = key;
        }

        protected override SymmetricAlgorithm GetSymmetricAlgorithm()
        {
            return new TripleDESCryptoServiceProvider();
        }
    }
}
