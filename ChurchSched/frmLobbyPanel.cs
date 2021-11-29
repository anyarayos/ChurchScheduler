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

        // REQUESTEE PANEL ================================================

        /* REQUESTEE PANEL VARIABLES ================================================
        
        requesteeSelectedRow
        - the selected row from the requestee data grid view

        requesteeSelectedRowID
        - holds the user id of the selected requestee from the data grid view

        userIDAndName
        - holds the user id and name used for the reservation panel
        - Ex:(1_Mark L. Bargamento)

         */
        
        DataGridViewRow requesteeSelectedRow;
        int selectedUserID;
        string userIDAndName;

        /* REQUESTEE PANEL METHODS ================================================

        LoadUserInfoDgvRequestee()
        - loads UserInfo data into dgvRequestee

        PopulateSelectedRequestee()
        - populate textboxes with requestee's data grid view's selected row's values

        ClearRequesteeTextBoxes()
        - clears textboxes of requestee panel

        CheckIfUserExists(email, contact)
        - check if the user already exists
        - returns true or false

        InsertNewUserInfo(name, contact, email, address)
        - inserts new user info

        UpdateUserInfo(id, name, contact, email, address)
        - updates user info

         */

        private void LoadUserInfoDgvRequestee()
        {
            // UserInfo data table
            DB = new SQLiteDataAdapter("SELECT * FROM UserInfo", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            dgvRequestees.DataSource = DT;
            
            // id column width
            dgvRequestees.Columns[0].Width = 50;
												// name and email column width
            dgvRequestees.Columns[1].Width = 150;
            dgvRequestees.Columns[3].Width = 150;
            // address column width
            dgvRequestees.Columns[4].Width = 400;
        }
        private void PopulateSelectedRequestee()
        {
            txtRequestName.Text = requesteeSelectedRow.Cells[1].Value.ToString();
            txtContactNum.Text = requesteeSelectedRow.Cells[2].Value.ToString();
            txtEmailAdd.Text = requesteeSelectedRow.Cells[3].Value.ToString();
            txtAddress.Text = requesteeSelectedRow.Cells[4].Value.ToString();
        }
        private void ClearRequesteeTextBoxes()
        {
            selectedUserID = Convert.ToInt32(null);
            txtRequestName.Clear();
            txtContactNum.Clear();
            txtEmailAdd.Clear();
            txtAddress.Clear();
        }
        private bool CheckIfUserExists(string email, string contact)
        {
            // data table will have a row if query returns a record
            DB = new SQLiteDataAdapter("SELECT id FROM UserInfo WHERE  email='" + email + "' OR contact='" + contact + "'", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            
            // if data table returns a record, user exists
            return DT.Rows.Count == 1;
        }
        private void InsertNewUserInfo(string name, string contact, string email, string address)
        {
            string SQLiteQuery = "INSERT INTO UserInfo (name, contact, email, address) VALUES ('" + name + "', '" + contact + "', '" + email + "', '" + address + "');";
            ExecuteQuery(SQLiteQuery);
        }
        private void UpdateUserInfo(int id, string name, string contact, string email, string address)
        {
            string SQLiteQuery = "UPDATE UserInfo SET name='" + name + "', contact='" + contact + "', email='" + email + "', address='" + address + "' WHERE Id='" + id + "'";
            ExecuteQuery(SQLiteQuery);
        }

        /* REQUESTEE PANEL EVENTS ================================================

        DataGridView Requestees = DONE

        Button Confirm Requestee = DONE
        Button Edit Requestee = DONE
        Button Delete Requestee = DONE
        Button Clear Requestee = DONE

        TextBox Search Requestee = WIP

         */

        private void dgvRequestees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // show the reservation tab on first selection
            if (tabControl.TabPages.Contains(tbReservation) == false)
            {
                tabControl.TabPages.Remove(tbAllReserve);
                tabControl.TabPages.Remove(tbPastEvents);
                tabControl.TabPages.Add(tbReservation);
                tabControl.TabPages.Add(tbAllReserve);
                tabControl.TabPages.Add(tbPastEvents);
            }

            // data grid view row index
            int index = e.RowIndex;
            requesteeSelectedRow = dgvRequestees.Rows[index];

            // set requestee selected row id
            selectedUserID = Convert.ToInt32(requesteeSelectedRow.Cells[0].Value);

            // populate textboxes with requestee's data grid view's selected row's value
            PopulateSelectedRequestee();

            // selected user for reservation panel
            userIDAndName = selectedUserID.ToString() + "_" + requesteeSelectedRow.Cells[1].Value.ToString();
            txtIDNameReserve.Text = userIDAndName;
        }
        private void btnConfirmRequestee_Click(object sender, EventArgs e)
        {
            // check if textboxes are filled
            bool textBoxesFilled = !(txtRequestName.Text == "" || txtContactNum.Text == "" || txtEmailAdd.Text == "" || txtAddress.Text == "");

            // insert new user info if text boxes are filled and no user duplication
            if (textBoxesFilled && !CheckIfUserExists(txtEmailAdd.Text, txtContactNum.Text))
            {
                // insert new user info
                InsertNewUserInfo(txtRequestName.Text, txtContactNum.Text, txtEmailAdd.Text, txtAddress.Text);
                // refresh requestee data grid view
                LoadUserInfoDgvRequestee();

                MessageBox.Show("New requestee added.");
            }
            // filled but has user duplication
            else if (textBoxesFilled && CheckIfUserExists(txtEmailAdd.Text, txtContactNum.Text))
            {
                MessageBox.Show("Requestee already exists.");
            }
            // text boxes incomplete
            else
            {
                MessageBox.Show("Incomplete submission, complete and try again.");
            }
        }
        private void btnEditrequestee_Click(object sender, EventArgs e)
        {
            if (selectedUserID > 0)
            {
                // message box edit confirmation
                DialogResult confirmEdit = MessageBox.Show(
                    // message box message
                    "Are you sure to edit user id: " + selectedUserID + " with the following values?\n" +
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
                    UpdateUserInfo(selectedUserID, txtRequestName.Text, txtContactNum.Text, txtEmailAdd.Text, txtAddress.Text);
                    // refresh requestee data grid view
                    LoadUserInfoDgvRequestee();

                    MessageBox.Show("User info successfully updated.");
																}
            }
            else
            {
                MessageBox.Show("No user selected.");
            }
        }
        private void btnDelRequestee_Click(object sender, EventArgs e)
        {
            if (selectedUserID > 0)
            {
                // populate textboxes with requestee's data grid view's selected row's value
                // (incase changes were made after selecting row)
                PopulateSelectedRequestee();

                //delete highlighted 
                DialogResult dialogResult = MessageBox.Show(
                    // message box message
                    "Are you sure to delete this Requestee ???\n" +
                    "\nid: " + selectedUserID +
                    "\nname: " + requesteeSelectedRow.Cells[1].Value.ToString() +
                    "\ncontact: " + requesteeSelectedRow.Cells[2].Value.ToString() +
                    "\nemail: " + requesteeSelectedRow.Cells[3].Value.ToString() +
                    "\naddress: " + requesteeSelectedRow.Cells[4].Value.ToString(),
                    // message box title
                    "Data Deletion Warning !!!",
                    // message box buttons
                    MessageBoxButtons.YesNo
                );
                if (dialogResult == DialogResult.Yes)
                {
                    ExecuteQuery("DELETE FROM UserInfo WHERE Id='" + selectedUserID + "'");
                    LoadUserInfoDgvRequestee();
                    MessageBox.Show("Deleted");
                }
            }
            else
            {
                MessageBox.Show("No user selected.");
            }
        }
        private void btnClearRequestee_Click(object sender, EventArgs e)
        {
            ClearRequesteeTextBoxes();
            dgvRequestees.ClearSelection();
            tabControl.TabPages.Remove(tbReservation);
        }
        private void textSearchRequestee_TextChanged(object sender, EventArgs e)
        {
            DB = new SQLiteDataAdapter("SELECT * FROM UserInfo WHERE name LIKE '%" + textSearchRequestee.Text + "%' OR contact LIKE '%" + textSearchRequestee.Text + "%' OR email LIKE '%" + textSearchRequestee.Text + "%'", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            dgvRequestees.DataSource = DT;
        }

        // RESERVATION PANEL ================================================

        /* RESERVATION PANEL VARIABLES ================================================

        currentEventSelected
        - 0 = None
        - 1 = Wedding
        - 2 = Baptism
        - 3 = Confirmation
        - 4 = Mass

        weddingRequirements
        baptismRequirements
        confirmationRequirements
        - for requirements list view

         */

        int userID;
        int currentEventSelected = 1;
        string[] weddingRequirements = {
                "Marriage License",
                "Baptismal certificate (Groom)",
                "Baptismal certificate (Bride)",
                "Confirmation certificate (Groom)",
                "Confirmation certificate (Bride)",
                "Birth certificate (Groom)",
                "Birth certificate (Bride)",
                "CENOMAR (Groom)",
                "CENOMAR (Bride)",
                "Marriage preparation Seminar",
                "Canonical interview",
                "Marriage Banns",
                "Confession"
            };
        string[] baptismRequirements = {
                "Birth certificate (Candidate)",
                "Marriage certificate (Parents)"
            };
        string[] confirmationRequirements = {
                "Baptismal certificate (Confirmand)",
                "Seminar Attendance (Confirmand)"
            };

        /* RESERVATION PANEL METHODS ================================================
        
        PopulateComboBoxTime(combobox)
        - populate combo box with time

         */

        private void PopulateComboBoxTime(ComboBox combobox)
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

        private void LoadPrice()
        {
            DB = new SQLiteDataAdapter("SELECT price FROM Prices WHERE price_id='" + currentEventSelected + "'", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            txtAmountToBePaid.Text = DT.Rows[0][0].ToString();
        }

        private void LoadReservationsDgvReservations()
								{
            switch (cmbEvents.SelectedItem.ToString())
            {
                case "Wedding":
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id, date, time, type, bride, groom, is_cancelled, mode_of_payment_id, balance"  +
                        "FROM Reservations " +
                        "INNER JOIN Wedding " +
                        "ON Reservations.reservation_id = Wedding.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Baptism":
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id, date, time, type, candidate, is_cancelled, mode_of_payment_id, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Baptization " +
                        "ON Reservations.reservation_id = Baptization.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Confirmation":
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id, date, time, type, confirmand, is_cancelled, mode_of_payment_id, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Confirmation " +
                        "ON Reservations.reservation_id = Confirmation.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Mass":
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id, date, time, type, purpose, is_cancelled, mode_of_payment_id, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Mass " +
                        "ON Reservations.reservation_id = Mass.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id" +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
            }
            DT = new DataTable();
            DB.Fill(DT);
            dgvReservations.DataSource = DT;
        }

        /* RESERVATION PANEL EVENTS ================================================
        
        ComboBox Events = WIP

        Button Confirm Reservation = WIP
        Button Cancel Reservation = WIP

         */

        private void cmbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEvents.SelectedItem.ToString())
            {
                case "Wedding":
                    lblAttendee1.Text = "Groom:";
                    lblAttendee2.Text = "Bride:";
                    lblAttendee2.Visible = true;
                    txtAttendee2.Visible = true;
                    currentEventSelected = 1;
                    listBoxRequirements.Items.Clear();
                    listBoxRequirements.Items.AddRange(weddingRequirements);
                    break;
                case "Baptism":
                    lblAttendee1.Text = "Candidate:";
                    lblAttendee2.Visible = false;
                    txtAttendee2.Visible = false;
                    currentEventSelected = 2;
                    listBoxRequirements.Items.Clear();
                    listBoxRequirements.Items.AddRange(baptismRequirements);
                    break;
                case "Confirmation":
                    lblAttendee1.Text = "Confirmand:";
                    lblAttendee2.Visible = false;
                    txtAttendee2.Visible = false;
                    currentEventSelected = 3;
                    listBoxRequirements.Items.Clear();
                    listBoxRequirements.Items.AddRange(confirmationRequirements);
                    break;
                case "Mass":
                    lblAttendee1.Text = "Purpose:";
                    lblAttendee2.Visible = false;
                    txtAttendee2.Visible = false;
                    currentEventSelected = 4;
                    listBoxRequirements.Items.Clear();
                    break;
            }
            LoadPrice();
            LoadReservationsDgvReservations();
        }
        private void btnConfirmReserve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IMPORTANT! \n \n \n \nMake sure to make full Payment 2 two (2) months before the reserve date. \n \nOtherwise, the reservation sill be forfeited", "Your Reservation is Successful!");
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

        // UPCOMING EVENTS PANEL ================================================

        /* UPCOMING EVENTS PANEL VARIABLES ================================================
         */

        /* UPCOMING EVENTS PANEL METHODS ================================================
         */

        /* UPCOMING EVENTS PANEL EVENTS ================================================
         */

        // PAST EVENTS PANEL ================================================

        /* PAST EVENTS PANEL VARIABLES ================================================
         */

        /* PAST EVENTS PANEL METHODS ================================================
         */

        /* PAST EVENTS PANEL EVENTS ================================================
         */

        // LOBBY PANEL FORM METHODS ================================================

        private int adminID;//instance variable na to ng frmLobby eto 

        public frmLobbyPanel()
        {
            InitializeComponent();
        }
        public frmLobbyPanel(int adminID)//call this on frmAdminLogin
        {
            InitializeComponent();
            //wag tanggalin kasi magtotopak lahat gago subukan mo
            // tangina mo paano pag tinanggal ko kasi trip ko lng bumagsak tayo haha
            this.adminID = adminID;
        }
        private void frmLobbyPanel_Load(object sender, EventArgs e)
        {
            // establish connection to church database
            SetConnection("Church.db");

            // REQUESTEE PANEL ================
            // hide reservation tab
            tabControl.TabPages.Remove(tbReservation);
            // load UserInfo into requestee data grid view
            LoadUserInfoDgvRequestee();

            // RESERVATION PANEL ================
            // populate comboboxes with time
            PopulateComboBoxTime(cmbTime);
            // default selected index into 0
            cmbEvents.SelectedIndex = 0;
            cmbTime.SelectedIndex = 0;
            cmbPaymentMode.SelectedIndex = 0;
            
        }

        private void btnViewPast_Click(object sender, EventArgs e)
        {
            frmViewDetails view = new frmViewDetails();
            view.ShowDialog();
        }

        private void btnViewUpcoming_Click(object sender, EventArgs e)
        {
            frmViewDetails view = new frmViewDetails();
            view.ShowDialog();
        }
    }
}
