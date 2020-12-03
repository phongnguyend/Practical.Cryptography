using System.IO;

namespace CryptographyHelper.HashAlgorithms
{
    public static class FileInfoExtensions
    {
        public static Hash UseMd5(this FileInfo file)
        {
            return new Md5(file);
        }

        public static Hash UseSha1(this FileInfo file)
        {
            return new Sha1(file);
        }

        public static Hash UseSha256(this FileInfo file)
        {
            return new Sha256(file);
        }

        public static Hash UseSha384(this FileInfo file)
        {
            return new Sha384(file);
        }

        public static Hash UseSha512(this FileInfo file)
        {
            return new Sha512(file);
        }
    }
}
