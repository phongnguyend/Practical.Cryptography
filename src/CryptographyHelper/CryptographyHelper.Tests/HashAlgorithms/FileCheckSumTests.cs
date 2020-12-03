using CryptographyHelper.HashAlgorithms;
using Xunit;

namespace CryptographyHelper.Tests.HashAlgorithms
{
    public class FileCheckSumTests
    {
        [Fact]
        public void Md5Tests()
        {
            string file = @"../../../CryptographyHelper.Tests.csproj";
            string md5 = file.ToFileInfo().UseMd5().ComputeHashedString();
        }
    }
}
