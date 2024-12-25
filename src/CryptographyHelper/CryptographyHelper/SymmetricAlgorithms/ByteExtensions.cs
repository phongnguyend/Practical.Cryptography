namespace CryptographyHelper.SymmetricAlgorithms;

public static class ByteExtensions
{
    public static DES UseDES(this byte[] data, byte[] key)
    {
        return DES.Use(data, key);
    }

    public static TripleDES UseTripleDES(this byte[] data, byte[] key)
    {
        return TripleDES.Use(data, key);
    }

    public static AES UseAES(this byte[] data, byte[] key)
    {
        return AES.Use(data, key);
    }
}
