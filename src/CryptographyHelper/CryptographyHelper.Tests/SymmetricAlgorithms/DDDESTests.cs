using System.Security.Cryptography;
using CryptographyHelper.SymmetricAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.SymmetricAlgorithms
{
    public class DDDESTests
    {
        [Fact]
        public void Encrypt()
        {
            // Arrange
            const string original = "Text to encrypt";
            var key = "e0x8U5MyotKHiY1uxqxurg==".FromBase64String();
            var iv = "Z1kmtPGvz1g=".FromBase64String();

            // Act
            var encrypted = original
                .UseTripleDES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Encrypt();

            // Assert
            Assert.Equal("BMAQOzU6W/qAZBoRMlauWg==", encrypted.ToBase64String());
        }

        [Fact]
        public void Decrypt()
        {
            // Arrange
            var encrypted = "BMAQOzU6W/qAZBoRMlauWg==".FromBase64String();
            var key = "e0x8U5MyotKHiY1uxqxurg==".FromBase64String();
            var iv = "Z1kmtPGvz1g=".FromBase64String();

            // Act
            var decrypted = encrypted
               .UseTripleDES(key)
               .WithCipher(CipherMode.ECB)
               .WithPadding(PaddingMode.PKCS7)
               .WithIV(iv)
               .Decrypt();

            // Assert
            Assert.Equal("Text to encrypt", decrypted.GetString());
        }
    }
}
