using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public class Sha384 : Hash
    {
        public Sha384(byte[] bytesToBeHashed, Stream streamToBeHashed)
            : base(bytesToBeHashed, streamToBeHashed)
        {
        }

        protected override HashAlgorithm GetHashAlgorithm()
        {
            return _key == null ? SHA384.Create() : (HashAlgorithm)new HMACSHA384(_key);
        }
    }
}
