using System;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Infrastructure
{
    public class EncryptHelper
    {
        public static string SHA1_Encrypt(string cleanStr)
        {
            byte[] bytes = Encoding.Default.GetBytes(cleanStr);
            using (SHA1 sha = new SHA1CryptoServiceProvider())
            {
                string[] strArray = BitConverter.ToString(sha.ComputeHash(bytes)).Split(new char[] { '-' });
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < strArray.Length; i++)
                {
                    builder.Append(strArray[i]);
                }
                return builder.ToString().Trim();
            }
        }
    }
}
