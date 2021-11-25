
namespace ChurchSched
{
    partial class ResetPass
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
            this.lblResetConfirmPass = new System.Windows.Forms.Label();
            this.lblResetNewPass = new System.Windows.Forms.Label();
            this.btnResetConfirm = new System.Windows.Forms.Button();
            this.txtResetConfirmNewPass = new System.Windows.Forms.TextBox();
            this.txtResetNewPass = new System.Windows.Forms.TextBox();
            this.btnLogInOnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResetConfirmPass
            // 
            this.lblResetConfirmPass.AutoSize = true;
            this.lblResetConfirmPass.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResetConfirmPass.Location = new System.Drawing.Point(36, 108);
            this.lblResetConfirmPass.Name = "lblResetConfirmPass";
            this.lblResetConfirmPass.Size = new System.Drawing.Size(172, 25);
            this.lblResetConfirmPass.TabIndex = 11;
            this.lblResetConfirmPass.Text = "Confirm Password:";
            // 
            // lblResetNewPass
            // 
            this.lblResetNewPass.AutoSize = true;
            this.lblResetNewPass.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResetNewPass.Location = new System.Drawing.Point(66, 50);
            this.lblResetNewPass.Name = "lblResetNewPass";
            this.lblResetNewPass.Size = new System.Drawing.Size(141, 25);
            this.lblResetNewPass.TabIndex = 10;
            this.lblResetNewPass.Text = "New Password:";
            // 
            // btnResetConfirm
            // 
            this.btnResetConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetConfirm.Location = new System.Drawing.Point(258, 146);
            this.btnResetConfirm.Name = "btnResetConfirm";
            this.btnResetConfirm.Size = new System.Drawing.Size(80, 31);
            this.btnResetConfirm.TabIndex = 9;
            this.btnResetConfirm.Text = "Confirm";
            this.btnResetConfirm.UseVisualStyleBackColor = true;
            this.btnResetConfirm.Click += new System.EventHandler(this.btnResetConfirm_Click);
            // 
            // txtResetConfirmNewPass
            // 
            this.txtResetConfirmNewPass.Location = new System.Drawing.Point(209, 108);
            this.txtResetConfirmNewPass.Name = "txtResetConfirmNewPass";
            this.txtResetConfirmNewPass.Size = new System.Drawing.Size(185, 23);
            this.txtResetConfirmNewPass.TabIndex = 7;
            // 
            // txtResetNewPass
            // 
            this.txtResetNewPass.Location = new System.Drawing.Point(208, 52);
            this.txtResetNewPass.Name = "txtResetNewPass";
            this.txtResetNewPass.Size = new System.Drawing.Size(186, 23);
            this.txtResetNewPass.TabIndex = 6;
            // 
            // btnLogInOnReset
            // 
            this.btnLogInOnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogInOnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogInOnReset.Location = new System.Drawing.Point(164, 202);
            this.btnLogInOnReset.Name = "btnLogInOnReset";
            this.btnLogInOnReset.Size = new System.Drawing.Size(75, 37);
            this.btnLogInOnReset.TabIndex = 13;
            this.btnLogInOnReset.Text = "Log-In";
            this.btnLogInOnReset.UseVisualStyleBackColor = true;
            this.btnLogInOnReset.Click += new System.EventHandler(this.btnLogInOnReset_Click);
            // 
            // ResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 257);
            this.Controls.Add(this.btnLogInOnReset);
            this.Controls.Add(this.lblResetConfirmPass);
            this.Controls.Add(this.lblResetNewPass);
            this.Controls.Add(this.btnResetConfirm);
            this.Controls.Add(this.txtResetConfirmNewPass);
            this.Controls.Add(this.txtResetNewPass);
            this.Name = "ResetPass";
            this.Text = "Reset Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResetConfirmPass;
        private System.Windows.Forms.Label lblResetNewPass;
        private System.Windows.Forms.Button btnResetConfirm;
        private System.Windows.Forms.TextBox txtResetConfirmNewPass;
        private System.Windows.Forms.TextBox txtResetNewPass;
        private System.Windows.Forms.Button btnLogInOnReset;
    }
}