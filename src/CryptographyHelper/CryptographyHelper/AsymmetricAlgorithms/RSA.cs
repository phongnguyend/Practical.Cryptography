using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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

        X509Certificate2 _cert;
        private string _keyXml;
        private byte[] _data;

        public static RSA Use(byte[] data, string keyXml)
        {
            return new RSA()
            {
                _data = data,
                _keyXml = keyXml,
            };
        }

        public static RSA Use(byte[] data, X509Certificate2 cert)
        {
            return new RSA()
            {
                _data = data,
                _cert = cert
            };
        }

        private RSA()
        {

        }

        private RSACryptoServiceProvider GetCrypto()
        {
            var crypto = new RSACryptoServiceProvider();
            crypto.FromXmlString2(_keyXml);
            return crypto;
        }

        public byte[] Encrypt()
        {
            using (var crypto = _cert != null ? _cert.GetRSAPublicKey() : GetCrypto())
            {
                return crypto.Encrypt(_data, RSAEncryptionPadding.Pkcs1);
            }
        }

        public byte[] Decrypt()
        {
            using (var crypto = _cert != null ? _cert.GetRSAPrivateKey() : GetCrypto())
            {
                return crypto.Decrypt(_data, RSAEncryptionPadding.Pkcs1);
            }
        }
    }
}
