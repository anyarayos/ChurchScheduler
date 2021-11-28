using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Linq;

namespace ChurchSched
{
    public partial class frmLobbyPanel : Form
    {
        // SQLITE VARIABLES AND METHODS ================================================

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

        // execute query method
        private void ExecuteQuery(string txtQuery)
        {
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        // REQUESTEE PANEL VARIABLES ================================================
        DataGridViewRow requesteeSelectedRow;
        int requesteeSelectedRowID;
        string userIDAndName;

        // REQUESTEE PANEL METHODS ================================================

        private void dgvRequesteeLoadUserInfo()
        // load UserInfo into requestee data grid view
        {
            DB = new SQLiteDataAdapter("SELECT * FROM UserInfo", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            //dgvRequestees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequestees.DataSource = DT;
            // id column width
            dgvRequestees.Columns[0].Width = 50;
												// name and email column width
            dgvRequestees.Columns[1].Width = 150;
            dgvRequestees.Columns[3].Width = 150;
            // address column width
            dgvRequestees.Columns[4].Width = 400;
        }

        private bool checkIfUserExists(string email, string contact)
        // check if the user already exists
        {
            // sql connection with Church.db
            SetConnection("Church.db");

            // data table will have a row if query returns a record
            DB = new SQLiteDataAdapter("SELECT id FROM UserInfo WHERE  email='" + email + "' OR contact='" + contact + "'", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            
            // if data table returns a record, user exists
            return DT.Rows.Count == 1;
        }

        private void insertNewUserInfo(string name, string contact, string email, string address)
								// insert new user info
        {
            string SQLiteQuery = "INSERT INTO UserInfo (name, contact, email, address) VALUES ('" + name + "', '" + contact + "', '" + email + "', '" + address + "');";
            ExecuteQuery(SQLiteQuery);
        }

        private void updateUserInfo(int id, string name, string contact, string email, string address)
        // update user info
        {
            string SQLiteQuery = "UPDATE UserInfo SET name='" + name + "', contact='" + contact + "', email='" + email + "', address='" + address + "' WHERE Id='" + id + "'";
            ExecuteQuery(SQLiteQuery);
        }

        // REQUESTEE PANEL EVENTS ================================================

        // confirm requestee button
        private void btnConfirmRequestee_Click(object sender, EventArgs e)
        {
            // check if textboxes are filled
            bool textBoxesFilled = !(txtRequestName.Text == "" || txtContactNum.Text == "" || txtEmailAdd.Text == "" || txtAddress.Text == "");

            // insert new user info if text boxes are filled and no user duplication
            if (textBoxesFilled && !checkIfUserExists(txtEmailAdd.Text, txtContactNum.Text))
            {
                // insert new user info
                insertNewUserInfo(txtRequestName.Text, txtContactNum.Text, txtEmailAdd.Text, txtAddress.Text);
                // refresh requestee data grid view
                dgvRequesteeLoadUserInfo();

                MessageBox.Show("New requestee added.");
            }
            else if (textBoxesFilled && checkIfUserExists(txtEmailAdd.Text, txtContactNum.Text))
            {
                MessageBox.Show("Requestee already exists.");
            }
            else
            {
                MessageBox.Show("Incomplete submission, complete and try again.");
            }
        }

        // edit requestee button
        private void btnEditrequestee_Click(object sender, EventArgs e)
        {
            if (requesteeSelectedRowID > 0)
            {
                // message box edit confirmation
                DialogResult confirmEdit = MessageBox.Show(
                    // message box message
                    "Are you sure to edit user id: " + requesteeSelectedRowID + " with the following values?\n" +
                    "\nname: " + txtRequestName.Text +
                    "\ncontact: " + txtContactNum.Text +
                    "\nemail: " + txtEmailAdd.Text +
                    "\naddress: " + txtAddress.Text,
                    // message box title
                    "Edit Confirmation",
                    // message box buttons
                    MessageBoxButtons.YesNo
                );
                // if edit confirmed
                if(confirmEdit == DialogResult.Yes)
																{
                    // update user info
                    updateUserInfo(requesteeSelectedRowID, txtRequestName.Text, txtContactNum.Text, txtEmailAdd.Text, txtAddress.Text);
                    // refresh requestee data grid view
                    dgvRequesteeLoadUserInfo();

                    MessageBox.Show("User info successfully updated.");
																}
            }
            else
            {
                MessageBox.Show("No user selected.");
            }
        }

        // RESERVATION PANEL METHODS ================================================

        // populate combo box with events
        private void populateWEvents(ComboBox combobox)
        {
            String[] events = { "Wedding", "Baptism", "Confirmation", "Mass" };
            foreach(string ev in events)
            {
                combobox.Items.Add(ev);
            }
        }

        // populate combo box with time
        private void populateWTime(ComboBox combobox)
        {
            List<String> timeIntervals = new List<String>();
            var item = DateTime.Today.AddHours(7);
            while (item <= DateTime.Today.AddHours(15))
            {
                string format = item.ToString("hh:mm tt") + " - " + item.AddMinutes(120).ToString("hh:mm tt");
                timeIntervals.Add(format);
                item = item.AddMinutes(60);
            }
            Object[] timeRange = timeIntervals.Cast<object>().ToArray();
            combobox.Items.AddRange(timeRange);
        }

        // FORM METHODS ================================================

        public frmLobbyPanel()
        {
            InitializeComponent();
        }

        private void frmLobbyPanel_Load(object sender, EventArgs e)
        {
            // establish connection to church database
            SetConnection("Church.db");

            // REQUESTEE PANEL ================
            // load UserInfo into requestee data grid view
            dgvRequesteeLoadUserInfo();

            // RESERVATION PANEL ================
            tbcon1.TabPages.Remove(tbReservation);
            populateWEvents(cmbEvents);//Populates comboboxes wag tanggalin please lng
            populateWTime(cmbTime);
            cmbEvents.SelectedIndex = 0;//Wag rin mga to
            cmbTime.SelectedIndex = 0;//
        }

        // MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY ================================================
        // MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY ================================================
        // MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY ================================================
        // MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY MESSY ================================================

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure that you would cancel this reservation ???", "Warning !!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                frmCancelationRemark cncl = new frmCancelationRemark();
                cncl.ShowDialog();
            }
            else
            {
                 //  
            }
        }

        private void btnCancelRequestee_Click(object sender, EventArgs e)
        {
            //delete highlighted 
            DialogResult dialogResult = MessageBox.Show("Are you sure that you would delete this Requestee ???", "Warning !!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                sql_con.Open();
                // sql_cmd = new SQLiteCommand("DELETE FROM UserInfo WHERE Id='"+selectedRow+"'", sql_con);
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                MessageBox.Show("Deleted");
                display();
            }
            else
            {
                //  
            }
            
        }

        // clear requestee textboxes button
        private void btnClearRequestee_Click(object sender, EventArgs e)
        {
            txtRequestName.Clear();
            txtContactNum.Clear();
            txtEmailAdd.Clear();
            txtAddress.Clear();
        }

        // requestees data grid view cell click event
        private void dgvRequestees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // data grid view row index
            int index = e.RowIndex;
            requesteeSelectedRow = dgvRequestees.Rows[index];

            // set requestee selected row id
            requesteeSelectedRowID = Convert.ToInt32(requesteeSelectedRow.Cells[0].Value);

            // populate textboxes with selected row's values
            txtRequestName.Text = requesteeSelectedRow.Cells[1].Value.ToString();
            txtContactNum.Text = requesteeSelectedRow.Cells[2].Value.ToString();
            txtEmailAdd.Text = requesteeSelectedRow.Cells[3].Value.ToString();
            txtAddress.Text = requesteeSelectedRow.Cells[4].Value.ToString();

            // selected user for reservation panel
            userIDAndName = requesteeSelectedRowID.ToString() + "_" + requesteeSelectedRow.Cells[1].Value.ToString();
            txtIDNameReserve.Text = userIDAndName;
        }
        private void dgvRequestees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbcon1.TabPages.Remove(tbReservation);
            tbcon1.TabPages.Remove(tbAllReserve);
            tbcon1.TabPages.Remove(tbPastEvents);
            tbcon1.TabPages.Add(tbReservation);
            tbcon1.TabPages.Add(tbAllReserve);
            tbcon1.TabPages.Add(tbPastEvents);
           
        }
        private void textSearchRequestee_TextChanged(object sender, EventArgs e)
        {
            //con = new SqlConnection(cs);  
            //con.Open();  
            //adapt = new SqlDataAdapter("select * from ---- where FirstName like '"+textSearchRequestee.Text+"%'", con);  
            //dt = new DataTable();  
            //adapt.Fill(dt);  
            //dataGridViewExistingRequestees.DataSource = dt;  
            //con.Close();
        }
        
