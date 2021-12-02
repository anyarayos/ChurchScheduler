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
using System.Runtime.InteropServices;//Very Important, Wag tanggalin mawawasak yung curve ng form

namespace ChurchSched
{
				public partial class frmAdminLogin : Form
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
									DB = new SQLiteDataAdapter("SELECT id FROM Accounts WHERE username='" + txtUserName.Text + "' AND password='" + txtPassword.Text + "'", sql_con);
									DT = new DataTable();
									DB.Fill(DT);

									// if data table has returned a record then proceed to login
									if (DT.Rows.Count == 1)
									{
											// adminID IS THE VARIABLE TO HOLD THE ID OF WHICH ADMIN THAT LOGGED IN, FIGURE OUT HOW TO PASS INTO LOBBY PANEL
											int adminID = Convert.ToInt32(DT.Rows[0][0]);

											this.DialogResult = DialogResult.Yes;
											frmLobbyPanel lobby = new frmLobbyPanel(adminID);
											lobby.ShowDialog();
											this.Dispose();
									}
									else
									{
										// loginAttempt if else
										loginAttempt--;
										if (loginAttempt == 0)
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
								//Para maging round yung edges
								[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
								private static extern IntPtr CreateRoundRectRgn
								(
									int nLeftRect,     // x-coordinate of upper-left corner
									int nTopRect,      // y-coordinate of upper-left corner
									int nRightRect,    // x-coordinate of lower-right corner
									int nBottomRect,   // y-coordinate of lower-right corner
									int nWidthEllipse, // width of ellipse
									int nHeightEllipse // height of ellipse
								);//To Here
								public frmAdminLogin()
								{
												InitializeComponent();
												this.FormBorderStyle = FormBorderStyle.None;//Rounded
												Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));//Rounded
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
			this.WindowState = FormWindowState.Minimized;
		}

        private void btnMaximize_Click(object sender, EventArgs e)
        {
			if (this.WindowState == FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Maximized;
				Region = new Region(new Rectangle(0, 0, Width, Height));
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
				Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
			}
		}

        private void btnExit_Click(object sender, EventArgs e)
        {
			this.Close();
		}
		//Instance Variables Needed To Move Form
		//Copy everything from here
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();
		//Wag gagalawin utang na loob
		private void mouseDownEvent()
		{
			ReleaseCapture();
			SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
		}

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
			mouseDownEvent();
        }

        private void frmAdminLogin_MouseDown(object sender, MouseEventArgs e)
        {
			mouseDownEvent();
		}
    }
}