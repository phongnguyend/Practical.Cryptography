using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithm
{
    public class DES
    {
        public static DES Use(byte[] data, byte[] key)
        {
            return new DES(data, key);
        }

        private readonly byte[] _data;
        private readonly byte[] _key;
        CipherMode? _cipherMode;
        PaddingMode? _paddingMode;
        private byte[] _iv;

        private DES(byte[] data, byte[] key)
        {
            _data = data;
            _key = key;
        }

        public DES WithCipher(CipherMode cipherMode)
        {
            _cipherMode = cipherMode;
            return this;
        }

        public DES WithPadding(PaddingMode paddingMode)
        {
            _paddingMode = paddingMode;
            return this;
        }

        public DES WithIV(byte[] iv)
        {
            _iv = iv;
            return this;
        }

        public byte[] Encrypt()
        {
            using (var crypto = new DESCryptoServiceProvider())
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
            //https://github.com/dotnet/corefx/issues/24033
            using (var crypto = System.Security.Cryptography.DES.Create())
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

                    return memoryStream.ToArray();
                }
            }
        }
    }
}
