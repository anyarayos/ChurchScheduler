using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ChurchSched
{
    public partial class ResetPass : Form
    {
        string username = ForgotPassSendCode.to;
        public ResetPass()
        {
            InitializeComponent();
        }

        private void btnResetConfirm_Click(object sender, EventArgs e)
        {
      
            if(txtResetNewPass.Text == txtResetConfirmNewPass.Text)
            {/*
                SqlConnection con = new SqlConnection("");//put the sql resources inside the ""
                SqlCommand cmmnd = new SqlCommand("");//insert query inside the ""
                con.Open();
                cmmnd.ExucuteNonQuery();
                con.Close();
                MessageBox.Show("reset Success !!!");*/
            }
            else
            {
                MessageBox.Show("The new Password does not match. \nMake sure that the Password Matched");
            }
        }

        private void btnLogInOnReset_Click(object sender, EventArgs e)
        {
            frmAdminLogin fLog = new frmAdminLogin();
            this.Hide();
            fLog.Show();
        }
    }
}
