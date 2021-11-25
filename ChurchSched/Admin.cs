using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchNameSpace
{
    abstract class Admin
    {
        private string UserName;
        protected string UserPassword;

        public Admin(string ID, string pass)
        {
            this.UserName = ID;
            this.UserPassword = pass;
        }
        public bool verifyLogin(string ID, string pass)
        {
            if (this.UserName.Equals(ID) && this.UserPassword.Equals(pass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract void updatePassword(string newPassword);
    }


}
