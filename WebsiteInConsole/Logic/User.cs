using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    [Serializable]
    public abstract class User
    {
        protected string _nickname;
        protected UserType _type;
        protected static uint _guestsAmount = 0;
        protected string _login;
        protected string _hashPass;
        public string Login { get => _login; }
        public string Nickname { get => _nickname; }
        public UserType Type { get => _type; }
        public abstract void ChangeName(string newName);
        public abstract void ChangePass(string pass);
        public abstract bool CheckPass(string pass);
    }
}
