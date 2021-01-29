using System.Security.Cryptography.X509Certificates;

namespace CryptographyHelper.Certificates
{
    public class CertificateFile
    {
        public static X509Certificate2 Find(string fileName, string password = null)
        {
            return string.IsNullOrWhiteSpace(password)
                ? new X509Certificate2(fileName)
                : new X509Certificate2(fileName, password);
        }
    }
}
