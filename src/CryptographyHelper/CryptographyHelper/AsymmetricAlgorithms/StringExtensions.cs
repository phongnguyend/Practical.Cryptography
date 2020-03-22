using System.Security.Cryptography.X509Certificates;

namespace CryptographyHelper.AsymmetricAlgorithms
{
    public static class StringExtensions
    {
        public static RSA UseRSA(this string data, string keyXml)
        {
            return data.GetBytes().UseRSA(keyXml);
        }

        public static RSA UseRSA(this string data, X509Certificate2 cert)
        {
            return data.GetBytes().UseRSA(cert);
        }
    }
}
