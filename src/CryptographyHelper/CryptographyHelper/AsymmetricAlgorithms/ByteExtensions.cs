using System.Security.Cryptography.X509Certificates;

namespace CryptographyHelper.AsymmetricAlgorithms
{
    public static class ByteExtensions
    {
        public static RSACrypto UseRSA(this byte[] data, string keyXml)
        {
            return RSACrypto.Use(data, keyXml);
        }

        public static RSACrypto UseRSA(this byte[] data, X509Certificate2 cert)
        {
            return RSACrypto.Use(data, cert);
        }
    }
}
