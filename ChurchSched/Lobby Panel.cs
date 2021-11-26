﻿using System;
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
            //con = new SqlConnection(cs);  
            //con.Open();  
            //adapt = new SqlDataAdapter("select * from ----",con);  
            //dt = new DataTable();  
            //dapt.Fill(dt);  
            //dataGridViewExistingRequestees.DataSource = dt;  //populate mo yung datagrid ng existing duh
            //con.Close();


        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure that you would cancel this reservation???");

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

            bool isEmpty = txtRequestName.Text == "" && txtContactNum.Text == "" && txtEmailAdd.Text == "" && txtAddress.Text == "";
            
            if (!isEmpty)
            {
                SetConnection("Church.db");
                DB = new SQLiteDataAdapter("SELECT id FROM UserInfo WHERE name='" + txtRequestName.Text + "' OR email='" + txtEmailAdd.Text + "' OR contact=''" + txtContactNum.Text + "'", sql_con);
                DT = new DataTable();
                DB.Fill(DT);
                bool userExists = DT.Rows.Count == 1;
                if (!userExists)
                {
                    MessageBox.Show("Success!");
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
            //txtRequestName.Text = selectedRow.Cells[].Value.ToString();
            //txtContactNum = selectedRow.Cells[].Value.ToString();
            //txtEmailAdd = selectedRow.Cells[].Value.ToString();
            //txtAddress = selectedRow.Cells[].Value.ToString();
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

    }
}
