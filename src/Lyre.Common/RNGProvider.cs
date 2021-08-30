using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Common
{
    public class RNGProvider
    {
        //MUST FIX: RNGCryptoServiceProvider has to be used random isn't secure enough for real purpouses
        //private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private static Random rngProvider = new Random();

        public static string GetString(int length)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_?*#!&$-.";
            char[] ret = new char[length];

            for(int i = 0;i < length; i++)
            {
                ret[i] = alphabet[rngProvider.Next(0, alphabet.Length)];
            }

            return new string(ret);
        }
    }
}
