using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public class Hash
    {
        private byte[] _toBeHashed;
        private Stream _streamToBeHashed;
        private Algorithm _algorithm;

        public Hash(byte[] toBeHashed, Algorithm algorithm)
        {
            _toBeHashed = toBeHashed;
            _algorithm = algorithm;
        }

        public Hash(Stream streamToBeHashed, Algorithm algorithm)
        {
            _streamToBeHashed = streamToBeHashed;
            _algorithm = algorithm;
        }

        private HashAlgorithm GetHashAlgorithm()
        {
            switch (_algorithm)
            {
                case Algorithm.MD5:
                    return MD5.Create();
                case Algorithm.SHA1:
                    return SHA1.Create();
                case Algorithm.SHA256:
                    return SHA256.Create();
                case Algorithm.SHA384:
                    return SHA384.Create();
                case Algorithm.SHA512:
                    return SHA512.Create();
            }
            return null;
        }

        public byte[] HashedBytes
        {
            get
            {
                using (var hashAlgorithm = GetHashAlgorithm())
                {
                    if (_streamToBeHashed != null)
                    {
                        return hashAlgorithm.ComputeHash(_streamToBeHashed);
                    }

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
