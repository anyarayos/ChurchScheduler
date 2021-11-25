using System;
using ChurchNameSpace;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChurchSched
{
	public partial class frmLogIn : Form
				{
        private string username, password;
        private int attempt = 0;
        public frmLogIn()
		{
			InitializeComponent();
		}
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator("Gelay Magalona", "GelayCEO", "password123");

            username = txtUserName.Text;
            password = txtPassword.Text;

            if(admin.verifyLogin(username, password))
            {
                this.DialogResult = DialogResult.Yes;
                this.Dispose();
            }
            else
            {
                attempt++;
                MessageBox.Show("Incorrect Username or Password. \nPlease try again: \nAttempts: " + attempt);
                txtUserName.Text = "";
                txtPassword.Text = "";

                if (attempt == 5)
                {
                    MessageBox.Show("Maximum attempts is reach. \nApplication will now exit");
                    this.DialogResult = DialogResult.No;
                    this.Dispose();
                }
            }
            
        }
       
    }
}
