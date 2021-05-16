using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    [Serializable]
    public class Site : ISite
    {
        private string _name;
        private User _user;
        private List<User> _authors;
        private List<News> _news;
        private List<Theme> _themes;
        private List<string> _rubrics;
        public string Name { get => _name; }
        public string CurUserName { get => _user.Nickname; }
        public List<string> Rubrics { get => _rubrics; }
        public List<News> AllNews { get => _news; }
        public List<User> Authors { get => _authors; }
        public string AuthorsToPrint
        {
            get
            {
                string strOut = "";
                if (_authors.Count == 0)
                    throw new Exception("There is no authors!");
                for (int i = 0; i < _authors.Count; i++)
                {
                    strOut += (i + 1).ToString() + ". " + _authors[i].Nickname;
                    if (i != _authors.Count - 1)
                        strOut += "\n";
                }
                return strOut;
            }
        }
        public string NewsToPrint
        {
            get
            {
                string strOut = "";
                if (_news.Count == 0)
                    throw new Exception("There is no news!");
                for (int i = 0; i < _news.Count; i++)
                {
                    strOut += (i + 1).ToString() + ". " + _news[i].Name;
                    if (i != _news.Count - 1)
                        strOut += "\n";
                }
                return strOut;
            }
        }
        public string RubricsToPrint
        {
            get
            {
                string strOut = "";
                if (_rubrics.Count == 0)
                    throw new Exception("There is no rubrics!");
                for (int i = 0; i < _rubrics.Count; i++)
                {
                    strOut += (i + 1).ToString() + ". " + _rubrics[i];
                    if (i != _rubrics.Count - 1)
                        strOut += "\n";
                }
                return strOut;
            }
        }
        public string ThemesToPrint
        {
            get
            {
                string strOut = "";
                if (_themes.Count == 0)
                    throw new Exception("There is no themes!");
                for (int i = 0; i < _themes.Count; i++)
                {
                    strOut += (i + 1).ToString() + ". " + _themes[i].Name + " (";
                    for (int j = 0; j < _themes[i].Tags.Length; j++)
                    {
                        strOut += _themes[i].Tags[j];
                        if (j != _themes[i].Tags.Length - 1)
                            strOut += ", ";
                    }
                    strOut += ")";
                    if (i != _themes.Count - 1)
                        strOut += "\n";
                }
                return strOut;
            }
        }
        public Site(string name)
        {
            _name = name;
            _user = null;
            _authors = new List<User>(0);
            _themes = new List<Theme>(6) { new Theme("Animals",  new string[3] {"animal", "funny", "beautiful"}),
                                           new Theme("Study",    new string[3] {"study", "teachers", "lessons"}),
                                           new Theme("Weekend",  new string[3] {"weekend", "funny", "resting"}),
                                           new Theme("Politics", new string[3] {"politic", "notfunny", "boring"}),
                                           new Theme("History",  new string[3] {"history", "funny", "boring"}),
                                           new Theme("Games",    new string[3] {"resting", "funny", "sport"})};
            _rubrics = new List<string>(4) { "Important", "Usual", "Breacking news", "Casual" };
            _news = new List<News>(0);
        }
        public void AddGuest()
        {
            User newUser = new Guest();
            _user = newUser;
        }
        public void Register(string nickname, string login, string pass)
        {
            if (nickname != null && login != null && pass != null)
            {
                if (FindUser(login) == null)
                {
                    User newUser = new Author(nickname, login, pass);
                    _user = newUser;
                    _authors.Add(newUser);
                }
                else
                    throw new Exception("You are registered already!");
            }
            else
                throw new Exception("Registration fail!");
        }
        public void Login(string login, string pass)
        {
            if (login != null && pass != null)
            {
                User newUser = FindUser(login, pass);
                if (newUser != null)
                {
                    _user = newUser;
                }
                else
                    throw new Exception("Wrong login or password!");
            }
            else
                throw new Exception("Login fail!");
        }
        public void Logout()
        {
            if (_user != null)
            {
                _user = null;
            }
            else
                throw new Exception("You are not in system!");
        }
        public void AddNews(string name, int rubric, string text, int theme, string[] tags = null)
        {
            if (_user is Author)
            {
                News newNews = new News(name, _rubrics[rubric], _themes[theme], text, _user, DateTime.Now.Month, tags);
                _news.Add(newNews);
            }
            else
                throw new Exception("Failed to add news!");
        }
        public string NewsByRubric(int rubNum, out List<News> news)
        {
            string strOut = "";
            int number = 1;
            news = new List<News>(0);
            if (_news.Count == 0)
                throw new Exception("There is no news!");
            for (int i = 0; i < _news.Count; i++)
            {
                if (_news[i].Rubric == _rubrics[rubNum - 1])
                {
                    news.Add(_news[i]);
                    strOut += (number++).ToString() + ". " + _news[i].Name;
                    if (i != _news.Count - 1)
                        strOut += "\n";
                }
            }
            if (news.Count == 0)
                throw new Exception("There is no news in this rubric!");
            return strOut;
        }
        public string NewsByAuthor(int authorNum, out List<News> news)
        {
            string strOut = "";
            int number = 1;
            news = new List<News>(0);
            if (_news.Count == 0)
                throw new Exception("There is no news!");
            for (int i = 0; i < _news.Count; i++)
            {
                if (_news[i].ItsAuthor == _authors[authorNum - 1])
                {
                    news.Add(_news[i]);
                    strOut += (number++).ToString() + ". " + _news[i].Name;
                    if (i != _news.Count - 1)
                        strOut += "\n";
                }
            }
            if (news.Count == 0)
                throw new Exception("There is no news by this author!");
            return strOut;
        }
        public string NewsByTheme(int themeNum, out List<News> news)
        {
            string strOut = "";
            int number = 1;
            news = new List<News>(0);
            if (_news.Count == 0)
                throw new Exception("There is no news!");
            for (int i = 0; i < _news.Count; i++)
            {
                if (_news[i].NewsTheme == _themes[themeNum - 1])
                {
                    news.Add(_news[i]);
                    strOut += (number++).ToString() + ". " + _news[i].Name;
                    if (i != _news.Count - 1)
                        strOut += "\n";
                }
            }
            if (news.Count == 0)
                throw new Exception("There is no news by this theme!");
            return strOut;
        }
        public string NewsByMonth(int monthNum, out List<News> news)
        {
            string strOut = "";
            int number = 1;
            news = new List<News>(0);
            if (_news.Count == 0)
                throw new Exception("There is no news!");
            for (int i = 0; i < _news.Count; i++)
            {
                if (_news[i].Month == monthNum)
                {
                    news.Add(_news[i]);
                    strOut += (number++).ToString() + ". " + _news[i].Name;
                    if (i != _news.Count - 1)
                        strOut += "\n";
                }
            }
            if (news.Count == 0)
                throw new Exception("There is no news in this month!");
            return strOut;
        }
        public string NewsByTag(string tag, out List<News> news)
        {
            string strOut = "";
            int number = 1;
            news = new List<News>(0);
            if (_news.Count == 0)
                throw new Exception("There is no news!");
            for (int i = 0; i < _news.Count; i++)
            {
                if (MatchTags(tag, _news[i].Tags))
                {
                    news.Add(_news[i]);
                    strOut += (number++).ToString() + ". " + _news[i].Name;
                    if (i != _news.Count - 1)
                        strOut += "\n";
                }
            }
            if (news.Count == 0)
                throw new Exception("There is no news found by this tag!");
            return strOut;
        }
        public bool MatchPass(string pass)
        {
            if (FindUser(_user.Login, pass) != null)
                return true;
            else
                return false;
        }
        public void ChangeUserName(string newName)
        {
            if (newName != "" && newName != null)
            {
                _user.ChangeName(newName);
            }
            else
                throw new Exception("Failed to change your name!");
        }
        public void ChangeUserPass(string newPass)
        {
            if (newPass != "" && newPass != null)
            {
                _user.ChangePass(newPass);
            }
            else
                throw new Exception("Failed to change your password!");
        }
        private User FindUser(string login)
        {
            foreach (User i in _authors)
            {
                if (i.Login == login)
                    return i;
            }
            return null;
        }
        private User FindUser(string login, string pass)
        {
            foreach (User i in _authors)
            {
                if (i.Login == login && i.CheckPass(pass))
                    return i;
            }
            return null;
        }
        private static bool MatchTags(string tag, string[] tags)
        {
            for (int i = 0; i < tags.Length; i++)
            {
                if (tags[i] == tag)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
