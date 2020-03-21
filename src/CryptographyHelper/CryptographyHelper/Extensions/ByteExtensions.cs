using System;
using System.Text;

namespace CryptographyHelper
{
    public static class ByteExtensions
    {
        public static byte[] Combine(this byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        public static string ToHashedString(this byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        public static string ToBase64String(this byte[] data, Base64FormattingOptions formattingOptions = Base64FormattingOptions.None)
        {
            return data != null ? Convert.ToBase64String(data, formattingOptions) : null;
        }

        public static string GetString(this byte[] data, Encoding encoding = null)
        {
            return (encoding ?? Encoding.UTF8).GetString(data);
        }
    }
}
