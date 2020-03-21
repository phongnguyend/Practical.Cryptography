using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public class Hash
    {
        private readonly byte[] _bytesToBeHashed;
        private readonly Stream _streamToBeHashed;
        private readonly HashAlgorithm _algorithm;

        public Hash(byte[] bytesToBeHashed, Stream streamToBeHashed, HashAlgorithm algorithm)
        {
            _bytesToBeHashed = bytesToBeHashed;
            _streamToBeHashed = streamToBeHashed;
            _algorithm = algorithm;
        }

        public byte[] HashedBytes
        {
            get
            {
                using (_algorithm)
                {
                    return _streamToBeHashed != null
                        ? _algorithm.ComputeHash(_streamToBeHashed)
                        : _algorithm.ComputeHash(_bytesToBeHashed);
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
