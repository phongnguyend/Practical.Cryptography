using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public class HMAC
    {
        private byte[] _toBeHashed;
        private byte[] _key;
        private Algorithm _algorithm;

        public HMAC(byte[] toBeHashed, byte[] key, Algorithm algorithm)
        {
            _toBeHashed = toBeHashed;
            _key = key;
            _algorithm = algorithm;
        }

        private HashAlgorithm GetHashAlgorithm()
        {
            switch (_algorithm)
            {
                case Algorithm.MD5:
                    return new HMACMD5(_key);
                case Algorithm.SHA1:
                    return new HMACSHA1(_key);
                case Algorithm.SHA256:
                    return new HMACSHA256(_key);
                case Algorithm.SHA384:
                    return new HMACSHA384(_key);
                case Algorithm.SHA512:
                    return new HMACSHA512(_key);
            }
            return null;
        }

        public byte[] HashedBytes
        {
            get
            {
                using (var hashAlgorithm = GetHashAlgorithm())
                {
                    return hashAlgorithm.ComputeHash(_toBeHashed);
                }
            }
        }

        public string HashedString
        {
            get
            {
                return HashedBytes.ToHashedString();
            }
        }
    }
}
