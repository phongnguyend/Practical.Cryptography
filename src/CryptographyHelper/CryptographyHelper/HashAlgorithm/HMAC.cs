using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithm
{
    public class HMAC
    {
        private byte[] _toBeHashed;
        private byte[] _key;

        public HMAC(byte[] toBeHashed, byte[] key)
        {
            _toBeHashed = toBeHashed;
            _key = key;
        }

        public byte[] Sha1
        {
            get
            {
                using (var hmac = new HMACSHA1(_key))
                {
                    return hmac.ComputeHash(_toBeHashed);
                }
            }
        }

        public byte[] Sha256
        {
            get
            {
                using (var hmac = new HMACSHA256(_key))
                {
                    return hmac.ComputeHash(_toBeHashed);
                }
            }
        }

        public byte[] Sha512
        {
            get
            {
                using (var hmac = new HMACSHA512(_key))
                {
                    return hmac.ComputeHash(_toBeHashed);
                }
            }
        }

        public byte[] Md5
        {
            get
            {
                using (var hmac = new HMACMD5(_key))
                {
                    return hmac.ComputeHash(_toBeHashed);
                }
            }
        }
    }
}
