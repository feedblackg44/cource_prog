using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    public class Site
    {
        private string _name;
        private User _user;
        private List<User> _authors;
        private List<News> _news;
        private List<string> _rubrics;
        public string name { get => _name; }
        public User CurUser { get => _user; }
        public List<User> Authors { get => _authors; }
        public string AuthorsToPrint
        {
            get 
            {
                string strOut = "";
                for (int i = 0; i < _authors.Count; i++)
                {
                    strOut += (i + 1).ToString() + ". " + _authors[i].Nickname;
                }
                return strOut;
            }
        }
        public List<News> NewsList { get => _news; }
        public string NewsToPrint
        {
            get
            {
                string strOut = "";
                for (int i = 0; i < _news.Count; i++)
                {
                    strOut += (i + 1).ToString() + ". " + _news[i].Name;
                }
                return strOut;
            }
        }
        public List<string> Rubrics { get => _rubrics; }
        public string RubricsToPrint
        {
            get
            {
                string strOut = "";
                for (int i = 0; i < _rubrics.Count; i++)
                {
                    strOut += (i + 1).ToString() + ". " + _rubrics[i];
                }
                return strOut;
            }
        }
        public Site(string name)
        {
            _name = name;
            _user = null;
            _authors = new List<User>(0);
            _rubrics = new List<string>(0);
            _news = new List<News>(0);
        }
        public void AddNews(string name, string rubric, string text, Theme theme, string[] tags = null)
        {
            if (_user is Author)
            {
                News newNews = new News(name, rubric, theme, text, _user, tags);
                _news.Add(newNews);
            }
            else
                throw new Exception("Failed to add news!");
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
        public void DeleteUser()
        {
            if (_user != null && _authors.Contains(_user))
            {
                int index = _authors.IndexOf(_user);
                _authors.RemoveAt(index);
                Logout();
            }
            else
                throw new Exception("Error while deleting user!");
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
                if (i.Login == login && i.HashPass == Tools.CreateMD5(pass))
                    return i;
            }
            return null;
        }
    }
}
