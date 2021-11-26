
namespace ChurchSched
{
    partial class frmLobbyPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLobbyPanel));
            this.tbRequestee = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnConfirmRequestee = new System.Windows.Forms.Button();
            this.btnEditrequestee = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnClearRequestee = new System.Windows.Forms.Button();
            this.txtRequestName = new System.Windows.Forms.TextBox();
            this.txtContactNum = new System.Windows.Forms.TextBox();
            this.txtEmailAdd = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.tbcon1 = new System.Windows.Forms.TabControl();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbAllReserve = new System.Windows.Forms.TabPage();
            this.tbReservation = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.grpbxAdditional = new System.Windows.Forms.GroupBox();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConfirmReserve = new System.Windows.Forms.Button();
            this.btnEditReserve = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textSearchRequestee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPastEvents = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchAllSched = new System.Windows.Forms.TextBox();
            this.dgvAllSched = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancelRequestee = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.rdbtnCash = new System.Windows.Forms.RadioButton();
            this.rdbtn = new System.Windows.Forms.RadioButton();
            this.rdbtnGCash = new System.Windows.Forms.RadioButton();
            this.tbRequestee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tbcon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tbAllReserve.SuspendLayout();
            this.tbReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbPastEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSched)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRequestee
            // 
            this.tbRequestee.Controls.Add(this.btnCancelRequestee);
            this.tbRequestee.Controls.Add(this.label9);
            this.tbRequestee.Controls.Add(this.label4);
            this.tbRequestee.Controls.Add(this.textSearchRequestee);
            this.tbRequestee.Controls.Add(this.txtAdd);
            this.tbRequestee.Controls.Add(this.txtEmailAdd);
            this.tbRequestee.Controls.Add(this.txtContactNum);
            this.tbRequestee.Controls.Add(this.txtRequestName);
            this.tbRequestee.Controls.Add(this.btnClearRequestee);
            this.tbRequestee.Controls.Add(this.pictureBox4);
            this.tbRequestee.Controls.Add(this.btnEditrequestee);
            this.tbRequestee.Controls.Add(this.btnConfirmRequestee);
            this.tbRequestee.Controls.Add(this.dgv);
            this.tbRequestee.Controls.Add(this.label28);
            this.tbRequestee.Controls.Add(this.label29);
            this.tbRequestee.Controls.Add(this.label30);
            this.tbRequestee.Controls.Add(this.label31);
            this.tbRequestee.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.tbRequestee.Location = new System.Drawing.Point(4, 24);
            this.tbRequestee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRequestee.Name = "tbRequestee";
            this.tbRequestee.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRequestee.Size = new System.Drawing.Size(950, 609);
            this.tbRequestee.TabIndex = 1;
            this.tbRequestee.Text = "REQUESTEE";
            this.tbRequestee.UseVisualStyleBackColor = true;
            this.tbRequestee.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label31.Location = new System.Drawing.Point(46, 52);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 19);
            this.label31.TabIndex = 22;
            this.label31.Text = "Name :";
            this.label31.Click += new System.EventHandler(this.label31_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label30.Location = new System.Drawing.Point(46, 100);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(120, 19);
            this.label30.TabIndex = 23;
            this.label30.Text = "Contact Number :";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label29.Location = new System.Drawing.Point(46, 147);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(103, 19);
            this.label29.TabIndex = 24;
            this.label29.Text = "Email Address :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label28.Location = new System.Drawing.Point(46, 188);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 19);
            this.label28.TabIndex = 25;
            this.label28.Text = "Address :";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(407, 51);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 29;
            this.dgv.Size = new System.Drawing.Size(492, 457);
            this.dgv.TabIndex = 39;
            // 
            // btnConfirmRequestee
            // 
            this.btnConfirmRequestee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmRequestee.Location = new System.Drawing.Point(46, 289);
            this.btnConfirmRequestee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmRequestee.Name = "btnConfirmRequestee";
            this.btnConfirmRequestee.Size = new System.Drawing.Size(127, 41);
            this.btnConfirmRequestee.TabIndex = 51;
            this.btnConfirmRequestee.Text = "Confirm Requestee";
            this.btnConfirmRequestee.UseVisualStyleBackColor = true;
            // 
            // btnEditrequestee
            // 
            this.btnEditrequestee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditrequestee.Location = new System.Drawing.Point(211, 289);
            this.btnEditrequestee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditrequestee.Name = "btnEditrequestee";
            this.btnEditrequestee.Size = new System.Drawing.Size(137, 41);
            this.btnEditrequestee.TabIndex = 52;
            this.btnEditrequestee.Text = "Edit Requestee";
            this.btnEditrequestee.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(46, 422);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(302, 117);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            // 
            // btnClearRequestee
            // 
            this.btnClearRequestee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearRequestee.Location = new System.Drawing.Point(46, 354);
            this.btnClearRequestee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearRequestee.Name = "btnClearRequestee";
            this.btnClearRequestee.Size = new System.Drawing.Size(127, 37);
            this.btnClearRequestee.TabIndex = 53;
            this.btnClearRequestee.Text = "Clear Requestee";
            this.btnClearRequestee.UseVisualStyleBackColor = true;
            this.btnClearRequestee.Click += new System.EventHandler(this.btnWeddCancel_Click);
            // 
            // txtRequestName
            // 
            this.txtRequestName.Location = new System.Drawing.Point(194, 51);
            this.txtRequestName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRequestName.Name = "txtRequestName";
            this.txtRequestName.Size = new System.Drawing.Size(154, 24);
            this.txtRequestName.TabIndex = 29;
            // 
            // txtContactNum
            // 
            this.txtContactNum.Location = new System.Drawing.Point(193, 97);
            this.txtContactNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContactNum.Name = "txtContactNum";
            this.txtContactNum.Size = new System.Drawing.Size(154, 24);
            this.txtContactNum.TabIndex = 30;
            // 
            // txtEmailAdd
            // 
            this.txtEmailAdd.Location = new System.Drawing.Point(193, 144);
            this.txtEmailAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmailAdd.Name = "txtEmailAdd";
            this.txtEmailAdd.Size = new System.Drawing.Size(154, 24);
            this.txtEmailAdd.TabIndex = 31;
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(193, 185);
            this.txtAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(154, 24);
            this.txtAdd.TabIndex = 32;
            // 
            // tbcon1
            // 
            this.tbcon1.Controls.Add(this.tbRequestee);
            this.tbcon1.Controls.Add(this.tbReservation);
            this.tbcon1.Controls.Add(this.tbAllReserve);
            this.tbcon1.Controls.Add(this.tbPastEvents);
            this.tbcon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcon1.Location = new System.Drawing.Point(0, 0);
            this.tbcon1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbcon1.Name = "tbcon1";
            this.tbcon1.SelectedIndex = 0;
            this.tbcon1.Size = new System.Drawing.Size(958, 637);
            this.tbcon1.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(372, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(165, 15);
            this.label16.TabIndex = 21;
            this.label16.Text = "Upcoming Scheduled Events";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 508);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(388, 94);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // tbAllReserve
            // 
            this.tbAllReserve.Controls.Add(this.dgvAllSched);
            this.tbAllReserve.Controls.Add(this.label5);
            this.tbAllReserve.Controls.Add(this.txtSearchAllSched);
            this.tbAllReserve.Controls.Add(this.pictureBox2);
            this.tbAllReserve.Controls.Add(this.label16);
            this.tbAllReserve.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.tbAllReserve.Location = new System.Drawing.Point(4, 24);
            this.tbAllReserve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAllReserve.Name = "tbAllReserve";
            this.tbAllReserve.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAllReserve.Size = new System.Drawing.Size(950, 609);
            this.tbAllReserve.TabIndex = 3;
            this.tbAllReserve.Text = "UPCOMING EVENTS";
            this.tbAllReserve.UseVisualStyleBackColor = true;
            // 
            // tbReservation
            // 
            this.tbReservation.Controls.Add(this.rdbtnGCash);
            this.tbReservation.Controls.Add(this.rdbtn);
            this.tbReservation.Controls.Add(this.rdbtnCash);
            this.tbReservation.Controls.Add(this.label11);
            this.tbReservation.Controls.Add(this.comboBox2);
            this.tbReservation.Controls.Add(this.cmbName);
            this.tbReservation.Controls.Add(this.btnCancel);
            this.tbReservation.Controls.Add(this.btnEditReserve);
            this.tbReservation.Controls.Add(this.btnConfirmReserve);
            this.tbReservation.Controls.Add(this.pictureBox1);
            this.tbReservation.Controls.Add(this.dgvList);
            this.tbReservation.Controls.Add(this.cmbTime);
            this.tbReservation.Controls.Add(this.grpbxAdditional);
            this.tbReservation.Controls.Add(this.dtpDate);
            this.tbReservation.Controls.Add(this.label8);
            this.tbReservation.Controls.Add(this.label7);
            this.tbReservation.Controls.Add(this.label3);
            this.tbReservation.Controls.Add(this.label2);
            this.tbReservation.Controls.Add(this.label1);
            this.tbReservation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbReservation.Location = new System.Drawing.Point(4, 24);
            this.tbReservation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReservation.Name = "tbReservation";
            this.tbReservation.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReservation.Size = new System.Drawing.Size(950, 609);
            this.tbReservation.TabIndex = 2;
            this.tbReservation.Text = "RESERVATION";
            this.tbReservation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(596, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "List of Reservation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(46, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(46, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type of Event :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(46, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Date : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(46, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time : ";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(130, 141);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(219, 25);
            this.dtpDate.TabIndex = 12;
            // 
            // grpbxAdditional
            // 
            this.grpbxAdditional.Location = new System.Drawing.Point(46, 280);
            this.grpbxAdditional.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbxAdditional.Name = "grpbxAdditional";
            this.grpbxAdditional.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbxAdditional.Size = new System.Drawing.Size(302, 232);
            this.grpbxAdditional.TabIndex = 19;
            this.grpbxAdditional.TabStop = false;
            this.grpbxAdditional.Text = "Additional";
            // 
            // cmbTime
            // 
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(130, 185);
            this.cmbTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(219, 25);
            this.cmbTime.TabIndex = 14;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(407, 51);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidth = 51;
            this.dgvList.RowTemplate.Height = 29;
            this.dgvList.Size = new System.Drawing.Size(492, 457);
            this.dgvList.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(407, 512);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(492, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnConfirmReserve
            // 
            this.btnConfirmReserve.Location = new System.Drawing.Point(38, 527);
            this.btnConfirmReserve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmReserve.Name = "btnConfirmReserve";
            this.btnConfirmReserve.Size = new System.Drawing.Size(139, 28);
            this.btnConfirmReserve.TabIndex = 46;
            this.btnConfirmReserve.Text = "Confirm Reservation";
            this.btnConfirmReserve.UseVisualStyleBackColor = true;
            // 
            // btnEditReserve
            // 
            this.btnEditReserve.Location = new System.Drawing.Point(217, 527);
            this.btnEditReserve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditReserve.Name = "btnEditReserve";
            this.btnEditReserve.Size = new System.Drawing.Size(139, 28);
            this.btnEditReserve.TabIndex = 47;
            this.btnEditReserve.Text = "Edit Reservation";
            this.btnEditReserve.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 562);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 28);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "Cancel Reservation";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(152, 51);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(197, 25);
            this.cmbName.TabIndex = 51;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(152, 97);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(196, 25);
            this.comboBox2.TabIndex = 52;
            // 
            // textSearchRequestee
            // 
            this.textSearchRequestee.Location = new System.Drawing.Point(525, 542);
            this.textSearchRequestee.Name = "textSearchRequestee";
            this.textSearchRequestee.Size = new System.Drawing.Size(316, 24);
            this.textSearchRequestee.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 545);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 55;
            this.label4.Text = "Search : ";
            // 
            // tbPastEvents
            // 
            this.tbPastEvents.Controls.Add(this.label10);
            this.tbPastEvents.Controls.Add(this.label6);
            this.tbPastEvents.Controls.Add(this.textBox1);
            this.tbPastEvents.Controls.Add(this.pictureBox3);
            this.tbPastEvents.Controls.Add(this.dataGridView1);
            this.tbPastEvents.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbPastEvents.Location = new System.Drawing.Point(4, 24);
            this.tbPastEvents.Name = "tbPastEvents";
            this.tbPastEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tbPastEvents.Size = new System.Drawing.Size(950, 609);
            this.tbPastEvents.TabIndex = 4;
            this.tbPastEvents.Text = "PAST EVENTS";
            this.tbPastEvents.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(468, 545);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 57;
            this.label5.Text = "Search : ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtSearchAllSched
            // 
            this.txtSearchAllSched.Location = new System.Drawing.Point(533, 542);
            this.txtSearchAllSched.Name = "txtSearchAllSched";
            this.txtSearchAllSched.Size = new System.Drawing.Size(316, 25);
            this.txtSearchAllSched.TabIndex = 56;
            // 
            // dgvAllSched
            // 
            this.dgvAllSched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSched.Location = new System.Drawing.Point(8, 41);
            this.dgvAllSched.Name = "dgvAllSched";
            this.dgvAllSched.RowTemplate.Height = 25;
            this.dgvAllSched.Size = new System.Drawing.Size(934, 450);
            this.dgvAllSched.TabIndex = 58;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(934, 450);
            this.dataGridView1.TabIndex = 59;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 508);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(388, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 545);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Search : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(533, 542);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 25);
            this.textBox1.TabIndex = 61;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(596, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 15);
            this.label9.TabIndex = 56;
            this.label9.Text = "List of Requestees";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(396, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 15);
            this.label10.TabIndex = 63;
            this.label10.Text = "Past Scheduled Events";
            // 
            // btnCancelRequestee
            // 
            this.btnCancelRequestee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelRequestee.Location = new System.Drawing.Point(211, 354);
            this.btnCancelRequestee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelRequestee.Name = "btnCancelRequestee";
            this.btnCancelRequestee.Size = new System.Drawing.Size(137, 37);
            this.btnCancelRequestee.TabIndex = 57;
            this.btnCancelRequestee.Text = "Cancel Requestee";
            this.btnCancelRequestee.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(46, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 19);
            this.label11.TabIndex = 53;
            this.label11.Text = "Mode of Payment";
            // 
            // rdbtnCash
            // 
            this.rdbtnCash.AutoSize = true;
            this.rdbtnCash.Location = new System.Drawing.Point(185, 231);
            this.rdbtnCash.Name = "rdbtnCash";
            this.rdbtnCash.Size = new System.Drawing.Size(55, 21);
            this.rdbtnCash.TabIndex = 54;
            this.rdbtnCash.TabStop = true;
            this.rdbtnCash.Text = "Cash";
            this.rdbtnCash.UseVisualStyleBackColor = true;
            // 
            // rdbtn
            // 
            this.rdbtn.AutoSize = true;
            this.rdbtn.Location = new System.Drawing.Point(185, 258);
            this.rdbtn.Name = "rdbtn";
            this.rdbtn.Size = new System.Drawing.Size(119, 21);
            this.rdbtn.TabIndex = 55;
            this.rdbtn.TabStop = true;
            this.rdbtn.Text = "Down Payment";
            this.rdbtn.UseVisualStyleBackColor = true;
            // 
            // rdbtnGCash
            // 
            this.rdbtnGCash.AutoSize = true;
            this.rdbtnGCash.Location = new System.Drawing.Point(279, 231);
            this.rdbtnGCash.Name = "rdbtnGCash";
            this.rdbtnGCash.Size = new System.Drawing.Size(69, 21);
            this.rdbtnGCash.TabIndex = 56;
            this.rdbtnGCash.TabStop = true;
            this.rdbtnGCash.Text = "G-Cash";
            this.rdbtnGCash.UseVisualStyleBackColor = true;
            // 
            // frmLobbyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 637);
            this.Controls.Add(this.tbcon1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLobbyPanel";
            this.Text = "Lobby Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbRequestee.ResumeLayout(false);
            this.tbRequestee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tbcon1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tbAllReserve.ResumeLayout(false);
            this.tbAllReserve.PerformLayout();
            this.tbReservation.ResumeLayout(false);
            this.tbReservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbPastEvents.ResumeLayout(false);
            this.tbPastEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSched)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbRequestee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textSearchRequestee;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.TextBox txtEmailAdd;
        private System.Windows.Forms.TextBox txtContactNum;
        private System.Windows.Forms.TextBox txtRequestName;
        private System.Windows.Forms.Button btnClearRequestee;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnEditrequestee;
        private System.Windows.Forms.Button btnConfirmRequestee;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TabControl tbcon1;
        private System.Windows.Forms.TabPage tbReservation;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEditReserve;
        private System.Windows.Forms.Button btnConfirmReserve;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.GroupBox grpbxAdditional;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbAllReserve;
        private System.Windows.Forms.DataGridView dgvAllSched;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchAllSched;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tbPastEvents;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCancelRequestee;
        private System.Windows.Forms.RadioButton rdbtnGCash;
        private System.Windows.Forms.RadioButton rdbtn;
        private System.Windows.Forms.RadioButton rdbtnCash;
        private System.Windows.Forms.Label label11;
    }
}