using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ChurchSched
{
    public partial class frmLobbyPanel : Form
    {
        // sql variables and objects
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        // set connection method
        private void SetConnection(string database)
        {
            sql_con = new SQLiteConnection("Data Source=" + database + "; Version=3; New=False; Compress=True;");
        }

        public frmLobbyPanel()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // sql connection with Church.db
            SetConnection("Church.db");

            // if (isAdmin)
            // {
            //      AdminButtonsAndTab.Show();
            // }
            // else
            // {
            //      AdminButtonsAndTab.Hide();
            // }

        }

        // FOR CONFIRM RESERVATION METHOD FOR WEDDINGS (pseudocode)
        //
        // display message box asking a yes or no if the user is sure with the input
        // 
        // if (check if all text boxes are filled)
        // {
        //      open SQLite connection
        //
        //      input.txt (values from text boxes)
        //
        //      INSERT input.txt into RESERVATION TABLE
        //      FIND input.txt FROM RESERVATION TABLE AND GET THE VALUE ID = id.input
        //      INSERT id.input, groom_name, bride_name into WEDDING TABLE
        //
        //      close SQLite connection
        // }
        // else
        // {
        //      display message box that the text boxes are incomplete
        // }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnWeddCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
