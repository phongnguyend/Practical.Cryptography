using System.Security.Cryptography.X509Certificates;

namespace CryptographyHelper.Certificates
{
    public class CertificateOption
    {
        public string Thumbprint { get; set; }

        public string Path { get; set; }

        public string Password { get; set; }

        public X509Certificate2 FindCertificate()
        {
            return !string.IsNullOrWhiteSpace(Thumbprint)
                ? CertificateStore.Find(Thumbprint)
                : CertificateFile.Find(Path, Password);
        }
    }
}
