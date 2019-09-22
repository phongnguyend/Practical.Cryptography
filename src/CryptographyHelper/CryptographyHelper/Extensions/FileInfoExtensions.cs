using CryptographyHelper.HashAlgorithms;
using System.IO;

namespace CryptographyHelper
{
    public static class FileInfoExtensions
    {
        public static Hash UseHash(this FileInfo file, Algorithm algorithm)
        {
            return new Hash(File.OpenRead(file.FullName), algorithm);
        }
    }
}
