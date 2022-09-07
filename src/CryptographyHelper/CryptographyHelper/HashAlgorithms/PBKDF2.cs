using System;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    /// <summary>
    /// password-based key derivation functionality
    /// </summary>
    public class PBKDF2
    {
        private Func<Rfc2898DeriveBytes> _getRfc2898;

        public PBKDF2(string password, int saltSize, int iterations)
        {
            _getRfc2898 = () => new Rfc2898DeriveBytes(password, saltSize, iterations);
        }

        public PBKDF2(string password, byte[] salt, int iterations)
        {
            _getRfc2898 = () => new Rfc2898DeriveBytes(password, salt, iterations);
        }

        public PBKDF2(byte[] password, byte[] salt, int iterations)
        {
            _getRfc2898 = () => new Rfc2898DeriveBytes(password, salt, iterations);
        }

        public PBKDF2(byte[] password, byte[] salt, int iterations, HashAlgorithmName hashAlgorithm)
        {
            _getRfc2898 = () => new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
        }

        public byte[] GetBytes(int length)
        {
            using var rfc2898 = _getRfc2898();
            return rfc2898.GetBytes(length);
        }
    }
}
