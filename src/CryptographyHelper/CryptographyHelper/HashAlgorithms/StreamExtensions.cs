using System.IO;

namespace CryptographyHelper.HashAlgorithms;

public static class StreamExtensions
{
    public static Hash UseMd5(this Stream data)
    {
        return new Md5(null, data);
    }

    public static Hash UseSha1(this Stream data)
    {
        return new Sha1(null, data);
    }

    public static Hash UseSha256(this Stream data)
    {
        return new Sha256(null, data);
    }

    public static Hash UseSha384(this Stream data)
    {
        return new Sha384(null, data);
    }

    public static Hash UseSha512(this Stream data)
    {
        return new Sha512(null, data);
    }
}
