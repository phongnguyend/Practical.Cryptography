using System.IO;

namespace CryptographyHelper.SymmetricAlgorithms;

public static class StreamExtensions
{
    public static DES UseDES(this Stream data, byte[] key)
    {
        return DES.Use(data, key);
    }

    public static TripleDES UseTripleDES(this Stream data, byte[] key)
    {
        return TripleDES.Use(data, key);
    }

    public static AES UseAES(this Stream data, byte[] key)
    {
        return AES.Use(data, key);
    }
}
