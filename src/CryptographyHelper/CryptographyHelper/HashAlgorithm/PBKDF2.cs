using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyHelper.HashAlgorithm
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

        public byte[] GetBytes(int leng)
        {
            using (var rfc2898 = _getRfc2898())
            {
                return rfc2898.GetBytes(leng);
            }
        }
    }
}
