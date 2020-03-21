using System.Security.Cryptography;

namespace CryptographyHelper.AsymmetricAlgorithms
{
    public class RSA
    {
        public static string GenerateKey(int size = 1024)
        {
            using (var crypto = new RSACryptoServiceProvider(size))
            {
                return crypto.ToXmlString2(true);
            }
        }

        public static string ExportPublicKey(string keyXml)
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString2(keyXml);
                return crypto.ToXmlString2(false);
            }
        }

        private string _keyXml;
        private byte[] _data;

        public static RSA Use(byte[] data, string keyXml)
        {
            return new RSA(data, keyXml);
        }

        private RSA(byte[] data, string keyXml)
        {
            _data = data;
            _keyXml = keyXml;
        }

        public byte[] Encrypt()
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString2(_keyXml);
                return crypto.Encrypt(_data, false);
            }
        }

        public byte[] Decrypt()
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString2(_keyXml);
                return crypto.Decrypt(_data, false);
            }
        }
    }
}
