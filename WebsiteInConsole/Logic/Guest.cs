using System;
using System.Collections.Generic;
using System.Text;

namespace SiteLogic
{
    [Serializable]
    public class Guest : User
    {
        public Guest()
        {
            _guestsAmount++;
            _nickname = "guest" + _guestsAmount.ToString();
            _login = null;
            _hashPass = null;
            _type = UserType.Guest;
        }
        public override void ChangeName(string newName)
        {
            throw new Exception("Please register to change name!");
        }
        public override void ChangePass(string pass)
        {
            throw new Exception("Please register to change pass!");
        }
        public override bool CheckPass(string pass)
        {
            throw new Exception("Guest can't have password!");
        }
    }
}
