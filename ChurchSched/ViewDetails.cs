using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChurchSched
{
    public partial class frmViewDetails : Form
    {
        int adminID,reservationID;
        string adminName,username;//Add a column for the admin name in the database
        string requesteeName,requesteeEmail;
        string reservationType,reservationDate,reservationTime;
        string groom, bride, candidate, confirmand, purpose;
        string paymentMode, paymentAmount, paymentBalance;

        private void readReservationData()
        {
            string sql_admin =  "SELECT username FROM Accounts WHERE id = " + adminID.ToString();
            //Note: Find a way to query the attendee(s), paymentMode, paymentAmount, paymentBalance
            string sql_reservation = "SELECT UserInfo.name, UserInfo.email, Reservations.type, Reservations.date, Reservations.time, " +
                "Wedding.groom, Wedding.bride, Baptism.candidate, Confirmation.confirmand, Mass.purpose " +
                "FROM Reservations INNER JOIN UserInfo ON Reservations.user_id = UserInfo.id " +
                "LEFT JOIN Wedding ON Reservations.reservation_id = Wedding.id " +
                "LEFT JOIN Baptism ON Reservations.reservation_id = Baptism.id " +
                "LEFT JOIN Confirmation ON Reservations.reservation_id = Confirmation.id " +
                "LEFT JOIN Mass ON Reservations.reservation_id = Mass.id " +
                "WHERE Reservations.reservation_id = " + reservationID.ToString();
            
            using (SQLiteConnection sql_con = new SQLiteConnection("Data Source=Church.db; Version=3; New=False; Compress=True;"))
            {
                sql_con.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql_admin, sql_con))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        username = reader[0] as string;
                        break;
                    }
                }
                using (SQLiteCommand command = new SQLiteCommand(sql_reservation, sql_con))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        requesteeName = reader[0] as string;
                        requesteeEmail = reader[1] as string;
                        reservationType = reader[2] as string;
                        reservationDate = reader[3] as string;
                        reservationTime = reader[4] as string;
                        groom = reader[5] as string;
                        bride = reader[6] as string;
                        candidate = reader[7] as string;
                        confirmand = reader[8] as string;
                        purpose = reader[9] as string;
                        break;
                    }
                }
                sql_con.Close();
            }
        }

        public frmViewDetails()
        {
            InitializeComponent();
        }

        public frmViewDetails(int adminID, int reservationID)
        {
            InitializeComponent();
            this.adminID = adminID;
            this.reservationID = reservationID;

        }
        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void hideAttendeeLabels()
        {
            lblDetailGroom.Visible = false;
            lblDetailBride.Visible = false;
            lblDetailCandidate.Visible = false;
            lblDetailConfirmand.Visible = false;
            lblDetailPurpose.Visible = false;
        }

        private void frmViewDetails_Load(object sender, EventArgs e)
        {
            readReservationData();
            hideAttendeeLabels();
            lblDetailUserAdmin.Text = username;
            lblDetailAdminID.Text = adminID.ToString();

            lblDetailReservatorName.Text = requesteeName;
            lblDetailReservatorEmail.Text = requesteeEmail;
            lblDetailEventType.Text = reservationType;
            lblDetailDate.Text = reservationDate;
            lblDetailTime.Text = reservationTime;

            //Sets the attendee(s)
            if (reservationType == "Wedding")
            {
                lblDetailGroom.Text = groom;
                lblDetailBride.Text = bride;
                lblDetailGroom.Visible = true;
                lblDetailBride.Visible = true;
            }
            else if (reservationType == "Baptism")
            {
                lblDetailCandidate.Text = candidate;
                lblDetailCandidate.Visible = true;
            }
            else if (reservationType == "Confirmation")
            {
                lblDetailConfirmand.Text = confirmand;
                lblDetailConfirmand.Visible = true;
            }
            else
            {
                lblDetailPurpose.Text = purpose;
                lblDetailPurpose.Visible = true;
            }

            //Sets the payment amounts
            //lblDetailPaidAmount.Text = paymentAmount;
            //lblDetailBalance.Text = paymentBalance;

            //Check which payment mode
            //if (paymentMode== "Gcash/Paypal")
            //{
            //    rbtnGcashPaypal.Checked = true;
            //}else if (paymentMode == "Debit/Credit Cardl")
            //{
            //    rbtnDebitCredit.Checked = true;
            //}
            //else
            //{
            //    rbtnCash.Checked = true;
            //}
        }
    }
}
