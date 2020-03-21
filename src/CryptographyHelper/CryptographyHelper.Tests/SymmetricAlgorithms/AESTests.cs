using System.Security.Cryptography;
using CryptographyHelper.SymmetricAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.SymmetricAlgorithms
{
    public class AESTests
    {
        [Fact]
        public void Encrypt()
        {
            // Arrange
            const string original = "Text to encrypt";
            var key = "MeNFuKVG63Ks7dChmDvA67lSN6eKDE1QVuZT1dGCYlI=".FromBase64String();
            var iv = "bXhlXQwu0R9qMjbCfEo7GA==".FromBase64String();

            // Act
            var encrypted = original
                .UseAES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Encrypt();

            // Assert
            Assert.Equal("NrKAB/j0THWXFjYbl+HSCA==", encrypted.ToBase64String());
        }

        [Fact]
        public void Decrypt()
        {
            // Arrange
            var encrypted = "NrKAB/j0THWXFjYbl+HSCA==".FromBase64String();
            var key = "MeNFuKVG63Ks7dChmDvA67lSN6eKDE1QVuZT1dGCYlI=".FromBase64String();
            var iv = "bXhlXQwu0R9qMjbCfEo7GA==".FromBase64String();

            // Act
            var decrypted = encrypted
               .UseAES(key)
               .WithCipher(CipherMode.ECB)
               .WithPadding(PaddingMode.PKCS7)
               .WithIV(iv)
               .Decrypt();

            // Assert
            Assert.Equal("Text to encrypt", decrypted.GetString());
        }
    }
}
