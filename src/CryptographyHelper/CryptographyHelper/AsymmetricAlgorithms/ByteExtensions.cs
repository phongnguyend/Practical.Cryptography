namespace CryptographyHelper.AsymmetricAlgorithms
{
    public static class ByteExtensions
    {
        public static RSA UseRSA(this byte[] data, string keyXml)
        {
            return RSA.Use(data, keyXml);
        }
    }
}
