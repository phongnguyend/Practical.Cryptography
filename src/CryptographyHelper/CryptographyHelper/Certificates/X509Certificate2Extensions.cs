using CryptographyHelper.AsymmetricAlgorithms;

namespace System.Security.Cryptography.X509Certificates
{
    public static class X509Certificate2Extensions
    {
        public static string GetRSAPublicKeyXml(this X509Certificate2 cert)
        {
            return cert.GetRSAPublicKey().ToXmlString2(false);
        }
    }
}
