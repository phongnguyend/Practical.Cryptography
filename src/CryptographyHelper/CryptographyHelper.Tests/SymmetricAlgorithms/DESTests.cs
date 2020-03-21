using System.Security.Cryptography;
using CryptographyHelper.SymmetricAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.SymmetricAlgorithms
{
    public class DESTests
    {
        [Fact]
        public void Encrypt()
        {
            // Arrange
            const string original = "Text to encrypt";
            var key = "cmjP+yg9d3Q=".FromBase64String();
            var iv = "bFWtV5H1BDc=".FromBase64String();

            // Act
            var encrypted = original
                .UseDES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Encrypt();

            // Assert
            Assert.Equal("faa7hXl/f/UVa+/ox02gDQ==", encrypted.ToBase64String());
        }

        [Fact]
        public void Decrypt()
        {
            // Arrange
            var encrypted = "faa7hXl/f/UVa+/ox02gDQ==".FromBase64String();
            var key = "cmjP+yg9d3Q=".FromBase64String();
            var iv = "bFWtV5H1BDc=".FromBase64String();

            // Act
            var decrypted = encrypted
               .UseDES(key)
               .WithCipher(CipherMode.ECB)
               .WithPadding(PaddingMode.PKCS7)
               .WithIV(iv)
               .Decrypt();

            // Assert
            Assert.Equal("Text to encrypt", decrypted.GetString());
        }
    }
}
