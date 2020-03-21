using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public static class FileInfoExtensions
    {
        public static Hash UseMd5(this FileInfo file)
        {
            return new Hash(null, File.OpenRead(file.FullName), MD5.Create());
        }
    }
}
