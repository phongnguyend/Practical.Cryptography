﻿using CryptographyHelper.HashAlgorithm;
using CryptographyHelper.SymmetricAlgorithm;
using System;

namespace CryptographyHelper
{
    public static class ExtensionMethods
    {
        public static Hash UseHash(this byte[] data)
        {
            return new Hash(data);
        }

        public static HMAC UseHMAC(this byte[] data, byte[] key)
        {
            return new HMAC(data, key);
        }

        public static AES UseAES(this byte[] data, byte[] key, byte[] iv)
        {
            return new AES(data, key, iv);
        }

        public static DES UseDES(this byte[] data, byte[] key, byte[] iv)
        {
            return new DES(data, key, iv);
        }

        public static TripleDES UseTripleDES(this byte[] data, byte[] key, byte[] iv)
        {
            return new TripleDES(data, key, iv);
        }

        public static byte[] Combine(this byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }
    }
}