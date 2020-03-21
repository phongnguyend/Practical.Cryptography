namespace CryptographyHelper.HashAlgorithms
{
    public static class StringExtensions
    {
        public static Hash UseMd5(this string data, byte[] key = null)
        {
            return data.ToBytes().UseMd5(key);
        }

        public static Hash UseSha1(this string data, byte[] key = null)
        {
            return data.ToBytes().UseSha1(key);
        }

        public static Hash UseSha256(this string data, byte[] key = null)
        {
            return data.ToBytes().UseSha256(key);
        }

        public static Hash UseSha384(this string data, byte[] key = null)
        {
            return data.ToBytes().UseSha384(key);
        }

        public static Hash UseSha512(this string data, byte[] key = null)
        {
            return data.ToBytes().UseSha512(key);
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
