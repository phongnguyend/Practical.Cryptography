using CryptographyHelper.HashAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.HashAlgorithms
{
    public class PBKDF2Tests
    {
        [Fact]
        public void Hash()
        {
            // Arrange
            const string passwordToHash = "MyVeryComplexPassword";
            var salt = "65QuFYgSxqIW0d9Y/QKRX9veWK0DOyX0g7+nbr9yux8=".FromBase64String();

            // Act
            var hashedPassword = passwordToHash.UsePBKDF2(salt, 500000).GetBytes(32).ToBase64String();

            // Assert
            Assert.Equal("c1M3Di0Eu5x/Uno80OLzf7AEdQepN0aPIO4xRnOe1D8=", hashedPassword);
        }
    }
}
