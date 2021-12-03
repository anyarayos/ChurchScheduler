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
using System.Collections;
using System.Runtime.InteropServices;//Very Important, Copy this

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

        CheckIfUserExistsEdit(email, contact, userID)
        - check if any other user has the same values of the edited values for the current user
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
        private bool CheckIfUserExistsEdit(string email, string contact, int userID)
        {
            // data table will have a row if query returns a record
            DB = new SQLiteDataAdapter("SELECT id FROM UserInfo WHERE (email='" + email + "' OR contact='" + contact + "') AND NOT id='" + userID + "'; ", sql_con);
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
            try
            {
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
            catch
            {

            }
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
            LoadUserInfoDgvRequestee();
            LoadReservationsDgvReservations();
            LoadUpcomingEventsOnDGV();
            LoadPastEventsOnDGV();

        }
        private void btnEditRequestee_Click(object sender, EventArgs e)
        {
            bool textBoxesFilled = !(txtRequestName.Text == "" || txtContactNum.Text == "" || txtEmailAdd.Text == "" || txtAddress.Text == "");
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
                if (confirmEdit == DialogResult.Yes)
                {
                    if (textBoxesFilled && !CheckIfUserExistsEdit(txtEmailAdd.Text, txtContactNum.Text, selectedUserID))
                    {
                        UpdateUserInfo(selectedUserID, txtRequestName.Text, txtContactNum.Text, txtEmailAdd.Text, txtAddress.Text);
                        MessageBox.Show("Requestee's information successfully updated.");
                    }
                    else if (textBoxesFilled && CheckIfUserExistsEdit(txtEmailAdd.Text, txtContactNum.Text, selectedUserID))
                    {
                        MessageBox.Show("Requestee already existed.");
                    }
                    else
                    {
                        MessageBox.Show("Incomplete Submission. \nPlease fill out all fields and try again.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Requestee selected.");
            }
            LoadUserInfoDgvRequestee();
            LoadReservationsDgvReservations();
            LoadUpcomingEventsOnDGV();
            LoadPastEventsOnDGV();
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
                    MessageBox.Show("Deleted");
                }
            }
            else
            {
                MessageBox.Show("No user selected.");
            }
            LoadUserInfoDgvRequestee();
            LoadReservationsDgvReservations();
            LoadUpcomingEventsOnDGV();
            LoadPastEventsOnDGV();
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
        
        reservationSelectedRow
        - holds the values of the selected row

        currentEventSelected
        - 0 = None
        - 1 = Wedding
        - 2 = Baptism
        - 3 = Confirmation
        - 4 = Mass

        selectedReservationID
        - holds the reservation_id of the selected reservation row
        
        weddingRequirements
        baptismRequirements
        confirmationRequirements
        - for requirements list view

         */

        DataGridViewRow reservationSelectedRow;
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

        private void LoadReservationsDgvReservations()
        {
            switch (cmbEvents.SelectedItem.ToString())
            {
                case "Wedding":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, is_cancelled, groom, bride, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Wedding " +
                        "ON Reservations.reservation_id = Wedding.id " +
                        "LEFT JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "LEFT JOIN ModeOfPayments " +
                        "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Baptism":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, is_cancelled, candidate, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Baptism " +
                        "ON Reservations.reservation_id = Baptism.id " +
                        "LEFT JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "LEFT JOIN ModeOfPayments " +
                        "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Confirmation":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, is_cancelled, confirmand, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Confirmation " +
                        "ON Reservations.reservation_id = Confirmation.id " +
                        "LEFT JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "LEFT JOIN ModeOfPayments " +
                        "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                        "WHERE Reservations.user_id =" + selectedUserID + ";"
                        , sql_con
                    );
                    break;
                case "Mass":
                    DB = new SQLiteDataAdapter(
                        "SELECT Reservations.reservation_id, date, time, type, is_cancelled, purpose, ModeOfPayments.mode_of_payment, balance " +
                        "FROM Reservations " +
                        "INNER JOIN Mass " +
                        "ON Reservations.reservation_id = Mass.id " +
                        "LEFT JOIN Payments " +
                        "ON Reservations.reservation_id = Payments.reservation_id " +
                        "LEFT JOIN ModeOfPayments " +
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
        private void PopulateSelectedReservation()
        {
            cmbEvents.SelectedIndex = cmbEvents.FindStringExact(reservationSelectedRow.Cells[3].Value.ToString());
            dtpDate.Value = DateTime.ParseExact(reservationSelectedRow.Cells[1].Value.ToString(), "yyyy'/'MM'/'dd", CultureInfo.InvariantCulture);
            cmbTime.SelectedIndex = cmbTime.FindStringExact(reservationSelectedRow.Cells[2].Value.ToString());
            // first text box
            txtAttendee1.Text = reservationSelectedRow.Cells[5].Value.ToString();
            // if has second text box then move index further
            if (currentEventSelected == 1)
            {
                txtAttendee2.Text = reservationSelectedRow.Cells[6].Value.ToString();
                //Ayaw //bahalakajan
                cmbPaymentMode.SelectedIndex = cmbPaymentMode.FindStringExact(reservationSelectedRow.Cells[7].Value.ToString());
                txtPaymentAmount.Text = reservationSelectedRow.Cells[8].Value.ToString();
            }
            else
            {
                cmbPaymentMode.SelectedIndex = cmbPaymentMode.FindStringExact(reservationSelectedRow.Cells[6].Value.ToString());
                txtPaymentAmount.Text = reservationSelectedRow.Cells[7].Value.ToString();
            }
        }
        private void PopulateComboBoxTime(ComboBox combobox)
        {
            ArrayList timeIntervals = new ArrayList();
            var item = DateTime.Today.AddHours(7);
            while (item <= DateTime.Today.AddHours(15))
            {
                string format = item.ToString("hh:mm tt") + " - " + item.AddMinutes(120).ToString("hh:mm tt");
                timeIntervals.Add(format.ToUpper());
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
        private void ClearTextBoxes()
								{
            txtAttendee1.Text = "";
            txtAttendee2.Text = "";
            txtPaymentAmount.Text = "";
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
        private bool CheckEnoughPaymentAmount(int price, int payment)
								{
            return (payment <= price) && (payment > 0);
								}
        private bool CheckDateOrTimeConflict(string date, string time)
        {
            // data table will have a row if query returns a record
            DB = new SQLiteDataAdapter("SELECT reservation_id FROM Reservations WHERE date='" + date + "' AND time='" + time + "';", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            // if data table returns a record, user exists
            return DT.Rows.Count == 1;
        }
        private bool CheckDateOrTimeConflictEdit(string date, string time, int reservationID)
        {
            // data table will have a row if query returns a record
            DB = new SQLiteDataAdapter("SELECT reservation_id FROM Reservations WHERE date='" + date + "' AND time='" + time + "' AND NOT reservation_id='" + reservationID + "';", sql_con);
            DT = new DataTable();
            DB.Fill(DT);
            // if data table returns a record, user exists
            return DT.Rows.Count == 1;
        }
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
                    SQLiteQuery = "INSERT INTO Wedding(id, groom, bride) " +
                    "VALUES(" + reservationID + ", '" + attendee1 + "', '" + attendee2 + "');";
                    ExecuteQuery(SQLiteQuery);

                    // insert payment query for the reservation
                    SQLiteQuery = "INSERT INTO Payments(reservation_id, price_id, mode_of_payment_id, balance) " +
                    "VALUES(" + reservationID + ", 1, " + modeOfPaymentID + ", " + paymentAmount + ");";
                    ExecuteQuery(SQLiteQuery);
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
                    ExecuteQuery(SQLiteQuery);
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
                    ExecuteQuery(SQLiteQuery);
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
                    ExecuteQuery(SQLiteQuery);
                    break;
            }
        }
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
                    SQLiteQuery = "UPDATE Wedding SET groom='" + attendee1 + "', bride='" + attendee2 + "' WHERE id='" + reservationID + "'";
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
                    SQLiteQuery = "UPDATE Baptism SET candidate='" + attendee1 + "' WHERE id='" + reservationID + "'";
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
                    SQLiteQuery = "UPDATE Mass SET purpose='" + attendee1 + "' WHERE id='" + reservationID + "'";
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
            try
            {
                // data grid view row index
                int index = e.RowIndex;
                reservationSelectedRow = dgvReservations.Rows[index];
                // populate textboxes with requestee's data grid view's selected row's value
                PopulateSelectedReservation();

                // holds the reservation id of previous query
                selectedReservationID = Convert.ToInt32(reservationSelectedRow.Cells[0].Value);
            }
            catch { }
        }
        private void btnConfirmReserve_Click(object sender, EventArgs e)
        {
            // for wedding
            bool reservationTextBoxesFilledEvent1 = !(txtAttendee1.Text == "" || txtAttendee2.Text == "" || txtPaymentAmount.Text == "");
            // for the rest
            bool reservationTextBoxesFilledEvent2 = !(txtAttendee1.Text == "" || txtPaymentAmount.Text == "");

            bool hasReservationID = selectedReservationID > 0;

            if (hasReservationID)
            {
                // check if there is no date or time conflict
                if (!CheckDateOrTimeConflict(dtpDate.Value.ToString("yyyy/MM/dd"), cmbTime.SelectedItem.ToString()))
                {
                    if (reservationTextBoxesFilledEvent1 || reservationTextBoxesFilledEvent2)
                    {
                        if (CheckEnoughPaymentAmount(Convert.ToInt32(txtAmountToBePaid.Text), Convert.ToInt32(txtPaymentAmount.Text)))
                        {
                            InsertNewReservation(currentAdminID, selectedUserID, cmbEvents.SelectedItem.ToString(), dtpDate.Value.ToString("yyyy/MM/dd"), cmbTime.SelectedItem.ToString(), txtAttendee1.Text, txtAttendee2.Text, CheckModeOfPayment(), Convert.ToDouble(txtPaymentAmount.Text));
                        }
                        else
                        {
                            MessageBox.Show("Payment is insufficient or too much, check and try again..");
                        }
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
            }
            else
            {
                MessageBox.Show("No reservation selected.");
            }
            LoadUserInfoDgvRequestee();
            LoadReservationsDgvReservations();
            LoadUpcomingEventsOnDGV();
            LoadPastEventsOnDGV();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure that you would cancel this reservation?", "Warning !!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                //frmCancelationRemark cncl = new frmCancelationRemark();
                //cncl.ShowDialog();
            }
            else
            {
                //  
            }
            LoadUserInfoDgvRequestee();
            LoadReservationsDgvReservations();
            LoadUpcomingEventsOnDGV();
            LoadPastEventsOnDGV();
        }

        private void btnEditReserve_Click(object sender, EventArgs e)
        {
            // for wedding
            bool reservationTextBoxesFilledEvent1 = !(txtAttendee1.Text == "" || txtAttendee2.Text == "" || txtPaymentAmount.Text == "");
            // for the rest
            bool reservationTextBoxesFilledEvent2 = !(txtAttendee1.Text == "" || txtPaymentAmount.Text == "");

            bool hasReservationID = selectedReservationID > 0;
            if (hasReservationID)
            {
                if (!CheckDateOrTimeConflictEdit(dtpDate.Value.ToString("yyyy/MM/dd"), cmbTime.SelectedItem.ToString(), selectedReservationID))
                {
                    if (reservationTextBoxesFilledEvent1 || reservationTextBoxesFilledEvent2)
                    {
                        if (CheckEnoughPaymentAmount(Convert.ToInt32(txtAmountToBePaid.Text), Convert.ToInt32(txtPaymentAmount.Text)))
                        {
                            UpdateReservation(selectedReservationID, currentAdminID, selectedUserID, cmbEvents.SelectedItem.ToString(), dtpDate.Value.ToString("yyyy/MM/dd"), cmbTime.SelectedItem.ToString(), txtAttendee1.Text, txtAttendee2.Text, CheckModeOfPayment(), Convert.ToDouble(txtPaymentAmount.Text));
                            MessageBox.Show("Edit Success");
                        }
                        else
                        {
                            MessageBox.Show("Payment is insufficient or too much, check and try again..");
                        }
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
            }
            else
            {
                MessageBox.Show("No reservation selected.");
            }
            LoadUserInfoDgvRequestee();
            LoadReservationsDgvReservations();
            LoadUpcomingEventsOnDGV();
            LoadPastEventsOnDGV();
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
            selectedReservationID = 0;
            ClearTextBoxes();
            LoadPrice();
            LoadReservationsDgvReservations();
        }

        // UPCOMING EVENTS PANEL ================================================

        /* UPCOMING EVENTS PANEL VARIABLES ================================================
         */

        string currentDateToday = DateTime.Today.ToString("yyyy/MM/dd");
        DataGridViewRow selectedUpcomingEventRow;
        int selectedUpcomingReservationID;

        /* UPCOMING EVENTS PANEL METHODS ================================================
         */

        private void LoadUpcomingEventsOnDGV()
        {
            DB = new SQLiteDataAdapter(
                "SELECT Reservations.reservation_id, date, time, type, name AS requested_by, ModeOfPayments.mode_of_payment, price, balance " +
                "FROM Reservations " +
                "LEFT JOIN Wedding " +
                "ON Reservations.reservation_id = Wedding.id " +
                "LEFT JOIN Baptism " +
                "ON Reservations.reservation_id = Baptism.id " +
                "LEFT JOIN Confirmation " +
                "ON Reservations.reservation_id = Confirmation.id " +
                "LEFT JOIN Mass " +
                "ON Reservations.reservation_id = Mass.id " +
                "LEFT JOIN Payments " +
                "ON Reservations.reservation_id = Payments.reservation_id " +
                "LEFT JOIN ModeOfPayments " +
                "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                "LEFT JOIN Prices " +
                "ON Prices.price_id = ModeOfPayments.mode_of_payment_id " +
                "LEFT JOIN UserInfo " +
                "ON Reservations.user_id = UserInfo.id " +
                "WHERE substr(date, 1, 10) >= '" + currentDateToday + "' " +
                "ORDER BY date, time;"
                , sql_con
            );
            DT = new DataTable();
            DB.Fill(DT);
            dgvUpcomingEvent.DataSource = DT;
        }

        /* UPCOMING EVENTS PANEL EVENTS ================================================
         */

        private void dgvUpcomingEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                selectedUpcomingEventRow = dgvUpcomingEvent.Rows[index];
                selectedUpcomingReservationID = Convert.ToInt32(selectedUpcomingEventRow.Cells[0].Value);
            }
            catch { }
        }

        private void btnViewUpComing_Click(object sender, EventArgs e)
        {
            bool hasID = selectedUpcomingReservationID > 0;
            if (hasID)
            {
                frmViewDetails viewDetails = new frmViewDetails(selectedUpcomingReservationID);
                viewDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("No reservation selected.");
            }
        }
        private void txtSearchUpcoming_TextChanged(object sender, EventArgs e)
        {
            bool searchBarEmpty = txtSearchUpcoming.Text == "";
            if (!searchBarEmpty)
            {
                DB = new SQLiteDataAdapter(
                    // selected columns
                    "SELECT Reservations.reservation_id, date, time, type, name AS requested_by, ModeOfPayments.mode_of_payment, price, balance " +
                    "FROM Reservations " +
                    "LEFT JOIN Wedding " +
                    "ON Reservations.reservation_id = Wedding.id " +
                    "LEFT JOIN Baptism " +
                    "ON Reservations.reservation_id = Baptism.id " +
                    "LEFT JOIN Confirmation " +
                    "ON Reservations.reservation_id = Confirmation.id " +
                    "LEFT JOIN Mass " +
                    "ON Reservations.reservation_id = Mass.id " +
                    "LEFT JOIN Payments " +
                    "ON Reservations.reservation_id = Payments.reservation_id " +
                    "LEFT JOIN ModeOfPayments " +
                    "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                    "LEFT JOIN Prices " +
                    "ON Prices.price_id = ModeOfPayments.mode_of_payment_id " +
                    "LEFT JOIN UserInfo " +
                    "ON Reservations.user_id = UserInfo.id " +
                    // condition
                    "WHERE (time LIKE '%" + txtSearchUpcoming.Text + "%' OR " +
                    "type LIKE '%" + txtSearchUpcoming.Text + "%' OR " +
                    "date LIKE '%" + txtSearchUpcoming.Text + "%' OR " +
                    "name LIKE '%" + txtSearchUpcoming.Text + "%' OR " +
                    "ModeOfPayments.mode_of_payment LIKE '%" + txtSearchUpcoming.Text + "%' OR " +
                    "price LIKE '%" + txtSearchUpcoming.Text + "%' OR " +
                    "balance LIKE '%" + txtSearchUpcoming.Text + "%')" +
                    "AND substr(date, 1, 10) >= '" + currentDateToday + "' " +
                    // order by date and time
                    "ORDER BY date, time;",
                    sql_con
                );
                DT = new DataTable();
                DB.Fill(DT);
                dgvUpcomingEvent.DataSource = DT;
            }
            else
            {
                LoadUpcomingEventsOnDGV();
            }
        }

        // PAST EVENTS PANEL ================================================

        /* PAST EVENTS PANEL VARIABLES ================================================
         */

        DataGridViewRow selectedPastEventRow;
        int selectedPastReservationID;

        /* PAST EVENTS PANEL METHODS ================================================
         */

        private void LoadPastEventsOnDGV()
        {
            DB = new SQLiteDataAdapter(
                "SELECT Reservations.reservation_id, date, time, type, name AS requested_by, ModeOfPayments.mode_of_payment, price, balance " +
                "FROM Reservations " +
                "LEFT JOIN Wedding " +
                "ON Reservations.reservation_id = Wedding.id " +
                "LEFT JOIN Baptism " +
                "ON Reservations.reservation_id = Baptism.id " +
                "LEFT JOIN Confirmation " +
                "ON Reservations.reservation_id = Confirmation.id " +
                "LEFT JOIN Mass " +
                "ON Reservations.reservation_id = Mass.id " +
                "LEFT JOIN Payments " +
                "ON Reservations.reservation_id = Payments.reservation_id " +
                "LEFT JOIN ModeOfPayments " +
                "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                "LEFT JOIN Prices " +
                "ON Prices.price_id = ModeOfPayments.mode_of_payment_id " +
                "LEFT JOIN UserInfo " +
                "ON Reservations.user_id = UserInfo.id " +
                "WHERE substr(date, 1, 10) < '" + currentDateToday + "' " +
                "ORDER BY date, time;"
                , sql_con
            );
            DT = new DataTable();
            DB.Fill(DT);
            dgvPastEvents.DataSource = DT;
        }

        /* PAST EVENTS PANEL EVENTS ================================================
         */

        private void dgvPastEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                selectedPastEventRow = dgvPastEvents.Rows[index];
                selectedPastReservationID = Convert.ToInt32(selectedPastEventRow.Cells[0].Value);
            }
            catch { }
        }

        private void btnViewPast_Click(object sender, EventArgs e)
        {
            bool hasID = selectedPastReservationID > 0;
            if (hasID)
            {
                frmViewDetails viewDetails = new frmViewDetails(selectedPastReservationID);
                viewDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("No reservation selected.");
            }
        }

        private void txtSearchPast_TextChanged(object sender, EventArgs e)
        {
            bool searchBarEmpty = txtSearchPast.Text == "";
            if (!searchBarEmpty)
            {
                DB = new SQLiteDataAdapter(
                    // selected columns
                    "SELECT Reservations.reservation_id, date, time, type, name AS requested_by, ModeOfPayments.mode_of_payment, price, balance " +
                    "FROM Reservations " +
                    "LEFT JOIN Wedding " +
                    "ON Reservations.reservation_id = Wedding.id " +
                    "LEFT JOIN Baptism " +
                    "ON Reservations.reservation_id = Baptism.id " +
                    "LEFT JOIN Confirmation " +
                    "ON Reservations.reservation_id = Confirmation.id " +
                    "LEFT JOIN Mass " +
                    "ON Reservations.reservation_id = Mass.id " +
                    "LEFT JOIN Payments " +
                    "ON Reservations.reservation_id = Payments.reservation_id " +
                    "LEFT JOIN ModeOfPayments " +
                    "ON Payments.mode_of_payment_id = ModeOfPayments.mode_of_payment_id " +
                    "LEFT JOIN Prices " +
                    "ON Prices.price_id = ModeOfPayments.mode_of_payment_id " +
                    "LEFT JOIN UserInfo " +
                    "ON Reservations.user_id = UserInfo.id " +

                    // condition
                    "WHERE (time LIKE '%" + txtSearchPast.Text + "%' OR " +
                    "type LIKE '%" + txtSearchPast.Text + "%' OR " +
                    "date LIKE '%" + txtSearchPast.Text + "%' OR " +
                    "name LIKE '%" + txtSearchPast.Text + "%' OR " +
                    "ModeOfPayments.mode_of_payment LIKE '%" + txtSearchPast.Text + "%' OR " +
                    "price LIKE '%" + txtSearchPast.Text + "%' OR " +
                    "balance LIKE '%" + txtSearchPast.Text + "%')" +
                    "AND substr(date, 1, 10) < '" + currentDateToday + "' " +

                    // order by date and time
                    "ORDER BY date, time;",
                    sql_con
                );
                DT = new DataTable();
                DB.Fill(DT);
                dgvPastEvents.DataSource = DT;
            }
            else
            {
                LoadPastEventsOnDGV();
            }
        }

        // LOBBY PANEL FORM ================================================

        private int currentAdminID;

        //Copy Everything From here
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

        public frmLobbyPanel()
        {
            InitializeComponent();
        }
        public frmLobbyPanel(int adminID)
        {
            InitializeComponent();
            this.currentAdminID = adminID;
            this.FormBorderStyle = FormBorderStyle.None;//Rounded
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));//Rounded
        }
        private void frmLobbyPanel_Load(object sender, EventArgs e)
        {
            dgvUpcomingEvent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPastEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            // UPCOMING EVENTS PANEL ================
            LoadUpcomingEventsOnDGV();
            // PAST EVENTS PANEL ================
            LoadPastEventsOnDGV();
        }
        //log out button in requestee tab
        /*private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to Logout ???", "Warning !!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                frmAdminLogin a = new frmAdminLogin();
                this.Dispose();
                a.ShowDialog();

            }
            else
            {
                //  
            }
        }
        //log out button in reservation tab
        private void btnLogOut1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to Logout ???", "Warning !!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                frmAdminLogin a = new frmAdminLogin();
                this.Dispose();
                a.ShowDialog();

            }
            else
            {
                //  
            }
        }*/

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
            DialogResult dialog = MessageBox.Show("Are you sure you want to Logout?", "Notice", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                frmAdminLogin adm = new frmAdminLogin();
                this.Dispose();
                adm.ShowDialog();
                
            }
            else
            {
                //  
            }
            
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

        private void tbRequestee_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownEvent();
        }

        private void tbReservation_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownEvent();
        }

        private void tbAllReserve_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownEvent();
        }

        private void tbPastEvents_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownEvent();
        }

        private void dgvRequestees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRequestees.ClearSelection();
        }

        private void dgvReservations_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvReservations.ClearSelection();
        }

        private void dgvUpcomingEvent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUpcomingEvent.ClearSelection();
        }

        private void dgvPastEvents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPastEvents.ClearSelection();
        }

        
    }
}