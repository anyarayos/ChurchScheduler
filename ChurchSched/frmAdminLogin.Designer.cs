
namespace ChurchSched
{
				partial class frmAdminLogin
				{
								/// <summary>
								///  Required designer variable.
								/// </summary>
								private System.ComponentModel.IContainer components = null;

								/// <summary>
								///  Clean up any resources being used.
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
								///  Required method for Designer support - do not modify
								///  the contents of this method with the code editor.
								/// </summary>
								private void InitializeComponent()
								{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminLogin));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblForgot = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogIn = new ChurchSched.Custom.CustomButtons();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.panelBtnWrapper = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.panelBtnWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(32, 108);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(209, 23);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(32, 168);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(209, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(90, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(90, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // lblForgot
            // 
            this.lblForgot.AutoSize = true;
            this.lblForgot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgot.Enabled = false;
            this.lblForgot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblForgot.Location = new System.Drawing.Point(82, 264);
            this.lblForgot.Name = "lblForgot";
            this.lblForgot.Size = new System.Drawing.Size(100, 15);
            this.lblForgot.TabIndex = 5;
            this.lblForgot.Text = "Forgot Password?";
            this.lblForgot.Click += new System.EventHandler(this.lblForgot_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ChurchSched.Properties.Resources.Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(286, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.White;
            this.btnLogIn.BackgroundColor = System.Drawing.Color.White;
            this.btnLogIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(116)))), ((int)(((byte)(153)))));
            this.btnLogIn.BorderRadius = 20;
            this.btnLogIn.BorderSize = 2;
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogIn.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogIn.ForeColor = System.Drawing.Color.Black;
            this.btnLogIn.Location = new System.Drawing.Point(59, 208);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(150, 53);
            this.btnLogIn.TabIndex = 7;
            this.btnLogIn.Text = "&Log-In";
            this.btnLogIn.TextColor = System.Drawing.Color.Black;
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(116)))), ((int)(((byte)(153)))));
            this.panelTitleBar.Controls.Add(this.lblLogin);
            this.panelTitleBar.Controls.Add(this.panelBtnWrapper);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(592, 36);
            this.panelTitleBar.TabIndex = 8;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(24, 8);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(63, 22);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Login";
            // 
            // panelBtnWrapper
            // 
            this.panelBtnWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBtnWrapper.Controls.Add(this.btnMinimize);
            this.panelBtnWrapper.Controls.Add(this.btnMaximize);
            this.panelBtnWrapper.Controls.Add(this.btnExit);
            this.panelBtnWrapper.Location = new System.Drawing.Point(371, 4);
            this.panelBtnWrapper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBtnWrapper.Name = "panelBtnWrapper";
            this.panelBtnWrapper.Size = new System.Drawing.Size(219, 29);
            this.panelBtnWrapper.TabIndex = 3;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = global::ChurchSched.Properties.Resources.minimize;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(116)))), ((int)(((byte)(153)))));
            this.btnMinimize.Location = new System.Drawing.Point(111, 4);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 22);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMaximize.BackgroundImage")));
            this.btnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMaximize.Enabled = false;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(116)))), ((int)(((byte)(153)))));
            this.btnMaximize.Location = new System.Drawing.Point(147, 4);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(26, 22);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::ChurchSched.Properties.Resources.close_button;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(116)))), ((int)(((byte)(153)))));
            this.btnExit.Location = new System.Drawing.Point(181, 4);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(26, 22);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmAdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(592, 329);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblForgot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Log In";
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmAdminLogin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelBtnWrapper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

								}

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForgot;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Custom.CustomButtons btnLogIn;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel panelBtnWrapper;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnExit;
    }
}

