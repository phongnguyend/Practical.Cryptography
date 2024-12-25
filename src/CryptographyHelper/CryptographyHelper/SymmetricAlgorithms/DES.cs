using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.SymmetricAlgorithms;

public class DES : SymmetricCrypto
{
    public static DES Use(byte[] data, byte[] key)
    {
        return new DES
        {
            _bytes = data,
            _key = key,
        };
    }

    public static DES Use(Stream data, byte[] key)
    {
        return new DES
        {
            _stream = data,
            _key = key,
        };
    }

    private DES()
    {
    }

    protected override SymmetricAlgorithm GetSymmetricAlgorithm()
    {
        return System.Security.Cryptography.DES.Create();
    }
}
