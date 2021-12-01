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

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDetailReservatorEmail_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

								private void frmViewDetails_FormClosed(object sender, FormClosedEventArgs e)
								{
            this.Dispose();
								}

        private void btnViewDetailOkay_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        int paymentMode,paymentAmount, paymentBalance;

        private void readReservationData()
        {
            string sql_admin = "SELECT Reservations.admin_id, Accounts.username FROM Reservations INNER JOIN Accounts ON Reservations.admin_id = Accounts.id WHERE Reservations.reservation_id = " + reservationID.ToString();
            //Note: Find a way to query the paymentMode, paymentAmount, paymentBalance
            string sql_reservation = "SELECT UserInfo.name, UserInfo.email, Reservations.type, Reservations.date, Reservations.time, " +
                "Wedding.groom, Wedding.bride, Baptism.candidate, Confirmation.confirmand, Mass.purpose, Payments.mode_of_payment_id, Payments.balance, Prices.price " +
                "FROM Reservations INNER JOIN UserInfo ON Reservations.user_id = UserInfo.id " +
                "LEFT JOIN Wedding ON Reservations.reservation_id = Wedding.id " +
                "LEFT JOIN Baptism ON Reservations.reservation_id = Baptism.id " +
                "LEFT JOIN Confirmation ON Reservations.reservation_id = Confirmation.id " +
                "LEFT JOIN Mass ON Reservations.reservation_id = Mass.id " +
                "LEFT JOIN Payments ON Reservations.reservation_id = Payments.reservation_id " +
                "LEFT JOIN Prices ON Prices.price_id = Payments.mode_of_payment_id " +
                "WHERE Reservations.reservation_id = " + reservationID.ToString();

            using (SQLiteConnection sql_con = new SQLiteConnection("Data Source=Church.db; Version=3; New=False; Compress=True;"))
            {
                sql_con.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql_admin, sql_con))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        adminID = Convert.ToInt32(reader[0]);
                        username = reader[1] as string;
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
                        paymentMode = Convert.ToInt32(reader[10]);
                        paymentAmount = Convert.ToInt32(reader[11]);
                        paymentBalance = Convert.ToInt32(reader[12]);
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

        public frmViewDetails(int reservationID)
        {
            InitializeComponent();
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
            lblDetailPaidAmount.Text = paymentAmount.ToString();
            lblDetailBalance.Text = paymentBalance.ToString();

           //Check which payment mode
            if (paymentMode == 1)
            {
                rbtnGcashPaypal.Checked = true;
            }
            else if (paymentMode == 2)
            {
                rbtnDebitCredit.Checked = true;
            }
            else
            {
                rbtnCash.Checked = true;
            }

            //Check if fully paid
            if (paymentAmount==paymentBalance)//temporary muna si >= habang wala pang checker
            {
                rbtnFull.Checked = true;
            }
            else
            {
                rbtnPartial.Checked = true;
            }
        }
    }
}
