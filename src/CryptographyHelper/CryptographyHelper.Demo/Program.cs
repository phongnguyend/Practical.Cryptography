using CryptographyHelper.HashAlgorithms;
using CryptographyHelper.SymmetricAlgorithms;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyHelper.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateFileChecksum();
            UseHash();
            UseHMAC();
            UsePBKDF2();
            UseAES();
            UseDES();
            UseTripleDES();
        }

        private static void CalculateFileChecksum()
        {
            string file = @"../../../Program.cs";
            string md5 = file.ToFileInfo().UseMd5().HashedString;
        }

        private static void UseTripleDES()
        {
            const string original = "Text to encrypt";
            var key = Convert.FromBase64String("e0x8U5MyotKHiY1uxqxurg==");
            var iv = Convert.FromBase64String("Z1kmtPGvz1g=");

            var encrypted = original
                .UseTripleDES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Encrypt();

            var decrypted = encrypted
                .UseTripleDES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Decrypt();

            Console.WriteLine("Triple DES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + encrypted.ToBase64String());
            Console.WriteLine("Decrypted Text = " + Encoding.UTF8.GetString(decrypted));

            Console.ReadLine();
        }

        private static void UseDES()
        {
            const string original = "Text to encrypt";
            var key = Convert.FromBase64String("cmjP+yg9d3Q=");
            var iv = Convert.FromBase64String("bFWtV5H1BDc=");

            var encrypted = original
                .UseDES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Encrypt();

            var decrypted = encrypted
                .UseDES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Decrypt();

            Console.WriteLine("DES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + encrypted.ToBase64String());
            Console.WriteLine("Decrypted Text = " + Encoding.UTF8.GetString(decrypted));

            Console.ReadLine();
        }

        private static void UseAES()
        {
            const string original = "Text to encrypt";
            var key = Convert.FromBase64String("MeNFuKVG63Ks7dChmDvA67lSN6eKDE1QVuZT1dGCYlI=");
            var iv = Convert.FromBase64String("bXhlXQwu0R9qMjbCfEo7GA==");

            var encrypted = original
                .UseAES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Encrypt();

            var decrypted = encrypted
                .UseAES(key)
                .WithCipher(CipherMode.ECB)
                .WithPadding(PaddingMode.PKCS7)
                .WithIV(iv)
                .Decrypt();

            Console.WriteLine("AES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + encrypted.ToBase64String());
            Console.WriteLine("Decrypted Text = " + Encoding.UTF8.GetString(decrypted));

            Console.ReadLine();
        }

        private static void UsePBKDF2()
        {
            const string passwordToHash = "MyVeryComplexPassword";
            var salt = Convert.FromBase64String("65QuFYgSxqIW0d9Y/QKRX9veWK0DOyX0g7+nbr9yux8=");

            var hashedPassword = passwordToHash.UsePBKDF2(salt, 500000).GetBytes(32);

            Console.WriteLine("Password to hash : " + passwordToHash);
            Console.WriteLine("Hashed Password : " + hashedPassword.ToBase64String());
            Console.ReadLine();
        }

        private static void UseHMAC()
        {
            const string originalMessage1 = "Original Message1 to hash";
            const string originalMessage2 = "Original Message2 to hash";
            var key = "myscretekey".ToBytes();

            Console.WriteLine("Original Message 1 : " + originalMessage1);
            Console.WriteLine("Original Message 2 : " + originalMessage2);
            Console.WriteLine();

            var hmacMd5ByteData1 = originalMessage1.ToBytes().UseMd5(key).HashedBytes;
            var hmacMd5ByteData2 = originalMessage2.ToBytes().UseMd5(key).HashedBytes;

            var hmacSha1ByteData1 = originalMessage1.ToBytes().UseSha1(key).HashedBytes;
            var hmacSha1ByteData2 = originalMessage2.ToBytes().UseSha1(key).HashedBytes;

            var hmacSha256ByteData1 = originalMessage1.ToBytes().UseSha256(key).HashedBytes;
            var hmacSha256ByteData2 = originalMessage2.ToBytes().UseSha256(key).HashedBytes;

            var hmacSha384ByteData1 = originalMessage1.ToBytes().UseSha384(key).HashedBytes;
            var hmacSha384ByteData2 = originalMessage2.ToBytes().UseSha384(key).HashedBytes;

            var hmacSha512ByteData1 = originalMessage1.ToBytes().UseSha512(key).HashedBytes;
            var hmacSha512ByteData2 = originalMessage2.ToBytes().UseSha512(key).HashedBytes;

            Console.WriteLine();
            Console.WriteLine("MD5 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + hmacMd5ByteData1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + hmacMd5ByteData2.ToHashedString());

            Console.WriteLine();
            Console.WriteLine("SHA 1 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + hmacSha1ByteData1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + hmacSha1ByteData2.ToHashedString());

            Console.WriteLine();
            Console.WriteLine("SHA 256 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + hmacSha256ByteData1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + hmacSha256ByteData2.ToHashedString());

            Console.WriteLine();
            Console.WriteLine("SHA 384 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + hmacSha384ByteData1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + hmacSha384ByteData2.ToHashedString());

            Console.WriteLine();
            Console.WriteLine("SHA 512 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + hmacSha512ByteData1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + hmacSha512ByteData2.ToHashedString());
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void UseHash()
        {
            const string originalMessageString1 = "Original Message to hash";
            const string originalMessageString2 = "Original Message2 to hash";

            Console.WriteLine("Original Message 1 : " + originalMessageString1);
            Console.WriteLine("Original Message 2 : " + originalMessageString2);
            Console.WriteLine();

            var originalMessage1 = originalMessageString1.ToBytes();
            var originalMessage2 = originalMessageString2.ToBytes();

            var md5Hashed1 = originalMessage1.UseMd5().HashedBytes;
            var md5Hashed2 = originalMessage2.UseMd5().HashedBytes;

            var sha1Hashed1 = originalMessage1.UseSha1().HashedBytes;
            var sha1Hashed2 = originalMessage2.UseSha1().HashedBytes;

            var sha256Hashed1 = originalMessage1.UseSha256().HashedBytes;
            var sha256Hashed2 = originalMessage2.UseSha256().HashedBytes;

            var sha384Hashed1 = originalMessage1.UseSha384().HashedBytes;
            var sha384Hashed2 = originalMessage2.UseSha384().HashedBytes;

            var sha512Hashed1 = originalMessage1.UseSha512().HashedBytes;
            var sha512Hashed2 = originalMessage2.UseSha512().HashedBytes;

            Console.WriteLine();
            Console.WriteLine("MD5 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + md5Hashed1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + md5Hashed2.ToHashedString());
            Console.WriteLine();
            Console.WriteLine("SHA 1 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + sha1Hashed1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + sha1Hashed2.ToHashedString());
            Console.WriteLine();

            Console.WriteLine("SHA 256 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + sha256Hashed1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + sha256Hashed2.ToHashedString());
            Console.WriteLine();
            Console.WriteLine("SHA 384 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + sha384Hashed1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + sha384Hashed2.ToHashedString());
            Console.WriteLine();
            Console.WriteLine("SHA 512 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + sha512Hashed1.ToHashedString());
            Console.WriteLine("Message 2 hash = " + sha512Hashed2.ToHashedString());
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
