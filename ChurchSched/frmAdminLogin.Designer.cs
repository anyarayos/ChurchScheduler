
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
												this.btnLogIn = new System.Windows.Forms.Button();
												this.lblForgot = new System.Windows.Forms.Label();
												this.SuspendLayout();
												// 
												// txtUserName
												// 
												this.txtUserName.Location = new System.Drawing.Point(170, 69);
												this.txtUserName.Name = "txtUserName";
												this.txtUserName.Size = new System.Drawing.Size(209, 23);
												this.txtUserName.TabIndex = 0;
												// 
												// txtPassword
												// 
												this.txtPassword.Location = new System.Drawing.Point(170, 129);
												this.txtPassword.Name = "txtPassword";
												this.txtPassword.Size = new System.Drawing.Size(209, 23);
												this.txtPassword.TabIndex = 1;
												this.txtPassword.UseSystemPasswordChar = true;
												// 
												// label1
												// 
												this.label1.AutoSize = true;
												this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
												this.label1.Location = new System.Drawing.Point(170, 45);
												this.label1.Name = "label1";
												this.label1.Size = new System.Drawing.Size(87, 21);
												this.label1.TabIndex = 2;
												this.label1.Text = "Username:";
												// 
												// label2
												// 
												this.label2.AutoSize = true;
												this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
												this.label2.Location = new System.Drawing.Point(170, 105);
												this.label2.Name = "label2";
												this.label2.Size = new System.Drawing.Size(83, 21);
												this.label2.TabIndex = 3;
												this.label2.Text = "Password:";
												// 
												// btnLogIn
												// 
												this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
												this.btnLogIn.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
												this.btnLogIn.Location = new System.Drawing.Point(230, 167);
												this.btnLogIn.Name = "btnLogIn";
												this.btnLogIn.Size = new System.Drawing.Size(100, 42);
												this.btnLogIn.TabIndex = 4;
												this.btnLogIn.Text = "Log-In";
												this.btnLogIn.UseVisualStyleBackColor = true;
												this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
												// 
												// lblForgot
												// 
												this.lblForgot.AutoSize = true;
												this.lblForgot.Cursor = System.Windows.Forms.Cursors.Hand;
												this.lblForgot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
												this.lblForgot.Location = new System.Drawing.Point(230, 222);
												this.lblForgot.Name = "lblForgot";
												this.lblForgot.Size = new System.Drawing.Size(100, 15);
												this.lblForgot.TabIndex = 5;
												this.lblForgot.Text = "Forgot Password?";
												this.lblForgot.Click += new System.EventHandler(this.lblForgot_Click);
												// 
												// frmAdminLogin
												// 
												this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
												this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
												this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
												this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
												this.ClientSize = new System.Drawing.Size(400, 246);
												this.Controls.Add(this.lblForgot);
												this.Controls.Add(this.btnLogIn);
												this.Controls.Add(this.label2);
												this.Controls.Add(this.label1);
												this.Controls.Add(this.txtPassword);
												this.Controls.Add(this.txtUserName);
												this.Name = "frmAdminLogin";
												this.Text = "Admin Log In";
												this.Load += new System.EventHandler(this.frmLogIn_Load);
												this.ResumeLayout(false);
												this.PerformLayout();

								}

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblForgot;
    }
}

