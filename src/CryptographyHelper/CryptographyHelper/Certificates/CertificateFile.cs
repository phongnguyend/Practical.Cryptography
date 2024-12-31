using System.Security.Cryptography.X509Certificates;

namespace CryptographyHelper.Certificates;

public class CertificateFile
{
    public static X509Certificate2 Find(string fileName, string password = null, X509KeyStorageFlags? x509KeyStorageFlags = null)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return new X509Certificate2(fileName);
        }

        if (x509KeyStorageFlags.HasValue)
        {
            return new X509Certificate2(fileName, password, x509KeyStorageFlags.Value);
        }

        
        return new X509Certificate2(fileName, password);
    }
}
