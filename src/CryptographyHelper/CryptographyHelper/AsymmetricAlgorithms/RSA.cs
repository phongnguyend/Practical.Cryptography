using System.Security.Cryptography;

namespace CryptographyHelper.AsymmetricAlgorithms
{
    public class RSA
    {
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
                crypto.FromXmlString(_keyXml);
                return crypto.Encrypt(_data, false);
            }
        }

        public byte[] Decrypt()
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString(_keyXml);
                return crypto.Decrypt(_data, false);
            }
        }
    }
}
