using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public class Md5 : Hash
    {
        public Md5(byte[] bytesToBeHashed, Stream streamToBeHashed)
            : base(bytesToBeHashed, streamToBeHashed)
        {
        }

        protected override HashAlgorithm GetHashAlgorithm()
        {
            return _key == null ? MD5.Create() : (HashAlgorithm)new HMACMD5(_key);
        }
    }
}
