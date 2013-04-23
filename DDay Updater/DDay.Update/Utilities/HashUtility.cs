using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DDay.Update.Utilities
{
    public class HashUtility
    {
        public static string GetSHA1Hash(string pathName)
        {
            byte[] arrbytHashValue;
            SHA1CryptoServiceProvider oSHA1Hasher = new SHA1CryptoServiceProvider();
            using (FileStream oFileStream = new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream);
                oFileStream.Close();
            }
            return Convert.ToBase64String(arrbytHashValue);
        }
    }
}
