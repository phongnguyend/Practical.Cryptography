using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CryptographyHelper.Certificates;

public static class CertificateManager
{
    public static void ExportPfx(X509Certificate2 cert, string fileName, string password)
    {
        byte[] pfxData = cert.Export(X509ContentType.Pfx, password);
        File.WriteAllBytes(fileName, pfxData);
    }

    public static void ExportCert(X509Certificate2 cert, string fileName)
    {
        byte[] certData = cert.Export(X509ContentType.Cert);
        File.WriteAllBytes(fileName, certData);
    }

    public static void ExportPem(X509Certificate2 cert, string fileName)
    {
        var builder = new System.Text.StringBuilder();

        builder.AppendLine("-----BEGIN CERTIFICATE-----");
        builder.AppendLine(Convert.ToBase64String(cert.RawData, Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END CERTIFICATE-----");

        var pem = builder.ToString();

        File.WriteAllText(fileName, pem);
    }

    public static void ExportPemWithPrivateKey(X509Certificate2 cert, string fileName)
    {
        var builder = new System.Text.StringBuilder();

        // Certificate
        builder.AppendLine("-----BEGIN CERTIFICATE-----");
        builder.AppendLine(Convert.ToBase64String(cert.RawData, Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END CERTIFICATE-----");

        // Private key (RSA only)
        RSA rsa = cert.GetRSAPrivateKey();
        var privateKeyBytes = rsa.ExportPkcs8PrivateKey();

        builder.AppendLine("-----BEGIN PRIVATE KEY-----");
        builder.AppendLine(Convert.ToBase64String(privateKeyBytes, Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END PRIVATE KEY-----");

        var pem = builder.ToString();

        File.WriteAllText(fileName, pem);
    }

    public static X509Certificate2 GenerateSelfSignedCertificate(string subjectName)
    {
        using RSA rsa = RSA.Create(2048);
        var request = new CertificateRequest(
            subjectName,
            rsa,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);

        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));

        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, false));

        request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

        // NotBefore: Now -1 day; NotAfter: Now + 365 days
        var cert = request.CreateSelfSigned(
            DateTimeOffset.UtcNow.AddDays(-1),
            DateTimeOffset.UtcNow.AddYears(1));

        return cert;
    }
}
