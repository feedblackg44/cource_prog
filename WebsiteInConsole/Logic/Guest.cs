using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    public class Guest : User
    {
        public Guest()
        {
            _amount++;
            _nickname = "guest" + _amount.ToString();
            _login = null;
            _hashPass = null;
            _type = UserType.Guest;
        }
    }
}
