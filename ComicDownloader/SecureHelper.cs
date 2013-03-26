using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ComicDownloader
{
   public  class SecureHelper
    {
       public static void EncryptFile(string inputFile, string outputFile, string skey)
       {
           RijndaelManaged aes = new RijndaelManaged();

           try
           {
               byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

               using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
               {
                   using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateEncryptor(key, key), CryptoStreamMode.Write))
                   {
                       using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                       {
                           int data;

                           while ((data = fsIn.ReadByte()) != -1)
                           {
                               cs.WriteByte((byte)data);
                           }

                           aes.Clear();
                       }

                   }
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               aes.Clear();
           }
       }

       public static void DecryptFile(string inputFile, string outputFile, string skey)
       {
           RijndaelManaged aes = new RijndaelManaged();

           try
           {
               byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

               using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
               {
                   using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                   {
                       using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateDecryptor(key, key), CryptoStreamMode.Read))
                       {
                           int data;

                           while ((data = cs.ReadByte()) != -1)
                           {
                               fsOut.WriteByte((byte)data);
                           }

                           aes.Clear();
                       }
                   }
               }

           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               aes.Clear();
           }
       }

    }
}
