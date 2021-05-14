using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    interface ISite
    {
        public void AddGuest();
        public void Register(string nickname, string login, string pass);
        public void Login(string login, string pass);
        public void Logout();
    }
}
