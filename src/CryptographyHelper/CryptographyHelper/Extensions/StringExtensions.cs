using System;
using System.IO;
using System.Text;

namespace CryptographyHelper;

public static class StringExtensions
{
    public static byte[] GetBytes(this string data, Encoding encoding = null)
    {
        return (encoding ?? Encoding.UTF8).GetBytes(data);
    }

    public static byte[] FromBase64String(this string data)
    {
        return Convert.FromBase64String(data);
    }

    public static FileInfo ToFileInfo(this string filePath)
    {
        return new FileInfo(filePath);
    }
}
