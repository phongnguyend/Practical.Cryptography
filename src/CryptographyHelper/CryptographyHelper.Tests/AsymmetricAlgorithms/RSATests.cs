using CryptographyHelper.AsymmetricAlgorithms;
using CryptographyHelper.Certificates;
using CryptographyHelper.HashAlgorithms;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace CryptographyHelper.Tests.AsymmetricAlgorithms
{
    public class RSATests
    {
        [Fact]
        public void ExportPublicKey()
        {
            // Arrange
            var rsaPrivateKey = "<RSAKeyValue><Modulus>ahefVEBt94CwUd8yEjZ+CWXYf4jiQBahnYSxLWxv70/4vy0hHsQoUxkinlcAvTqhuyhrtgvxp6fotIGGq8Tp+GdTl7JASizb4CqRGJOcW2fp+0pzp8YEc7rxBjh3aJexRZh/BT7Ay5L+0EzkNX67GJNV7+MbaFWTfgt1jP+ea9s=</Modulus><Exponent>AQAB</Exponent><P>ptrYlsMKE5o8JdHKqdb8MEkaoGpGEbcNnK1naOLGwpRaK+Wc32UtmS3tNVBL+fRoxUjiJlFwH8OF2EPg9KBRnw==</P><Q>osYgOkMd/Zm9Hp4ZEjmDL6h5O5aWkyiBrnpG0vrUbHbZjNgknoM2bAZ5/8mud2mCa0Ixq3YI7u7L5Xr9iPgURQ==</Q><DP>ECTakfO7FNx2d15OEpLHgdCA8AZ4Uxx4B7HLcJ2Ih6kc9GRaAk9i0xBbhC4Ju9yHCpebsgNtKtWbLKqcqG6elw==</DP><DQ>ZuCMC+bRtLAPXKOVuvQImv2DKgtCPd4TIIB99Oi9i5QOabtOYbUSl3H8d5MzpptT55Cdrf3bJZBd5Ds4tPH+dQ==</DQ><InverseQ>faDRZ4/rsw2Q89/EPonsvtI+nE9X8CMw2TNNP9wiZ63fTFYuLFi/JgiwViOG66PAPwp/8iJXaVAl9ugYnh33ew==</InverseQ><D>Iy9YaRHBJq9oSo7SRVYLMMS1K37TQlv/F4WVWTI4YU7NeWHXNSPrF7wjTg4esaNLVg3Owx5s86RtOcgnSLpSueEAh068/+jaI2q5IpRFzyBZkrv/mDySxqwIQ4UD4SrOwOjLaNQBMT7GHVqFeFYzS8US8C9S/e0s6ouPhYqbwsk=</D></RSAKeyValue>";

            // Act
            var rsaPublicKey = RSACrypto.ExportPublicKey(rsaPrivateKey);

            // Assert
            var expected = "<RSAKeyValue><Modulus>ahefVEBt94CwUd8yEjZ+CWXYf4jiQBahnYSxLWxv70/4vy0hHsQoUxkinlcAvTqhuyhrtgvxp6fotIGGq8Tp+GdTl7JASizb4CqRGJOcW2fp+0pzp8YEc7rxBjh3aJexRZh/BT7Ay5L+0EzkNX67GJNV7+MbaFWTfgt1jP+ea9s=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            Assert.Equal(expected, rsaPublicKey);
        }

        [Fact]
        public void EncryptAndDecrypt()
        {
            // Arrange
            var secret = "supper secret text";
            var rsaPrivateKey = "<RSAKeyValue><Modulus>ahefVEBt94CwUd8yEjZ+CWXYf4jiQBahnYSxLWxv70/4vy0hHsQoUxkinlcAvTqhuyhrtgvxp6fotIGGq8Tp+GdTl7JASizb4CqRGJOcW2fp+0pzp8YEc7rxBjh3aJexRZh/BT7Ay5L+0EzkNX67GJNV7+MbaFWTfgt1jP+ea9s=</Modulus><Exponent>AQAB</Exponent><P>ptrYlsMKE5o8JdHKqdb8MEkaoGpGEbcNnK1naOLGwpRaK+Wc32UtmS3tNVBL+fRoxUjiJlFwH8OF2EPg9KBRnw==</P><Q>osYgOkMd/Zm9Hp4ZEjmDL6h5O5aWkyiBrnpG0vrUbHbZjNgknoM2bAZ5/8mud2mCa0Ixq3YI7u7L5Xr9iPgURQ==</Q><DP>ECTakfO7FNx2d15OEpLHgdCA8AZ4Uxx4B7HLcJ2Ih6kc9GRaAk9i0xBbhC4Ju9yHCpebsgNtKtWbLKqcqG6elw==</DP><DQ>ZuCMC+bRtLAPXKOVuvQImv2DKgtCPd4TIIB99Oi9i5QOabtOYbUSl3H8d5MzpptT55Cdrf3bJZBd5Ds4tPH+dQ==</DQ><InverseQ>faDRZ4/rsw2Q89/EPonsvtI+nE9X8CMw2TNNP9wiZ63fTFYuLFi/JgiwViOG66PAPwp/8iJXaVAl9ugYnh33ew==</InverseQ><D>Iy9YaRHBJq9oSo7SRVYLMMS1K37TQlv/F4WVWTI4YU7NeWHXNSPrF7wjTg4esaNLVg3Owx5s86RtOcgnSLpSueEAh068/+jaI2q5IpRFzyBZkrv/mDySxqwIQ4UD4SrOwOjLaNQBMT7GHVqFeFYzS8US8C9S/e0s6ouPhYqbwsk=</D></RSAKeyValue>";
            var rsaPublicKey = "<RSAKeyValue><Modulus>ahefVEBt94CwUd8yEjZ+CWXYf4jiQBahnYSxLWxv70/4vy0hHsQoUxkinlcAvTqhuyhrtgvxp6fotIGGq8Tp+GdTl7JASizb4CqRGJOcW2fp+0pzp8YEc7rxBjh3aJexRZh/BT7Ay5L+0EzkNX67GJNV7+MbaFWTfgt1jP+ea9s=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            // Act
            var encrypted = secret.UseRSA(rsaPublicKey).Encrypt();
            var decrypted = encrypted.UseRSA(rsaPrivateKey).Decrypt();

            // Assert
            Assert.Equal("supper secret text", decrypted.GetString());
        }

        [Fact]
        public void EncryptAndDecryptUsingCert()
        {
            // Arrange
            var secret = "supper secret text";
            var cert = CertificateFile.Find("AsymmetricAlgorithms/classifiedads.identityserver.pfx", "password1234");

            for (var i = 0; i < 10; i++)
            {
                // Act
                var encrypted = secret.UseRSA(cert).Encrypt();
                var decrypted = encrypted.UseRSA(cert).Decrypt();

                // Assert
                Assert.Equal("supper secret text", decrypted.GetString());
            }
        }

        [Fact]
        public void GenerateKey()
        {
            // Arrange
            var secret = "supper secret text";
            var rsaPrivateKey = RSACrypto.GenerateKey();
            var rsaPublicKey = RSACrypto.ExportPublicKey(rsaPrivateKey);

            // Act
            var encrypted = secret.UseRSA(rsaPublicKey).Encrypt();
            var decrypted = encrypted.UseRSA(rsaPrivateKey).Decrypt();

            // Assert
            Assert.Equal("supper secret text", decrypted.GetString());
        }

        [Fact]
        public void SignAndVerifyHash()
        {
            // Arrange
            var secret = "supper secret text".UseSha256().ComputeHash();
            var rsaPrivateKey = RSACrypto.GenerateKey();
            var rsaPublicKey = RSACrypto.ExportPublicKey(rsaPrivateKey);

            // Act
            var signature = secret.UseRSA(rsaPrivateKey).SignHash(HashAlgorithmName.SHA256);
            var verified = secret.UseRSA(rsaPublicKey).VerifyHash(signature, HashAlgorithmName.SHA256);

            // Assert
            Assert.True(verified);
        }

        [Fact]
        public void SignAndVerifyHashUsingCert()
        {
            // Arrange
            var secret = "supper secret text".UseSha256().ComputeHash();
            var cert = new X509Certificate2("AsymmetricAlgorithms/classifiedads.identityserver.pfx", "password1234");

            // Act
            var signature = secret.UseRSA(cert).SignHash(HashAlgorithmName.SHA256);
            var verified = secret.UseRSA(cert).VerifyHash(signature, HashAlgorithmName.SHA256);

            // Assert
            Assert.True(verified);
        }

        [Fact]
        public void SignAndVerifyData()
        {
            // Arrange
            var secret = "supper secret text";
            var rsaPrivateKey = RSACrypto.GenerateKey();
            var rsaPublicKey = RSACrypto.ExportPublicKey(rsaPrivateKey);

            // Act
            var signature = secret.UseRSA(rsaPrivateKey).SignData(HashAlgorithmName.SHA512);
            var verified = secret.UseRSA(rsaPublicKey).VerifyData(signature, HashAlgorithmName.SHA512);

            // Assert
            Assert.True(verified);
        }

        [Fact]
        public void SignAndVerifyDataUsingCert()
        {
            // Arrange
            var secret = "supper secret text";
            var cert = new X509Certificate2("AsymmetricAlgorithms/classifiedads.identityserver.pfx", "password1234");

            // Act
            var signature = secret.UseRSA(cert).SignData(HashAlgorithmName.SHA512);
            var verified = secret.UseRSA(cert).VerifyData(signature, HashAlgorithmName.SHA512);

            // Assert
            Assert.True(verified);
        }
    }
}
