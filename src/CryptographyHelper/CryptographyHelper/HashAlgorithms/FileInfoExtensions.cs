using System.IO;

namespace CryptographyHelper.HashAlgorithms
{
    public static class FileInfoExtensions
    {
        public static Hash UseMd5(this FileInfo file)
        {
            return new Md5(null, File.OpenRead(file.FullName));
        }
    }
}
