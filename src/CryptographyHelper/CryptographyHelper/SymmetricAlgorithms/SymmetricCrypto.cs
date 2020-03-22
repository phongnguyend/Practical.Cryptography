using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms
{
    public abstract class SymmetricCrypto
    {
        public static byte[] GenerateKey(int length = 128)
        {
            using (RNGCryptoServiceProvider randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        protected byte[] _data;
        protected byte[] _key;
        protected CipherMode? _cipherMode;
        protected PaddingMode? _paddingMode;
        protected byte[] _iv;

        public SymmetricCrypto WithCipher(CipherMode cipherMode)
        {
            _cipherMode = cipherMode;
            return this;
        }

        public SymmetricCrypto WithPadding(PaddingMode paddingMode)
        {
            _paddingMode = paddingMode;
            return this;
        }

        public SymmetricCrypto WithIV(byte[] iv)
        {
            _iv = iv;
            return this;
        }

        protected abstract SymmetricAlgorithm GetSymmetricAlgorithm();

        public byte[] Encrypt()
        {
            using (var crypto = GetSymmetricAlgorithm())
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
            using (var crypto = GetSymmetricAlgorithm())
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
