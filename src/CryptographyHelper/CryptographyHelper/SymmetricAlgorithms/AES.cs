using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public class AES: SymmetricBase
    {
        public static byte[] GenerateKey(int size = 128)
        {
            using (var crypto = new AesCryptoServiceProvider())
            {
                crypto.KeySize = size;
                crypto.BlockSize = size;
                crypto.GenerateKey();
                return crypto.Key;
            }
        }

        public static AES Use(byte[] data, byte[] key)
        {
            return new AES(data, key);
        }

        private AES(byte[] data, byte[] key)
        {
            _data = data;
            _key = key;
        }

        protected override SymmetricAlgorithm GetSymmetricAlgorithm()
        {
            return new AesCryptoServiceProvider();
        }
    }
}
