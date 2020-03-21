namespace CryptographyHelper.HashAlgorithms
{
    public static class StringExtensions
    {
        public static Hash UseHash(this string data, Algorithm algorithm)
        {
            return new Hash(data.ToBytes(), algorithm);
        }

        public static PBKDF2 UsePBKDF2(this string password, int saltSize, int iterations)
        {
            return new PBKDF2(password, saltSize, iterations);
        }

        public static PBKDF2 UsePBKDF2(this string password, byte[] salt, int iterations)
        {
            return new PBKDF2(password, salt, iterations);
        }
    }
}
