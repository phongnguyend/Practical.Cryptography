using CryptographyHelper.HashAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.HashAlgorithms;

public class Md5Tests
{
    [Fact]
    public void HashString()
    {
        // Arrange
        const string originalMessage = "Original Message to hash";

        // Act
        var hashed = originalMessage.UseMd5().ComputeHash().ToHexString();

        // Assert
        Assert.Equal("B4DE75BC83002A2705C1CB5BC41727C5", hashed);
    }

    [Fact]
    public void HashBytes()
    {
        // Arrange
        byte[] originalMessage = "Original Message to hash".GetBytes();

        // Act
        var hashed = originalMessage.UseMd5().ComputeHash().ToHexString();

        // Assert
        Assert.Equal("B4DE75BC83002A2705C1CB5BC41727C5", hashed);
    }

    [Fact]
    public void HashStringWithKey()
    {
        // Arrange
        const string originalMessage = "Original Message to hash";
        var key = "myscretekey".GetBytes();

        // Act
        var hashed = originalMessage.UseMd5().WithKey(key).ComputeHash().ToHexString();

        // Assert
        Assert.Equal("0A1820C7393A3FE90F8726E7FB8D303D", hashed);
    }

    [Fact]
    public void HashBytesWithKey()
    {
        // Arrange
        byte[] originalMessage = "Original Message to hash".GetBytes();
        var key = "myscretekey".GetBytes();

        // Act
        var hashed = originalMessage.UseMd5().WithKey(key).ComputeHash().ToHexString();

        // Assert
        Assert.Equal("0A1820C7393A3FE90F8726E7FB8D303D", hashed);
    }
}
