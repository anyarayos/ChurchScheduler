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
using System.Data.SQLite;


namespace ChurchSched
{
    public partial class frmLogIn : Form
    {
        // sql variables and objects
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        // set connection method
        private void SetConnection()
								{
            sql_con = new SQLiteConnection("Data Source=Church.db; Version=3; New=False; Compress=True;");
								}

        // execute query NOT SURE IF IMPORTANT
        private void ExecuteQuery(string txtQuery)
								{
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
								}

        // variables
        private int attempt = 3;
        
        // 
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // sql connection 
            SetConnection();
            
            // Data Table
            DB = new SQLiteDataAdapter("SELECT * FROM Accounts WHERE username = '" + txtUserName.Text + "' AND password = '" + txtPassword.Text + "'", sql_con);
            DT = new DataTable();
            DB.Fill(DT);

            // verifyLogin
            if (DT.Rows.Count == 1)
            { 
                this.DialogResult = DialogResult.Yes;
                this.Dispose();
            }
            else
            {
                attempt--;
                if (attempt == 0)
                {
                    MessageBox.Show("No more attempts left. \nApplication will now exit");
                    this.DialogResult = DialogResult.No;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password. \nPlease try again: \nAttempts: " + attempt);
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
            }
        }

        public frmLogIn()
        {
            InitializeComponent();
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
