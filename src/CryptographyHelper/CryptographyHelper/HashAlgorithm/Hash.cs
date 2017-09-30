using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithm
{
    public class Hash
    {
        private byte[] _toBeHashed;

        public Hash(byte[] toBeHashed)
        {
            _toBeHashed = toBeHashed;
        }

        public byte[] Sha1
        {
            get
            {
                using (var sha1 = SHA1.Create())
                {
                    return sha1.ComputeHash(_toBeHashed);
                }
            }
        }

        public byte[] Sha256
        {
            get
            {
                using (var sha256 = SHA256.Create())
                {
                    return sha256.ComputeHash(_toBeHashed);
                }
            }
        }

        public byte[] Sha512
        {
            get
            {
                using (var sha512 = SHA512.Create())
                {
                    return sha512.ComputeHash(_toBeHashed);
                }
            }
        }

        public byte[] Md5
        {
            get
            {
                using (var md5 = MD5.Create())
                {
                    return md5.ComputeHash(_toBeHashed);
                }
            }
        }
    }
}
