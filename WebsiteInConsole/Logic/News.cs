using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    public class News
    {
        private string _name;
        private string _rubric;
        private string[] _tags;
        private Theme _newsTheme;
        private User _author;
        private string _text;
        public string Name { get => _name; }
        public string Rubric { get => _rubric; }
        public Theme NewsTheme { get => _newsTheme; }
        public User ItsAuthor { get => _author; }
        public string Text { get => _text; }
        public string[] Tags 
        {
            get 
            {
                if (_tags != null)
                    return _tags;
                else
                    return _newsTheme.Tags;
            }
        }
        public News(string name, string rubric, Theme newsTheme, string text, User user, string[] tags = null)
        {
            _name = name;
            _rubric = rubric;
            _tags = tags;
            _newsTheme = newsTheme;
            _author = user;
            _text = text;
        }
    }
}
              