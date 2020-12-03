using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public abstract class Hash
    {
        private readonly byte[] _bytesToBeHashed;
        private readonly Stream _streamToBeHashed;
        protected byte[] _key;

        public Hash(byte[] bytesToBeHashed, Stream streamToBeHashed)
        {
            _bytesToBeHashed = bytesToBeHashed;
            _streamToBeHashed = streamToBeHashed;
        }

        public Hash WithKey(byte[] key)
        {
            _key = key;
            return this;
        }

        protected abstract HashAlgorithm GetHashAlgorithm();

        public byte[] ComputeHash()
        {
            using (var algorithm = GetHashAlgorithm())
            {
                return _streamToBeHashed != null
                    ? algorithm.ComputeHash(_streamToBeHashed)
                    : algorithm.ComputeHash(_bytesToBeHashed);
            }
        }

        public string ComputeHashedString()
        {
            return ComputeHash().ToHashedString();
        }
    }
}

