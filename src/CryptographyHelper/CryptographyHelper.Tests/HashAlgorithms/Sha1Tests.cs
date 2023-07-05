using CryptographyHelper.HashAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.HashAlgorithms
{
    public class Sha1Tests
    {
        [Fact]
        public void HashString()
        {
            // Arrange
            const string originalMessage = "Original Message to hash";

            // Act
            var hashed = originalMessage.UseSha1().ComputeHash().ToHexString();

            // Assert
            Assert.Equal("3882994BFCD293B6070D78A9DB0690E3BD18364F", hashed);
        }

        [Fact]
        public void HashBytes()
        {
            // Arrange
            byte[] originalMessage = "Original Message to hash".GetBytes();

            // Act
            var hashed = originalMessage.UseSha1().ComputeHash().ToHexString();

            // Assert
            Assert.Equal("3882994BFCD293B6070D78A9DB0690E3BD18364F", hashed);
        }

        [Fact]
        public void HashStringWithKey()
        {
            // Arrange
            const string originalMessage = "Original Message to hash";
            var key = "myscretekey".GetBytes();

            // Act
            var hashed = originalMessage.UseSha1().WithKey(key).ComputeHash().ToHexString();

            // Assert
            Assert.Equal("75E1EF7CF7645DA619BF6A2594B64843DE6690BD", hashed);
        }

        [Fact]
        public void HashBytesWithKey()
        {
            // Arrange
            byte[] originalMessage = "Original Message to hash".GetBytes();
            var key = "myscretekey".GetBytes();

            // Act
            var hashed = originalMessage.UseSha1().WithKey(key).ComputeHash().ToHexString();

            // Assert
            Assert.Equal("75E1EF7CF7645DA619BF6A2594B64843DE6690BD", hashed);
        }
    }
}
