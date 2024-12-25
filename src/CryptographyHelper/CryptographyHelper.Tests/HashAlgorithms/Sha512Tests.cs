using CryptographyHelper.HashAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.HashAlgorithms;

public class Sha512Tests
{
    [Fact]
    public void HashString()
    {
        // Arrange
        const string originalMessage = "Original Message to hash";

        // Act
        var md5Hashed = originalMessage.UseSha512().ComputeHash().ToHexString();

        // Assert
        Assert.Equal("4BC7C892C45B94157C58D07F40B52CC2325505A560C7EB30472B43A15717E32307BF1B7A2CAD08446A9EF220F5255A9763FACA8632CFBC35D2C1E3131A250986", md5Hashed);
    }

    [Fact]
    public void HashBytes()
    {
        // Arrange
        byte[] originalMessage = "Original Message to hash".GetBytes();

        // Act
        var md5Hashed = originalMessage.UseSha512().ComputeHash().ToHexString();

        // Assert
        Assert.Equal("4BC7C892C45B94157C58D07F40B52CC2325505A560C7EB30472B43A15717E32307BF1B7A2CAD08446A9EF220F5255A9763FACA8632CFBC35D2C1E3131A250986", md5Hashed);
    }

    [Fact]
    public void HashStringWithKey()
    {
        // Arrange
        const string originalMessage = "Original Message to hash";
        var key = "myscretekey".GetBytes();

        // Act
        var md5Hashed = originalMessage.UseSha512().WithKey(key).ComputeHash().ToHexString();

        // Assert
        Assert.Equal("E6F4B40BA23A614DF9CE20B0CE3C2212BDAE3D003E72306140130F711163CB1A211AAC51D45991132D7996E585C8E21D5F54755B1D810D8A0069E78E7D22763D", md5Hashed);
    }

    [Fact]
    public void HashBytesWithKey()
    {
        // Arrange
        byte[] originalMessage = "Original Message to hash".GetBytes();
        var key = "myscretekey".GetBytes();

        // Act
        var md5Hashed = originalMessage.UseSha512().WithKey(key).ComputeHash().ToHexString();

        // Assert
        Assert.Equal("E6F4B40BA23A614DF9CE20B0CE3C2212BDAE3D003E72306140130F711163CB1A211AAC51D45991132D7996E585C8E21D5F54755B1D810D8A0069E78E7D22763D", md5Hashed);
    }
}
