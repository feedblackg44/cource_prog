using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SiteLogic;

namespace SiteInterface
{
    class Program
    {
        enum StateType { NoOne, Guest, Author };
        static void Main(string[] args)
        {
            string name = "KPI News";
            BinaryFormatter formatter = new BinaryFormatter();
            Site site;
            if (File.Exists("site.dat"))
            {
                using (FileStream fs = new FileStream("site.dat", FileMode.OpenOrCreate))
                {
                    site = (Site)formatter.Deserialize(fs);
                }
            }
            else
                site = new Site(name);
            int choise = -1;
            StateType state = StateType.NoOne;
            while (true)
            {
                Menu.PrintLogo(name);

                try
                {
                    if (state == StateType.NoOne)
                    {
                        switch (choise)
                        {
                            case (1):
                                site.AddGuest();
                                state = StateType.Guest;
                                choise = -1;
                                break;
                            case (2):
                                Console.Write("Write here your login: ");
                                string login = Console.ReadLine();
                                Console.Write("Write here your password: ");
                                string pass = Tools.GetPass();
                                Console.WriteLine();
                                Console.Write("Write here your nickname: ");
                                string nickname = Console.ReadLine();
                                site.Register(nickname, login, pass);
                                state = StateType.Author;
                                choise = -1;
                                break;
                            case (3):
                                Console.Write("Write here your login: ");
                                string log = Console.ReadLine();
                                Console.Write("Write here your password: ");
                                string password = Tools.GetPass();
                                Console.WriteLine();
                                site.Login(log, password);
                                state = StateType.Author;
                                choise = -1;
                                break;
                            case (0):
                                System.Environment.Exit(0);
                                break;
                            default:
                                Menu.PrintDefaultMenu(name);
                                Console.Write("\nChoose a num from 0 to 3: ");
                                choise = Tools.GetInt();
                                break;
                        }
                    }
                    else if (state == StateType.Guest)
                    {
                        switch (choise)
                        {
                            case (1):
                                Console.WriteLine("Rubrics:");
                                Console.WriteLine(site.RubricsToPrint);
                                Console.Write("\nChoose a rubric to show news: ");
                                int rubNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByRubric;
                                Console.WriteLine("News in rubric {0}:", site.Rubrics[rubNum - 1]);
                                Console.WriteLine(site.NewsByRubric(rubNum, out newsByRubric));
                                Console.Write("\nChoose news to show: ");
                                int newsNumR = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByRubric[newsNumR - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (2):
                                Console.Write("\nChoose a tag to show news: ");
                                string tag = Console.ReadLine();

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByTag;
                                Console.WriteLine("News by tag {0}:", tag);
                                Console.WriteLine(site.NewsByTag(tag, out newsByTag));
                                Console.Write("\nChoose news to show: ");
                                int newsNumT = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByTag[newsNumT - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (3):
                                Console.WriteLine("Authors:");
                                Console.WriteLine(site.AuthorsToPrint);
                                Console.Write("\nChoose an author to show news: ");
                                int authorNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByAuthor;
                                Console.WriteLine("News by Author {0}:", site.Authors[authorNum - 1].Nickname);
                                Console.WriteLine(site.NewsByAuthor(authorNum, out newsByAuthor));
                                Console.Write("\nChoose news to show: ");
                                int newsNumA = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByAuthor[authorNum - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (4):
                                Console.WriteLine("Themes:");
                                Console.WriteLine(site.ThemesToPrint);
                                Console.Write("\nChoose a theme to show news: ");
                                int themeNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByTheme;
                                Console.WriteLine("News by theme number {0}:", themeNum);
                                Console.WriteLine(site.NewsByTheme(themeNum, out newsByTheme));
                                Console.Write("\nChoose news to show: ");
                                int newsNumTh = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByTheme[newsNumTh - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (5):
                                Console.Write("Write a month number to show news: ");
                                int monthNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByMonth;
                                Console.WriteLine("News by month number {0}:", monthNum);
                                Console.WriteLine(site.NewsByMonth(monthNum, out newsByMonth));
                                Console.Write("\nChoose news to show: ");
                                int newsNumM = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByMonth[newsNumM - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (6):
                                Console.WriteLine("All news:");
                                Console.WriteLine(site.NewsToPrint);

                                Console.Write("\nChoose news to show: ");
                                int newsNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(site.AllNews[newsNum - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (0):
                                site.Logout();
                                state = StateType.NoOne;
                                choise = -1;
                                break;
                            default:
                                Menu.PrintGuestMenu(site.CurUserName);
                                Console.Write("\nChoose a num from 0 to 6: ");
                                choise = Tools.GetInt();
                                break;
                        }
                    }
                    else if (state == StateType.Author)
                    {
                        switch (choise)
                        {
                            case (1):
                                Console.WriteLine("Rubrics:");
                                Console.WriteLine(site.RubricsToPrint);
                                Console.Write("\nChoose a rubric to show news: ");
                                int rubNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByRubric;
                                Console.WriteLine("News in rubric {0}:", site.Rubrics[rubNum - 1]);
                                Console.WriteLine(site.NewsByRubric(rubNum, out newsByRubric));
                                Console.Write("\nChoose news to show: ");
                                int newsNumR = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByRubric[newsNumR - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (2):
                                Console.Write("\nChoose a tag to show news: ");
                                string tag = Console.ReadLine();

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByTag;
                                Console.WriteLine("News by tag {0}:", tag);
                                Console.WriteLine(site.NewsByTag(tag, out newsByTag));
                                Console.Write("\nChoose news to show: ");
                                int newsNumT = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByTag[newsNumT - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (3):
                                Console.WriteLine("Authors:");
                                Console.WriteLine(site.AuthorsToPrint);
                                Console.Write("\nChoose an author to show news: ");
                                int authorNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByAuthor;
                                Console.WriteLine("News by Author {0}:", site.Authors[authorNum - 1].Nickname);
                                Console.WriteLine(site.NewsByAuthor(authorNum, out newsByAuthor));
                                Console.Write("\nChoose news to show: ");
                                int newsNumA = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByAuthor[authorNum - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (4):
                                Console.WriteLine("Themes:");
                                Console.WriteLine(site.ThemesToPrint);
                                Console.Write("\nChoose a theme to show news: ");
                                int themeNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByTheme;
                                Console.WriteLine("News by theme number {0}:", themeNum);
                                Console.WriteLine(site.NewsByTheme(themeNum, out newsByTheme));
                                Console.Write("\nChoose news to show: ");
                                int newsNumTh = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByTheme[newsNumTh - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (5):
                                Console.Write("Write a month number to show news: ");
                                int monthNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                List<News> newsByMonth;
                                Console.WriteLine("News by month number {0}:", monthNum);
                                Console.WriteLine(site.NewsByMonth(monthNum, out newsByMonth));
                                Console.Write("\nChoose news to show: ");
                                int newsNumM = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(newsByMonth[newsNumM - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (6):
                                Console.WriteLine("All news:");
                                Console.WriteLine(site.NewsToPrint);

                                Console.Write("\nChoose news to show: ");
                                int newsNum = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Menu.PrintLogo(name);
                                Console.WriteLine(site.AllNews[newsNum - 1]);

                                Console.WriteLine("\nPress any key to back to main menu...");
                                Console.ReadKey();
                                choise = -1;
                                break;
                            case (7):
                                Console.Write("Write a name for the news: ");
                                string newsName = Console.ReadLine();
                                Console.Write("Write a text for the news: ");
                                string newsText = Console.ReadLine();
                                Console.WriteLine("Rubrics:");
                                Console.WriteLine(site.RubricsToPrint);
                                Console.Write("Choose a rubric: ");
                                int newsRubric = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Themes:");
                                Console.WriteLine(site.ThemesToPrint);
                                Console.Write("Choose a theme: ");
                                int newsTheme = Convert.ToInt32(Console.ReadLine());

                                site.AddNews(newsName, newsRubric - 1, newsText, newsTheme - 1);

                                choise = -1;
                                break;
                            case (8):
                                Console.Write("Write your current password: ");
                                string nPass = Tools.GetPass();
                                Console.WriteLine();
                                if (site.MatchPass(nPass))
                                {
                                    Console.Write("Write your new nickname: ");
                                    string newName = Console.ReadLine();
                                    site.ChangeUserName(newName);
                                }
                                choise = -1;
                                break;
                            case (9):
                                Console.Write("Write your current password: ");
                                string cPass = Tools.GetPass();
                                Console.WriteLine();
                                if (site.MatchPass(cPass))
                                {
                                    Console.Write("Write your new password: ");
                                    string newPass = Tools.GetPass();
                                    site.ChangeUserPass(newPass);
                                }

                                choise = -1;
                                break;
                            case (0):
                                site.Logout();
                                state = StateType.NoOne;
                                choise = -1;
                                break;
                            default:
                                Menu.PrintAuthorMenu(site.CurUserName);
                                Console.Write("\nChoose a num from 0 to 10: ");
                                choise = Tools.GetInt();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Menu.PrintLogo(name);

                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    choise = -1;
                }
                using (FileStream fs = new FileStream("site.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, site);
                }
                Console.Clear();
            }
        }
    }
}
