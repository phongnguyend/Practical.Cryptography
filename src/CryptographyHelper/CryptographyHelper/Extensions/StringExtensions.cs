using System.IO;
using System.Text;

namespace CryptographyHelper
{
    public static class StringExtensions
    {
        public static byte[] ToBytes(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static FileInfo ToFileInfo(this string filePath)
        {
            return new FileInfo(filePath);
        }
    }
}
