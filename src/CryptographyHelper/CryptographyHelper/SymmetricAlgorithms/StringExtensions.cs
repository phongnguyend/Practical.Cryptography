namespace CryptographyHelper.SymmetricAlgorithms;

public static class StringExtensions
{
    public static DES UseDES(this string data, byte[] key)
    {
        return data.GetBytes().UseDES(key);
    }

    public static TripleDES UseTripleDES(this string data, byte[] key)
    {
        return data.GetBytes().UseTripleDES(key);
    }

    public static AES UseAES(this string data, byte[] key)
    {
        return data.GetBytes().UseAES(key);
    }
}
