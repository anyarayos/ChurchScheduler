using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace ChurchSched
{
    public partial class ForgotPassSendCode : Form
    {
        String randomCode;
        public static string to;
        public ForgotPassSendCode()
        {
            InitializeComponent();
        }

        private void btnFogotSend_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtForgotEmailRecovery.Text).ToString();
            from = ""; // the Email in the databsae
            pass = ""; // the password of the email
            messageBody = "Your Reset Code is : " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password Reseting Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Sent Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnForgotVerify_Click(object sender, EventArgs e)
        {
            if(randomCode == (txtForgotCodeVerify.Text).ToString())
            {
                to = txtForgotEmailRecovery.Text;
                ResetPass rp = new ResetPass();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("Wrong Reset Code");
            }
        }   
    }
}
