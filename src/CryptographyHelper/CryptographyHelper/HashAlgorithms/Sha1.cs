using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public class Sha1 : Hash
    {
        public Sha1(byte[] bytesToBeHashed, Stream streamToBeHashed)
            : base(bytesToBeHashed, streamToBeHashed)
        {
        }

        protected override HashAlgorithm GetHashAlgorithm()
        {
            return _key == null ? SHA1.Create() : (HashAlgorithm)new HMACSHA1(_key);
        }
    }
}
