using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithm
{
    public class DES
    {
        private readonly byte[] _data;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public DES(byte[] data, byte[] key, byte[] iv)
        {
            _data = data;
            _key = key;
            _iv = iv;
        }

        public byte[] Encrypt()
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = _key;
                des.IV = _iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(_data, 0, _data.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt()
        {
            using (var des = System.Security.Cryptography.DES.Create())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = _key;
                des.IV = _iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(_data, 0, _data.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }
    }
}
