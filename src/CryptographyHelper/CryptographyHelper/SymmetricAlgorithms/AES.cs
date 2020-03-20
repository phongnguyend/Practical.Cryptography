using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithm
{
    public class AES
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

        private readonly byte[] _data;
        private readonly byte[] _key;
        CipherMode? _cipherMode;
        PaddingMode? _paddingMode;
        private byte[] _iv;

        private AES(byte[] data, byte[] key)
        {
            _data = data;
            _key = key;
        }

        public AES WithCipher(CipherMode cipherMode)
        {
            _cipherMode = cipherMode;
            return this;
        }

        public AES WithPadding(PaddingMode paddingMode)
        {
            _paddingMode = paddingMode;
            return this;
        }

        public AES WithIV(byte[] iv)
        {
            _iv = iv;
            return this;
        }

        public byte[] Encrypt()
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Key = _key;
                aes.Mode = _cipherMode ?? aes.Mode;
                aes.Padding = _paddingMode ?? aes.Padding;
                aes.IV = _iv ?? aes.IV;

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
                aes.Key = _key;
                aes.Mode = _cipherMode ?? aes.Mode;
                aes.Padding = _paddingMode ?? aes.Padding;
                aes.IV = _iv ?? aes.IV;

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
