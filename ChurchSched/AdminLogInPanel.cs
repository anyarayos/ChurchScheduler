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
								// variables
								private int loginAttempt = 3;

								// set connection method
								private void SetConnection(string database)
								{
												sql_con = new SQLiteConnection("Data Source=" + database + "; Version=3; New=False; Compress=True;");
								}

								// login button
								private void btnLogIn_Click(object sender, EventArgs e)
								{
												// sql connection with Church.db
												SetConnection("Church.db");

												// data table will have a row if query returns a record
												DB = new SQLiteDataAdapter("SELECT * FROM Accounts WHERE username='" + txtUserName.Text + "' AND password='" + txtPassword.Text + "'", sql_con);
												DT = new DataTable();
												DB.Fill(DT);

												// if data table has returned a record then proceed to login
												if(DT.Rows.Count == 1)
												{
																this.DialogResult = DialogResult.Yes;
																this.Dispose();
																}
																else
																{
																// loginAttempt if else
																loginAttempt--;
																if(loginAttempt == 0)
																{
																				MessageBox.Show("No more attempts left.\nApplication will now exit.");
																				this.DialogResult = DialogResult.No;
																				this.Dispose();
																}
																else
																{
																				txtUserName.Text = "";
																				txtPassword.Text = "";
																				MessageBox.Show("Incorrect Username or Password.\nPlease try again.\nAttempts left: " + loginAttempt);
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