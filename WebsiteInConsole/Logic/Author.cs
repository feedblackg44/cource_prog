using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    public class Author : User
    {
        public Author(string nickname, string login, string pass)
        {
            _amount++;
            _nickname = nickname;
            _login = login;
            _hashPass = Tools.CreateMD5(pass);
            _type = UserType.Author;
        }
    }
}
