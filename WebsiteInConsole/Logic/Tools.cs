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
        public static string GetPass()
        {
            string strOut = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Delete)
                {
                    strOut += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            return strOut;
        }
        public static int GetInt()
        {
            int num;

            bool success = Int32.TryParse(Console.ReadLine(), out num);
            if (!success)
            {
                num = -1;
            }

            return num;
        }
    }
}
