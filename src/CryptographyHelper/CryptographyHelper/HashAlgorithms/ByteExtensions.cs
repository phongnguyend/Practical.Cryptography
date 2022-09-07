namespace CryptographyHelper.HashAlgorithms
{
    public static class ByteExtensions
    {
        public static Hash UseMd5(this byte[] data)
        {
            return new Md5(data, null);
        }

        public static Hash UseSha1(this byte[] data)
        {
            return new Sha1(data, null);
        }

        public static Hash UseSha256(this byte[] data)
        {
            return new Sha256(data, null);
        }

        public static Hash UseSha384(this byte[] data)
        {
            return new Sha384(data, null);
        }

        public static Hash UseSha512(this byte[] data)
        {
            return new Sha512(data, null);
        }
    }
}
