using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncDecUtil
{
    public class EncDecCls
    {
        static string key = "4khd76s6d7f82sde";
        public static string EncryptData64(string data)
        {
            try
            {
                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(data);
                string encrypted = Convert.ToBase64String(b);
                byte[] c = System.Text.ASCIIEncoding.ASCII.GetBytes(encrypted);
                encrypted = Convert.ToBase64String(c);
                return encrypted;

            }
            catch (Exception exx)
            {

                return "";
            }
            
            // return data;
        }
        public static string DecryptData64(string data)
        {
            byte[] b;
            byte[] c;
            string decrypted;
            try
            {
                
                b = Convert.FromBase64String(data);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);

                c = Convert.FromBase64String(decrypted);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(c);
            }
            catch (Exception fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
        public static string EncryptData(string input)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string DecryptData(string input)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
