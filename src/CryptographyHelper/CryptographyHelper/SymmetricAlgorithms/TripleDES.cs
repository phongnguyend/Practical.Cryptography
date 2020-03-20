using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithm
{
    public class TripleDES
    {
        public static TripleDES Use(byte[] data, byte[] key)
        {
            return new TripleDES(data, key);
        }

        private readonly byte[] _data;
        private readonly byte[] _key;
        CipherMode? _cipherMode;
        PaddingMode? _paddingMode;
        private byte[] _iv;

        private TripleDES(byte[] data, byte[] key)
        {
            _data = data;
            _key = key;
        }

        public TripleDES WithCipher(CipherMode cipherMode)
        {
            _cipherMode = cipherMode;
            return this;
        }

        public TripleDES WithPadding(PaddingMode paddingMode)
        {
            _paddingMode = paddingMode;
            return this;
        }

        public TripleDES WithIV(byte[] iv)
        {
            _iv = iv;
            return this;
        }

        public byte[] Encrypt()
        {
            using (var crypto = new TripleDESCryptoServiceProvider())
            {
                crypto.Key = _key;
                crypto.Mode = _cipherMode ?? crypto.Mode;
                crypto.Padding = _paddingMode ?? crypto.Padding;
                crypto.IV = _iv ?? crypto.IV;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, crypto.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(_data, 0, _data.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt()
        {
            using (var crypto = new TripleDESCryptoServiceProvider())
            {
                crypto.Key = _key;
                crypto.Mode = _cipherMode ?? crypto.Mode;
                crypto.Padding = _paddingMode ?? crypto.Padding;
                crypto.IV = _iv ?? crypto.IV;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, crypto.CreateDecryptor(),
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
