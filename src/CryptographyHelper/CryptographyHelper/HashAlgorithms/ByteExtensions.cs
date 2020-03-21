namespace CryptographyHelper.HashAlgorithms
{
    public static class ByteExtensions
    {
        public static Hash UseHash(this byte[] data, Algorithm algorithm)
        {
            return new Hash(data, algorithm);
        }

        public static PBKDF2 UsePBKDF2(this byte[] password, byte[] salt, int iterations)
        {
            return new PBKDF2(password, salt, iterations);
        }

        public static HMAC UseHMAC(this byte[] data, byte[] key, Algorithm algorithm)
        {
            return new HMAC(data, key, algorithm);
        }
    }
}
