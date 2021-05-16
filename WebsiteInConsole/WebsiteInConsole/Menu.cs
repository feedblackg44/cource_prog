using System;
using System.Collections.Generic;
using System.Text;

namespace SiteInterface
{
    static class Menu
    {
        public static void PrintDefaultMenu(string name)
        {
            string menuHead = "Welcome to " + name + "!\n\n";
            List<string> choises = new List<string>(0);
            choises.Add("1 - Enter as Guest");
            choises.Add("2 - Register");
            choises.Add("3 - Login");
            choises.Add("0 - Exit");

            string menu = menuHead;
            for (int i = 0; i < choises.Count; i++)
            {
                menu += choises[i] + "\n";
            }

            Console.Write(menu);
        }
        public static void PrintGuestMenu(string name)
        {
            string menuHead = "Hello, " + name + "!\n\n";
            List<string> choises = new List<string>(0);
            choises.Add("1 - Show rubrics");
            choises.Add("2 - Choose a tag");
            choises.Add("3 - Show authors");
            choises.Add("4 - Show themes");
            choises.Add("5 - Show news by month");
            choises.Add("6 - Show all news");
            choises.Add("0 - Logout");

            string menu = menuHead;
            for (int i = 0; i < choises.Count; i++)
            {
                menu += choises[i] + "\n";
            }

            Console.Write(menu);
        }
        public static void PrintAuthorMenu(string name)
        {
            string menuHead = "Hello, " + name + "!\n\n";
            List<string> choises = new List<string>(0);
            choises.Add("1 - Show rubrics");
            choises.Add("2 - Choose a tag");
            choises.Add("3 - Show authors");
            choises.Add("4 - Show themes");
            choises.Add("5 - Show news by date");
            choises.Add("6 - Show all news");
            choises.Add("7 - Create news");
            choises.Add("8 - Change name");
            choises.Add("9 - Change password");
            choises.Add("0 - Logout");

            string menu = menuHead;
            for (int i = 0; i < choises.Count; i++)
            {
                menu += choises[i] + "\n";
            }

            Console.Write(menu);
        }
        public static void PrintLogo(string name)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\t\t/-----");
            for (int i = 0; i < name.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-----\\");
            Console.Write("\t\t|     ");
            Console.Write(name);
            Console.WriteLine("     |");
            Console.Write("\t\t\\-----");
            for (int i = 0; i < name.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-----/");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
