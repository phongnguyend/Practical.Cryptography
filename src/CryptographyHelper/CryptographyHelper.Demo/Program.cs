using System;
using System.Text;

namespace CryptographyHelper.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            UseHash();
            UseHMAC();
            UsePBKDF2();
            UseAES();
            UseDES();
            UseTripleDES();
        }

        private static void UseTripleDES()
        {
            const string original = "Text to encrypt";
            var key = Convert.FromBase64String("e0x8U5MyotKHiY1uxqxurg==");
            var iv = Convert.FromBase64String("Z1kmtPGvz1g=");

            var encrypted = Encoding.UTF8.GetBytes(original).UseTripleDES(key, iv).Encrypt();
            var decrypted = encrypted.UseTripleDES(key, iv).Decrypt();
            
            Console.WriteLine("Triple DES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + Encoding.UTF8.GetString(decrypted));

            Console.ReadLine();
        }

        private static void UseDES()
        {
            const string original = "Text to encrypt";
            var key = Convert.FromBase64String("cmjP+yg9d3Q=");
            var iv = Convert.FromBase64String("bFWtV5H1BDc=");
            
            var encrypted = Encoding.UTF8.GetBytes(original).UseDES(key, iv).Encrypt();
            var decrypted = encrypted.UseDES(key, iv).Decrypt();
            
            Console.WriteLine("DES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + Encoding.UTF8.GetString(decrypted));

            Console.ReadLine();
        }

        private static void UseAES()
        {
            const string original = "Text to encrypt";
            var key = Convert.FromBase64String("MeNFuKVG63Ks7dChmDvA67lSN6eKDE1QVuZT1dGCYlI=");
            var iv = Convert.FromBase64String("bXhlXQwu0R9qMjbCfEo7GA==");

            var encrypted = Encoding.UTF8.GetBytes(original).UseAES(key, iv).Encrypt();
            var decrypted = encrypted.UseAES(key, iv).Decrypt();

            Console.WriteLine("AES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + Encoding.UTF8.GetString(decrypted));

            Console.ReadLine();
        }

        private static void UsePBKDF2()
        {
            const string passwordToHash = "MyVeryComplexPassword";
            var salt = Convert.FromBase64String("65QuFYgSxqIW0d9Y/QKRX9veWK0DOyX0g7+nbr9yux8=");

            var hashedPassword = passwordToHash.UsePBKDF2(salt, 500000).GetBytes(32);

            Console.WriteLine("Password to hash : " + passwordToHash);
            Console.WriteLine("Hashed Password : " + Convert.ToBase64String(hashedPassword));
            Console.ReadLine();
        }

        private static void UseHMAC()
        {
            const string originalMessage1 = "Original Message1 to hash";
            const string originalMessage2 = "Original Message2 to hash";
            var key = Encoding.UTF8.GetBytes("myscretekey");

            Console.WriteLine("Original Message 1 : " + originalMessage1);
            Console.WriteLine("Original Message 2 : " + originalMessage2);
            Console.WriteLine();

            var hmacMd5ByteData1 = Encoding.UTF8.GetBytes(originalMessage1).UseHMAC(key).Md5;
            var hmacMd5ByteData2 = Encoding.UTF8.GetBytes(originalMessage2).UseHMAC(key).Md5;

            var hmacSha1ByteData1 = Encoding.UTF8.GetBytes(originalMessage1).UseHMAC(key).Sha1;
            var hmacSha1ByteData2 = Encoding.UTF8.GetBytes(originalMessage2).UseHMAC(key).Sha1;

            var hmacSha256ByteData1 = Encoding.UTF8.GetBytes(originalMessage1).UseHMAC(key).Sha256;
            var hmacSha256ByteData2 = Encoding.UTF8.GetBytes(originalMessage2).UseHMAC(key).Sha256;

            var hmacSha512ByteData1 = Encoding.UTF8.GetBytes(originalMessage1).UseHMAC(key).Sha512;
            var hmacSha512ByteData2 = Encoding.UTF8.GetBytes(originalMessage2).UseHMAC(key).Sha512;

            Console.WriteLine();
            Console.WriteLine("MD5 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacMd5ByteData1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacMd5ByteData2));

            Console.WriteLine();
            Console.WriteLine("SHA 1 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacSha1ByteData1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacSha1ByteData2));

            Console.WriteLine();
            Console.WriteLine("SHA 256 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacSha256ByteData1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacSha256ByteData2));

            Console.WriteLine();
            Console.WriteLine("SHA 512 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacSha512ByteData1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacSha512ByteData2));
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void UseHash()
        {
            const string originalMessage1 = "Original Message to hash";
            const string originalMessage2 = "Original Message2 to hash";

            Console.WriteLine("Original Message 1 : " + originalMessage1);
            Console.WriteLine("Original Message 2 : " + originalMessage2);
            Console.WriteLine();

            var md5Hashed1 = Encoding.UTF8.GetBytes(originalMessage1).UseHash().Md5;
            var md5Hashed2 = Encoding.UTF8.GetBytes(originalMessage2).UseHash().Md5;

            var sha1Hashed1 = Encoding.UTF8.GetBytes(originalMessage1).UseHash().Sha1;
            var sha1Hashed2 = Encoding.UTF8.GetBytes(originalMessage2).UseHash().Sha1;

            var sha256Hashed1 = Encoding.UTF8.GetBytes(originalMessage1).UseHash().Sha256;
            var sha256Hashed2 = Encoding.UTF8.GetBytes(originalMessage2).UseHash().Sha256;

            var sha512Hashed1 = Encoding.UTF8.GetBytes(originalMessage1).UseHash().Sha512;
            var sha512Hashed2 = Encoding.UTF8.GetBytes(originalMessage2).UseHash().Sha512;

            Console.WriteLine();
            Console.WriteLine("MD5 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(md5Hashed1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(md5Hashed2));
            Console.WriteLine();
            Console.WriteLine("SHA 1 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(sha1Hashed1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(sha1Hashed2));
            Console.WriteLine();

            Console.WriteLine("SHA 256 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(sha256Hashed1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(sha256Hashed2));
            Console.WriteLine();
            Console.WriteLine("SHA 512 Hashes");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(sha512Hashed1));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(sha512Hashed2));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
