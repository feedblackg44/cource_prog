using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    public abstract class User
    {
        protected string _nickname;
        protected UserType _type;
        protected static uint _amount = 0;
        protected string _login;
        protected string _hashPass;
        public string Login { get => _login; }
        public string HashPass { get => _hashPass; }
        public string Nickname { get => _nickname; }
        public UserType Type { get => _type; }
        public static uint Amount { get => _amount; }
    }
}
