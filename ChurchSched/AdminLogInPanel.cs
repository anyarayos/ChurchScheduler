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
using System.Data;
using System.Data.SqlClient;


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
            /*Remove the commnet enabler kung meron ng database hehehehe
            //SqlConnection con = new SqlConnection("");//put the sql resources inside the ""
            //SqlDataAdapter Sda = new SqlDataAdaptor("SELECT * FROM ---- WHERE username = '"+txtUserName.Text+"' and password = '"+txtPassword.Text+"'", con); //---- meaning the name of the table with the credential of the admins
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            if(dt.row.Count > 0)
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
            */
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

        private void frmLogIn_Load(object sender, EventArgs e)
        {

        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            ForgotPassSendCode fpsc = new ForgotPassSendCode();
            this.Hide();
            fpsc.Show();

        }
    }
}
