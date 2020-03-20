using System.Security.Cryptography;

namespace CryptographyHelper.AsymmetricAlgorithms
{
    public class RSA
    {
        private string _publicKeyXml;
        private byte[] _data;

        public static RSA Use(byte[] data, string publicKeyXml)
        {
            return new RSA(data, publicKeyXml);
        }

        private RSA(byte[] data, string publicKeyXml)
        {
            _data = data;
            _publicKeyXml = publicKeyXml;
        }

        public byte[] Encrypt()
        {
            using (var crypto = new RSACryptoServiceProvider())
            {
                crypto.FromXmlString(_publicKeyXml);
                return crypto.Encrypt(_data, false);
            }
        }
    }
}
