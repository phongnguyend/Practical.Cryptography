using CryptographyHelper.HashAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.HashAlgorithms
{
    public class Sha256Tests
    {
        [Fact]
        public void HashString()
        {
            // Arrange
            const string originalMessage = "Original Message to hash";

            // Act
            var hashed = originalMessage.UseSha256().ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("DC1D33325F502D18D02F21B7F8AA721EF485A92C4E0F6A8D34378025E5DF078E", hashed);
        }

        [Fact]
        public void HashBytes()
        {
            // Arrange
            byte[] originalMessage = "Original Message to hash".GetBytes();

            // Act
            var hashed = originalMessage.UseSha256().ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("DC1D33325F502D18D02F21B7F8AA721EF485A92C4E0F6A8D34378025E5DF078E", hashed);
        }

        [Fact]
        public void HashStringWithKey()
        {
            // Arrange
            const string originalMessage = "Original Message to hash";
            var key = "myscretekey".GetBytes();

            // Act
            var hashed = originalMessage.UseSha256().WithKey(key).ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("91EC99381BAD80B8F96CCB2B9E292E806DB439C298230594650C07CAC1621148", hashed);
        }

        [Fact]
        public void HashBytesWithKey()
        {
            // Arrange
            byte[] originalMessage = "Original Message to hash".GetBytes();
            var key = "myscretekey".GetBytes();

            // Act
            var hashed = originalMessage.UseSha256().WithKey(key).ComputeHash().ToHashedString();

            // Assert
            Assert.Equal("91EC99381BAD80B8F96CCB2B9E292E806DB439C298230594650C07CAC1621148", hashed);
        }
    }
}
