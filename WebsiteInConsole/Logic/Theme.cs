using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    [Serializable]
    public class Theme
    {
        private string _name;
        private string[] _tags;
        public string Name { get => _name; }
        public string[] Tags { get => _tags; }
        public Theme(string name, string[] tags = null)
        {
            _name = name;
            _tags = tags;
        }
    }
}
