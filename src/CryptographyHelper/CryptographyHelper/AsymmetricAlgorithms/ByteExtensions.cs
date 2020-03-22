using System.Security.Cryptography.X509Certificates;

namespace CryptographyHelper.AsymmetricAlgorithms
{
    public static class ByteExtensions
    {
        public static RSA UseRSA(this byte[] data, string keyXml)
        {
            return RSA.Use(data, keyXml);
        }

        public static RSA UseRSA(this byte[] data, X509Certificate2 cert)
        {
            return RSA.Use(data, cert);
        }
    }
}