        int state = 0;//Gagamitin to sa submit kunyari state 1, gamitin mo yung query related sa wedding
        private void cmbEvents_SelectedIndexChanged(object sender, EventArgs e)//Hide/Show Attendees according to event
        {
            string[] weddingReqs = {"Marriage License",
                "Baptismal certificate (Groom)","Baptismal certificate (Bride)",
                "Confirmation certificate (Groom)","Confirmation certificate (Bride)",
                "Birth certificate (Groom)", "Birth certificate (Bride)",
                "CENOMAR (Groom)", "CENOMAR (Bride)",
                "Marriage preparation Seminar",
                "Canonical interview","Marriage Banns",
                "Confession"};
            string[] baptismReqs = {"Birth certificate (Candidate)", "Marriage certificate (Parents)" };
            string[] confirmationReqs = { "Baptismal certificate","Seminar Attendance"};
            if (cmbEvents.SelectedItem.ToString()=="Wedding")
            {
                lblAttendee1.Text = "Groom:";
                lblAttendee2.Text = "Bride:";
                lblAttendee2.Visible = true;
                txtAttendee2.Visible = true;
                state = 1;
                listBoxRequirements.Items.Clear();
                listBoxRequirements.Items.AddRange(weddingReqs);
                //Change dgv
            }
            else if(cmbEvents.SelectedItem.ToString() == "Baptism")
            {
                lblAttendee1.Text = "Candidate:";
                lblAttendee2.Visible = false;
                txtAttendee2.Visible = false;
                state = 2;
                listBoxRequirements.Items.Clear();
                listBoxRequirements.Items.AddRange(baptismReqs);
                //Change dgv
            }
            else if (cmbEvents.SelectedItem.ToString() == "Confirmation")
            {
                lblAttendee1.Text = "Confirmand:";
                lblAttendee2.Visible = false;
                txtAttendee2.Visible = false;
                state = 3;
                listBoxRequirements.Items.Clear();
                listBoxRequirements.Items.AddRange(confirmationReqs);
                //Change dgv
            }
            else
            {
                lblAttendee1.Text = "Purpose:";
                lblAttendee2.Visible = false;
                txtAttendee2.Visible = false;
                state = 4;
                listBoxRequirements.Items.Clear();
                //Change dgv
            }
        }
        private void btnConfirmReserve_Click(object sender, EventArgs e)
        {
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            display();
        }

        public void display() {
            DT = new DataTable();
            sql_con.Open();
            DB = new SQLiteDataAdapter("SELECT * FROM UserInfo", sql_con);
            DB.Fill(DT);
            dgvRequestees.DataSource = DT;
            sql_con.Close();

        }
    }
}
