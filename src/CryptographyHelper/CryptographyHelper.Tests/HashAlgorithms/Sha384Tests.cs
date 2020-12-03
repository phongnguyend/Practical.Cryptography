using CryptographyHelper.HashAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.HashAlgorithms
{
    public class Sha384Tests
    {
        [Fact]
        public void HashString()
        {
            // Arrange
            const string originalMessage = "Original Message to hash";

            // Act
            var hashed = originalMessage.UseSha384().ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("F6CAF4688471120BFF98F0F53D9F5A403C9991F9F196F93713C4D6262A6787F890DFB300807354A199715E1CA4A43EA5", hashed);
        }

        [Fact]
        public void HashBytes()
        {
            // Arrange
            byte[] originalMessage = "Original Message to hash".GetBytes();

            // Act
            var hashed = originalMessage.UseSha384().ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("F6CAF4688471120BFF98F0F53D9F5A403C9991F9F196F93713C4D6262A6787F890DFB300807354A199715E1CA4A43EA5", hashed);
        }

        [Fact]
        public void HashStringWithKey()
        {
            // Arrange
            const string originalMessage = "Original Message to hash";
            var key = "myscretekey".GetBytes();

            // Act
            var hashed = originalMessage.UseSha384().WithKey(key).ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("0803D90E53B514DC34B8EFD4D7076E75C11B164120895697E5EA5C1DE0E12BEAB4FC5C85548D6D12FF8E9FD648121F1E", hashed);
        }

        [Fact]
        public void HashBytesWithKey()
        {
            // Arrange
            byte[] originalMessage = "Original Message to hash".GetBytes();
            var key = "myscretekey".GetBytes();

            // Act
            var hashed = originalMessage.UseSha384().WithKey(key).ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("0803D90E53B514DC34B8EFD4D7076E75C11B164120895697E5EA5C1DE0E12BEAB4FC5C85548D6D12FF8E9FD648121F1E", hashed);
        }
    }
}
