using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchNameSpace
{
    class Administrator : Admin
    {
        private string Admin_Name;

        public Administrator(string name, string ID, string pass) : base ( ID, pass)
        {
            this.Admin_Name = name;
        }

        public override void updatePassword(string newPassword)
        {
            this.UserPassword = newPassword;
        }

        public void updateAdminName(string name)
        {
            this.Admin_Name = name;
        }

    }
}
