using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithm
{
    public class AES
    {
        private readonly byte[] _data;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public AES(byte[] data, byte[] key, byte[] iv)
        {
            _data = data;
            _key = key;
            _iv = iv;
        }

        public byte[] Encrypt()
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = _key;
                aes.IV = _iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(_data, 0, _data.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt()
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = _key;
                aes.IV = _iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(_data, 0, _data.Length);
                    cryptoStream.FlushFinalBlock();

                    var decryptBytes = memoryStream.ToArray();

                    return decryptBytes;
                }
            }
        }
    }
}
