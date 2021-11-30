using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Linq;
using System.Globalization;

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

            // load reservations data table on dgv reservations for convenience
            LoadReservationsDgvReservations();

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
                    //if textboxes are all filled ANDD (email address or contact number doesn't match existing)
                    // update user info
                    UpdateUserInfo(selectedUserID, txtRequestName.Text, txtContactNum.Text, txtEmailAdd.Text, txtAddress.Text);
                    // refresh requestee data grid view
                    LoadUserInfoDgvRequestee();
                    MessageBox.Show("User info successfully updated.");

                    //else if textboxes are all filled ANDD (email address or contact number matches existing)
                    //Show "A requestee with the same email address or contact number already exists!"

                    //else
                    //Show "Incomplete submission, complete and try again."
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

        int currentEventSelected = 1;
        int selectedReservationID = 0;
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

        private void PopulateSelectedReservation()
        {
            cmbEvents.SelectedIndex = cmbEvents.FindStringExact(reservattionSelectedRow.Cells[3].Value.ToString());
            dtpDate.Value = DateTime.ParseExact(reservattionSelectedRow.Cells[1].Value.ToString(), "yyyy'/'MM'/'dd", CultureInfo.InvariantCulture);
            cmbTime.SelectedIndex = cmbTime.FindStringExact(reservattionSelectedRow.Cells[2].Value.ToString());
            txtAttendee1.Text = reservattionSelectedRow.Cells[4].Value.ToString();
            //Pakiayos yung position ni Groom sa database dapat mas nauuna siya kesa kay bride thanks
            //Paano pag ayaw ko kasi ladies first
            if (currentEventSelected == 1)
            {
                //txtAttendee2.Text.Cells[5].Value.ToString();//Fix the position of Bride tulad ng sabi ko para gumana to
                //Ayaw
                cmbPaymentMode.SelectedIndex = cmbPaymentMode.FindStringExact(reservattionSelectedRow.Cells[7].Value.ToString());
                txtPaymentAmount.Text = reservattionSelectedRow.Cells[8].Value.ToString();
            }
            else
            {
                cmbPaymentMode.SelectedIndex = cmbPaymentMode.FindStringExact(reservattionSelectedRow.Cells[6].Value.ToString());
                txtPaymentAmount.Text = reservattionSelectedRow.Cells[7].Value.ToString();
            }
        }
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
        private int CheckModeOfPayment()
        {
            switch (cmbPaymentMode.SelectedItem.ToString())
            {
                case "Gcash/Paypal":
                    return 1;
                case "Debit/Credit Card":
                    return 2;
                case "Cash Payment":
                    return 3;
                default:
                    return 0;
            }
        }
        private void LoadReservationsDgvReservations()
								{
            switch (cmbEvents.SelectedItem.ToString())
            {
                case "Wedding":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, bride, groom, is_cancelled, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Wedding " +
                        "ON Reservations.reservation_id = Wedding.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "INNER JOIN ModeOfPayments " +
                        "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Baptism":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, candidate, is_cancelled, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Baptism " +
                        "ON Reservations.reservation_id = Baptism.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "INNER JOIN ModeOfPayments " +
                        "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Confirmation":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, confirmand, is_cancelled, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Confirmation " +
                        "ON Reservations.reservation_id = Confirmation.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "INNER JOIN ModeOfPayments " +
                        "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Mass":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, purpose, is_cancelled, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Mass " +
                        "ON Reservations.reservation_id = Mass.id " +
                        "INNER JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "INNER JOIN ModeOfPayments " +
                        "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
            }
            DT = new DataTable();
            DB.Fill(DT);
            dgvReservations.DataSource = DT;
        }
        private bool CheckDateOrTimeConflict(string date, string time)
        {
            // data table will have a row if query returns a record
            DB = new SQLiteDataAdapter("SELECT reservation_id FROM Reservations WHERE date='" + date + "' OR time='" + time + "';", sql_con);
            DT = new DataTable();
            DB.Fill(DT);

            // if data table returns a record, user exists
            return DT.Rows.Count == 1;
        }

        // USE THIS METHOD IF YOU WANT TO INSERT NEW RESERVATION
        // txt.Attendee2.Text WILL STILL RECIEVED BUT WONT BE USED IF THE EVENT ISNT RELATING TO WEDDING
        // InsertNewReservation(currentAdminID, selectedUserID, cmbEvents.SelectedItem.ToString(), dtpDate.Value.ToString(), cmbTime.SelectedItem.ToString(), txtAttendee1.Text, txtAttendee2.Text, CheckModeOfPayment(),Convert.ToDouble(txtPaymentAmount.Text));
        private void InsertNewReservation(int adminID, int userID, string massEvent, string date, string time, string attendee1, string attendee2, int modeOfPaymentID, double paymentAmount)
								{
            string SQLiteQuery;
            int reservationID;
            switch (massEvent)
            {
                case "Wedding":
                    // insert reservation query
                    SQLiteQuery = "INSERT INTO Reservations(admin_id, user_id, type, date, time, is_cancelled) " +
                    "VALUES(" + adminID + ", " + userID + ", '" + massEvent + "', '" + date + "', '" + time + "', 0);";
                    ExecuteQuery(SQLiteQuery);
                    
                    // find the inserted reservation id
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id " +
                        "FROM Reservations " +
                        "WHERE " +
                        "admin_id=" + adminID + " AND " +
                        "user_id=" + userID + " AND " +
                        "type = '" + massEvent + "' AND " +
                        "date='" + date + "' AND " +
                        "time='" + time + "' AND " +
                        "is_cancelled = 0;"
                        , sql_con
                    );
                    DT = new DataTable();
                    DB.Fill(DT);
                    
                    // holds the reservation id of previous query
                    reservationID = Convert.ToInt32(DT.Rows[0][0]);

                    // insert event query relating to reservation
                    SQLiteQuery = "INSERT INTO Wedding(id, bride, groom) " +
                    "VALUES(" + reservationID + ", '" + attendee1 + "', '" + attendee2 + "');";
                    ExecuteQuery(SQLiteQuery);

                    // insert payment query for the reservation
                    SQLiteQuery = "INSERT INTO Payments(reservation_id, price_id, mode_of_payment_id, balance) " +
                    "VALUES(" + reservationID + ", 1, " + modeOfPaymentID + ", " + paymentAmount + ");";
                    break;
                
                case "Baptism":
                    // insert reservation query
                    SQLiteQuery = "INSERT INTO Reservations(admin_id, user_id, type, date, time, is_cancelled) " +
                    "VALUES(" + adminID + ", " + userID + ", '" + massEvent + "', '" + date + "', '" + time + "', 0);";
                    ExecuteQuery(SQLiteQuery);

                    // find the inserted reservation id
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id " +
                        "FROM Reservations " +
                        "WHERE " +
                        "admin_id=" + adminID + " AND " +
                        "user_id=" + userID + " AND " +
                        "type = '" + massEvent + "' AND " +
                        "date='" + date + "' AND " +
                        "time='" + time + "' AND " +
                        "is_cancelled = 0;"
                        , sql_con
                    );
                    DT = new DataTable();
                    DB.Fill(DT);

                    // holds the reservation id of previous query
                    reservationID = Convert.ToInt32(DT.Rows[0][0]);

                    // insert event query relating to reservation
                    SQLiteQuery = "INSERT INTO Baptism(id, candidate) " +
                    "VALUES(" + reservationID + ", '" + attendee1 + "');";
                    ExecuteQuery(SQLiteQuery);

                    // insert payment query for the reservation
                    SQLiteQuery = "INSERT INTO Payments(reservation_id, price_id, mode_of_payment_id, balance) " +
                    "VALUES(" + reservationID + ", 2, " + modeOfPaymentID + ", " + paymentAmount + ");";
                    break;
                case "Confirmation":
                    // insert reservation query
                    SQLiteQuery = "INSERT INTO Reservations(admin_id, user_id, type, date, time, is_cancelled) " +
                    "VALUES(" + adminID + ", " + userID + ", '" + massEvent + "', '" + date + "', '" + time + "', 0);";
                    ExecuteQuery(SQLiteQuery);

                    // find the inserted reservation id
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id " +
                        "FROM Reservations " +
                        "WHERE " +
                        "admin_id=" + adminID + " AND " +
                        "user_id=" + userID + " AND " +
                        "type = '" + massEvent + "' AND " +
                        "date='" + date + "' AND " +
                        "time='" + time + "' AND " +
                        "is_cancelled = 0;"
                        , sql_con
                    );
                    DT = new DataTable();
                    DB.Fill(DT);

                    // holds the reservation id of previous query
                    reservationID = Convert.ToInt32(DT.Rows[0][0]);

                    // insert event query relating to reservation
                    SQLiteQuery = "INSERT INTO Confirmation(id, confirmand) " +
                    "VALUES(" + reservationID + ", '" + attendee1 + "');";
                    ExecuteQuery(SQLiteQuery);

                    // insert payment query for the reservation
                    SQLiteQuery = "INSERT INTO Payments(reservation_id, price_id, mode_of_payment_id, balance) " +
                    "VALUES(" + reservationID + ", 3, " + modeOfPaymentID + ", " + paymentAmount + ");";
                    break;
                case "Mass":
                    // insert reservation query
                    SQLiteQuery = "INSERT INTO Reservations(admin_id, user_id, type, date, time, is_cancelled) " +
                    "VALUES(" + adminID + ", " + userID + ", '" + massEvent + "', '" + date + "', '" + time + "', 0);";
                    ExecuteQuery(SQLiteQuery);

                    // find the inserted reservation id
                    DB = new SQLiteDataAdapter(
                        "SELECT reservation_id " +
                        "FROM Reservations " +
                        "WHERE " +
                        "admin_id=" + adminID + " AND " +
                        "user_id=" + userID + " AND " +
                        "type = '" + massEvent + "' AND " +
                        "date='" + date + "' AND " +
                        "time='" + time + "' AND " +
                        "is_cancelled = 0;"
                        , sql_con
                    );
                    DT = new DataTable();
                    DB.Fill(DT);

                    // holds the reservation id of previous query
                    reservationID = Convert.ToInt32(DT.Rows[0][0]);

                    // insert event query relating to reservation
                    SQLiteQuery = "INSERT INTO Mass(id, purpose) " +
                    "VALUES(" + reservationID + ", '" + attendee1 + "');";
                    ExecuteQuery(SQLiteQuery);

                    // insert payment query for the reservation
                    SQLiteQuery = "INSERT INTO Payments(reservation_id, price_id, mode_of_payment_id, balance) " +
                    "VALUES(" + reservationID + ", 4, " + modeOfPaymentID + ", " + paymentAmount + ");";
                    break;
            }
            
        }

        // UpdateReservation(selectedReservationID, currentAdminID, selectedUserID, cmbEvents.SelectedItem.ToString(), dtpDate.Value.ToString(), cmbTime.SelectedItem.ToString(), txtAttendee1.Text, txtAttendee2.Text, CheckModeOfPayment(),Convert.ToDouble(txtPaymentAmount.Text));
        private void UpdateReservation(int reservationID, int adminID, int userID, string massEvent, string date, string time, string attendee1, string attendee2, int modeOfPaymentID, double paymentAmount)
								{
            string SQLiteQuery;
            switch (massEvent)
            {
                case "Wedding":
                    // update reservation query
                    SQLiteQuery = "UPDATE Reservations SET admin_id='" + adminID + "', date='" + date + "', time='" + time + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);
                    
                    // update event query
                    SQLiteQuery = "UPDATE Wedding SET bride='" + attendee1 + "', groom='" + attendee2 + "' WHERE id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);
                    
                    // update payment query
                    SQLiteQuery = "UPDATE Payments SET mode_of_payment_id='" + modeOfPaymentID + "', balance='" + paymentAmount + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);
                    break;

                case "Baptism":
                    // update reservation query
                    SQLiteQuery = "UPDATE Reservations SET admin_id='" + adminID + "', date='" + date + "', time='" + time + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);

                    // update event query
                    SQLiteQuery = "UPDATE Wedding SET candidate='" + attendee1 + "' WHERE id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);

                    // update payment query
                    SQLiteQuery = "UPDATE Payments SET mode_of_payment_id='" + modeOfPaymentID + "', balance='" + paymentAmount + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);
                    break;
                case "Confirmation":
                    // update reservation query
                    SQLiteQuery = "UPDATE Reservations SET admin_id='" + adminID + "', date='" + date + "', time='" + time + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);

                    // update event query
                    SQLiteQuery = "UPDATE Confirmation SET confirmand='" + attendee1 + "' WHERE id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);

                    // update payment query
                    SQLiteQuery = "UPDATE Payments SET mode_of_payment_id='" + modeOfPaymentID + "', balance='" + paymentAmount + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);
                    break;
                case "Mass":
                    // update reservation query
                    SQLiteQuery = "UPDATE Reservations SET admin_id='" + adminID + "', date='" + date + "', time='" + time + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);

                    // update event query
                    SQLiteQuery = "UPDATE Confirmation SET purpose='" + attendee1 + "' WHERE id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);

                    // update payment query
                    SQLiteQuery = "UPDATE Payments SET mode_of_payment_id='" + modeOfPaymentID + "', balance='" + paymentAmount + "' WHERE reservation_id='" + reservationID + "'";
                    ExecuteQuery(SQLiteQuery);
                    break;
            }
        }

        /* RESERVATION PANEL EVENTS ================================================
        
        ComboBox Events = WIP
        Button Confirm Reservation = WIP
        Button Cancel Reservation = WIP

         */

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // data grid view row index
            int index = e.RowIndex;
            reservattionSelectedRow = dgvReservations.Rows[index];

            // populate textboxes with requestee's data grid view's selected row's value
            PopulateSelectedReservation();

            DB = new SQLiteDataAdapter(
                        "SELECT reservation_id " +
                        "FROM Reservations " +
                        "WHERE " +
                        "user_id=" + selectedUserID + " AND " +
                        "type = '" + cmbEvents.SelectedIndex + "' AND " +
                        "date='" + dtpDate.Value.ToString() + "' AND " +
                        "time='" + cmbTime.SelectedIndex.ToString() + "';"
                        , sql_con
                    );
            DT = new DataTable();
            DB.Fill(DT);

            // holds the reservation id of previous query
            selectedReservationID = Convert.ToInt32(DT.Rows[0][0]);
        }
        private void btnConfirmReserve_Click(object sender, EventArgs e)
        {
            // for wedding
            bool reservationTextBoxesFilledEvent1 =!(txtAttendee1.Text==""||txtAttendee2.Text==""||txtPaymentAmount.Text=="");
            // for the rest
            bool reservationTextBoxesFilledEvent2 =!(txtAttendee1.Text==""||txtPaymentAmount.Text=="");

            // check if there is no date or time conflict
												if (!CheckDateOrTimeConflict(dtpDate.Value.ToString(), cmbTime.SelectedItem.ToString()))
												{
																if (reservationTextBoxesFilledEvent1 || reservationTextBoxesFilledEvent2)
																{
                    InsertNewReservation(currentAdminID, selectedUserID, cmbEvents.SelectedItem.ToString(), dtpDate.Value.ToString(), cmbTime.SelectedItem.ToString(), txtAttendee1.Text, txtAttendee2.Text, CheckModeOfPayment(), Convert.ToDouble(txtPaymentAmount.Text));
																}
																else
																{
                    MessageBox.Show("Submission Incomplete, check and try again.");
                }
												}
												else
												{
                MessageBox.Show(
                    "There is already an existing reservation to your preferred date and time.\n" +
                    "Please select another date and time."
                );
            }
            LoadReservationsDgvReservations();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //==CANCEL LOGIC==
            //Check if there's a reservation selected
            //Populate textboxes of the reservation's data grid view's selected row value

            //Prompt a dialog box if the user really wants to cancel
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
            //if yes make isCancelled to true 

            //If no reservation selected PRINT No reservation selected.

        }
        private void btnEditReserve_Click(object sender, EventArgs e)
        {
            //==EDIT LOGIC==
            
            if ( selectedUserID > 0) {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit " + selectedUserID + " with the following values?\n" +
            "\nEvent: " + cmbEvents.SelectedItem.ToString() +
            "\nDate: " + dtpDate.Value.ToString() +
            "\nTime: " + cmbTime.SelectedItem.ToString() +
            "\nAttendee 1: " + txtAttendee1.Text +
             "\nAttendee 2: " + txtAttendee2.Text +
             "\nMode of Payment: " + cmbPaymentMode.SelectedItem.ToString() +
             "\nPayment Amount: " + txtPaymentAmount.Text, "Edit Confirmation",
                                MessageBoxButtons.YesNo);
                DialogResult confirmEdit = dialogResult;
                if (confirmEdit == DialogResult.Yes) {
                    //bool textBoxesFilledEvent1 =!(txtAttendee1.Text==""||txtAttendee2.Text==""||txtPaymentAmount.Text=="");\\For Wedding
                    //bool textBoxesFilledEvent2 =!(txtAttendee1.Text==""||txtPaymentAmount.Text=="");\\The Rest

                    // outermost IF checks the event type selected, then the next if will check kung puno textboxes na needed according to the event

                    //if(currentEventSelected==1) Check kung wedding type sinelect
                        //if(textBoxesFilledEvent1) txtattendee1 and txtattendee2 and txtpayment ichcheck
                            //if(date & time doesn't match any record)
                                 //UPDATE
                                 //
                            //else
                             //Print There is a reservation for the selected date and time. Please choose another.
                        //else
                        // Print Some of the fields are incomplete.
                   
                    //else Kung hindi si Wedding type sinelect
                        //if(textBoxesFilledEvent2) txtattendee1 and txtpayment ichcheck
                            ///if(date & time doesn't match any record)
                                ///UPDATE
                            /////else
                                //Print There is a reservation for the selected date and time. Please choose another.
                        //else
                        // Print Some of the fields are incomplete.
                    //
                    //}
                }
            }
            LoadReservationsDgvReservations();

            //bool textBoxesFilledEvent1 =!(txtAttendee1.Text==""||txtAttendee2.Text==""||txtPaymentAmount.Text=="");\\For Wedding
            //bool textBoxesFilledEvent2 =!(txtAttendee1.Text==""||txtPaymentAmount.Text=="");\\The Rest

            //if(user selected something from the dgv){
            //DialogResult confirmEdit = MessageBox.Show(
            // message box message
            //"Are you sure you want to edit " + selectedReservationID + " with the following values?\n" +
            //"\nEvent: " + cmbEvents.SelectedItem.ToString() +
            //"\nDate: " + dtpDate.Value.ToString() +
            //"\nTime: " + cmbTime.SelectedItem.ToString() +
            //"\nAttendee 1: " + txtAttendee1.Text;
            //"\nAttendee 2: " + txtAttendee2.Text;
            //"\nMode of Payment: " + cmbPaymentMode.SelectedItem.ToString();
            //"\nPayment Amount: " + txtPaymentAmount.Text,
            // message box title
            //"Edit Confirmation",
            // message box buttons
            //MessageBoxButtons.YesNo
            //);
            //if(confirmEdit == DialogResult.Yes)
            //														{
                // CHECK MUNA IF ALL TEXTBOXES ARE FILLED
                //if(currentEventSelected==1)\\ May additional na isang textbox kasi si Wedding
                    //if(textBoxesFilledEvent1){
                    //  if(date & time doesn't match any record){
                        //  UPDATE}
                    //}
                //else
                    //if(textBoxesFilledEvent2{
                    ////  if(date & time doesn't match any record){
                        //  UPDATE}
                    //}               
            // refresh reservations data grid view
            //MessageBox.Show("Reservations successfully updated.");
            //													}
            //}
            //else{
            //PRINT "No user selected."
            //}
        }
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
        DataGridViewRow reservattionSelectedRow;

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

        private int currentAdminID;//instance variable na to ng frmLobby eto 

        public frmLobbyPanel()
        {
            InitializeComponent();
        }
        public frmLobbyPanel(int adminID)//call this on frmAdminLogin
        {
            InitializeComponent();
            //wag tanggalin kasi magtotopak lahat gago subukan mo
            // tangina mo paano pag tinanggal ko kasi trip ko lng bumagsak tayo haha
            this.currentAdminID = adminID;
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
