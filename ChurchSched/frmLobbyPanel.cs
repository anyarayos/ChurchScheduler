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
            SetConnection("Church.db");
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        public frmLobbyPanel()
        {
            InitializeComponent();
        }

        private void frmLobbyPanel_Load(object sender, EventArgs e)
        {
            // when LobbyPanel form loads, update the data grid view from the UserInfo table
            // query to show data ("SELECT * FROM UserInfo")
            SetConnection("Church.db");
            sql_con.Open();
            DB = new SQLiteDataAdapter("SELECT * FROM UserInfo", sql_con);
            DB.Fill(DT);
            dgvRequestees.DataSource = DT;
            sql_con.Close();

            tbcon1.TabPages.Remove(tbReservation);

            populateWEvents(cmbEvents);//Populates comboboxes wag tanggalin please lng
            populateWTime(cmbTime);
            cmbEvents.SelectedIndex = 0;//Wag rin mga to 
            cmbTime.SelectedIndex = 0;//
        }

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

        private void btnConfirmRequestee_Click(object sender, EventArgs e)
        {
            //if(all fields !empty)
            //	if(requestee !exists) //get username & email address then compare it
            //		//get the inputted values and store in database
            //	else
            //		print requestee already exists
            //else
            //print there are incomplete fields in your submission.
            //empty out the fields

            // sql connection with Church.db
             
            //dataGridViewExistingRequestees.DataSource = dt;  //populate mo yung datagrid ng existing duh
            //con.Close();

            // check if fields are complete
            bool fieldAreComplete = !(txtRequestName.Text == "" || txtContactNum.Text == "" || txtEmailAdd.Text == "" || txtAddress.Text == "");
            if (fieldAreComplete)
            {
                // sql connection with Church.db
                SetConnection("Church.db");

                // data table will have a row if query returns a record
                DB = new SQLiteDataAdapter("SELECT id FROM UserInfo WHERE name='" + txtRequestName.Text + "' OR email='" + txtEmailAdd.Text + "' OR contact='" + txtContactNum.Text + "'", sql_con);
                DT = new DataTable();
                DB.Fill(DT);

                // if data table returns a record, tell that the user exists
                bool userExists = DT.Rows.Count == 1;
                if (!userExists)
                {
                    // THIS IS THE QUERY USED TO INSERT VALUES INTO THE UserInfo TABLE
                    /*
                    string query = "INSERT INTO UserInfo (name, contact, email, address) VALUES ('" + txtRequestName.Text + "', '" + txtContactNum.Text + "', '" + txtEmailAdd.Text + "', '" + txtAddress.Text + "');";
                    ExecuteQuery(query);
                    */
                    MessageBox.Show("Success! New user created.");
                }
                else
                {
                    MessageBox.Show("User already exists!");
                }
            }
            else
            {
                MessageBox.Show("There are incomplete fields in your submission.");
            }
        }

        private void btnEditrequestee_Click(object sender, EventArgs e)
        {
            //update existing data using whatever was changed in the field
        }

        private void btnCancelRequestee_Click(object sender, EventArgs e)
        {
            //delete highlighted 
        }

        private void btnClearRequestee_Click(object sender, EventArgs e)
        {
            txtRequestName.Clear();
            txtContactNum.Clear();
            txtEmailAdd.Clear();
            txtAddress.Clear();
        }
        DataGridViewRow selectedRow;

        private void dgvRequestees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            selectedRow = dgvRequestees.Rows[index];
            txtRequestName.Text = selectedRow.Cells[1].Value.ToString();
            txtContactNum.Text = selectedRow.Cells[2].Value.ToString();
            txtEmailAdd.Text = selectedRow.Cells[3].Value.ToString();
            txtAddress.Text = selectedRow.Cells[4].Value.ToString();
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
        private void populateWEvents(ComboBox combobox)
        {
            String[] events = { "Wedding", "Baptism", "Confirmation", "Mass" };
            foreach (string ev in events)
            {
                combobox.Items.Add(ev);
            }
        }
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

        private void cmbEvents_SelectedIndexChanged(object sender, EventArgs e)//Hide/Show Attendees according to event
        {

            if (cmbEvents.SelectedItem.ToString()=="Wedding")
            {
                lblAttendee1.Text = "Groom:";
                lblAttendee2.Text = "Bride:";
                lblAttendee2.Visible = true;
                txtAttendee2.Visible = true;
                //Change dgv
            }
            else if(cmbEvents.SelectedItem.ToString() == "Baptism")
            {
                lblAttendee1.Text = "Candidate:";
                lblAttendee2.Visible = false;
                txtAttendee2.Visible = false;
                //Change dgv
            }
            else if (cmbEvents.SelectedItem.ToString() == "Confirmation")
            {
                lblAttendee1.Text = "Confirmand:";
                lblAttendee2.Visible = false;
                txtAttendee2.Visible = false;
                //Change dgv
            }
            else
            {
                lblAttendee1.Text = "Purpose:";
                lblAttendee2.Visible = false;
                txtAttendee2.Visible = false;
                //Change dgv
            }
        }
    }
}
