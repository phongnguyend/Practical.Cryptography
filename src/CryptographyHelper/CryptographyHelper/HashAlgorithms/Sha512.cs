using System.IO;
using System.Security.Cryptography;

namespace CryptographyHelper.HashAlgorithms
{
    public class Sha512 : Hash
    {
        public Sha512(byte[] bytesToBeHashed, Stream streamToBeHashed)
            : base(bytesToBeHashed, streamToBeHashed)
        {
        }

        protected override HashAlgorithm GetHashAlgorithm()
        {
            return _key == null ? SHA512.Create() : (HashAlgorithm)new HMACSHA512(_key);
        }
    }
}
