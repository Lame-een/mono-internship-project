using System;
using System.Security.Cryptography;

namespace Lyre.Common
{
    //Implementation based on http://csharptest.net/470/another-example-of-how-to-store-a-salted-password-hash/
    //hopefully secure enough
    public class CryptoProvider
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        private const int _iterations = 10000;  //DO NOT CHANGE IN PRODUCTION
        private const int _saltSize = 32;
        private const int _hashSize = 256;


        public static string GenerateSalt(ref byte[] salt, int size)
        {
            rngCsp.GetBytes(salt = new byte[size]);

            return Convert.ToBase64String(salt);
        }

        public static string GenerateSalt(ref byte[] salt)
        {
            rngCsp.GetBytes(salt = new byte[_saltSize]);

            return Convert.ToBase64String(salt);
        }

        //more secure would be using SecureString
        //due to the server being a less likely attack vector this shouldn't be an issue in
        //the project
        public static string Hash(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations);
            var hash = pbkdf2.GetBytes(_hashSize);

            return Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string saltString, string inputHash)
        {
            byte[] outsideHash = Convert.FromBase64String(inputHash);

            byte[] salt = Convert.FromBase64String(saltString);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations);
            var hash = pbkdf2.GetBytes(_hashSize);

            for (int i = 0; i < _hashSize; i++)
            {
                if (hash[i] != outsideHash[i]) return false;
            }

            return true;
        }

        public static byte[] Encrypt(string plainText, string key)
        {
            byte[] iv = new byte[16];
            byte[] text = Convert.FromBase64String(plainText);
            Aes aes = Aes.Create();
            aes.Key = Convert.FromBase64String(key);
            aes.IV = iv;
            ICryptoTransform encryptor = aes.CreateEncryptor();

            return encryptor.TransformFinalBlock(text, 0, text.Length);
        }

        public static byte[] Decrypt(string encryptedText, string key)
        {
            byte[] iv = new byte[16];
            byte[] text = Convert.FromBase64String(encryptedText);
            Aes aes = Aes.Create();
            aes.Key = Convert.FromBase64String(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor();

            return decryptor.TransformFinalBlock(text, 0, text.Length);
        }
    }
}
