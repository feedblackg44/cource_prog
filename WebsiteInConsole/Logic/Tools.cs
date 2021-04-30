using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    public enum UserType { Author, Guest };
    public static class Tools
    {
        public static string CreateMD5(string input)
        {
            input += "goodsalt";
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
