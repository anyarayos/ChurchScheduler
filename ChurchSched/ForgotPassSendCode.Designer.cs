
namespace ChurchSched
{
    partial class ForgotPassSendCode
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
            this.txtForgotEmailRecovery = new System.Windows.Forms.TextBox();
            this.txtForgotCodeVerify = new System.Windows.Forms.TextBox();
            this.btnFogotSend = new System.Windows.Forms.Button();
            this.btnForgotVerify = new System.Windows.Forms.Button();
            this.lblForgotEmailRecovery = new System.Windows.Forms.Label();
            this.lblForgotCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtForgotEmailRecovery
            // 
            this.txtForgotEmailRecovery.Location = new System.Drawing.Point(124, 57);
            this.txtForgotEmailRecovery.Name = "txtForgotEmailRecovery";
            this.txtForgotEmailRecovery.Size = new System.Drawing.Size(186, 23);
            this.txtForgotEmailRecovery.TabIndex = 0;
            // 
            // txtForgotCodeVerify
            // 
            this.txtForgotCodeVerify.Location = new System.Drawing.Point(124, 121);
            this.txtForgotCodeVerify.Name = "txtForgotCodeVerify";
            this.txtForgotCodeVerify.Size = new System.Drawing.Size(180, 23);
            this.txtForgotCodeVerify.TabIndex = 1;
            // 
            // btnFogotSend
            // 
            this.btnFogotSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFogotSend.Location = new System.Drawing.Point(229, 87);
            this.btnFogotSend.Name = "btnFogotSend";
            this.btnFogotSend.Size = new System.Drawing.Size(75, 23);
            this.btnFogotSend.TabIndex = 2;
            this.btnFogotSend.Text = "Send";
            this.btnFogotSend.UseVisualStyleBackColor = true;
            this.btnFogotSend.Click += new System.EventHandler(this.btnFogotSend_Click);
            // 
            // btnForgotVerify
            // 
            this.btnForgotVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForgotVerify.Location = new System.Drawing.Point(229, 150);
            this.btnForgotVerify.Name = "btnForgotVerify";
            this.btnForgotVerify.Size = new System.Drawing.Size(75, 23);
            this.btnForgotVerify.TabIndex = 3;
            this.btnForgotVerify.Text = "Verify";
            this.btnForgotVerify.UseVisualStyleBackColor = true;
            this.btnForgotVerify.Click += new System.EventHandler(this.btnForgotVerify_Click);
            // 
            // lblForgotEmailRecovery
            // 
            this.lblForgotEmailRecovery.AutoSize = true;
            this.lblForgotEmailRecovery.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblForgotEmailRecovery.Location = new System.Drawing.Point(46, 55);
            this.lblForgotEmailRecovery.Name = "lblForgotEmailRecovery";
            this.lblForgotEmailRecovery.Size = new System.Drawing.Size(67, 25);
            this.lblForgotEmailRecovery.TabIndex = 4;
            this.lblForgotEmailRecovery.Text = "E-mail";
            // 
            // lblForgotCode
            // 
            this.lblForgotCode.AutoSize = true;
            this.lblForgotCode.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblForgotCode.Location = new System.Drawing.Point(57, 116);
            this.lblForgotCode.Name = "lblForgotCode";
            this.lblForgotCode.Size = new System.Drawing.Size(56, 25);
            this.lblForgotCode.TabIndex = 5;
            this.lblForgotCode.Text = "Code";
            // 
            // ForgotPassSendCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 201);
            this.Controls.Add(this.lblForgotCode);
            this.Controls.Add(this.lblForgotEmailRecovery);
            this.Controls.Add(this.btnForgotVerify);
            this.Controls.Add(this.btnFogotSend);
            this.Controls.Add(this.txtForgotCodeVerify);
            this.Controls.Add(this.txtForgotEmailRecovery);
            this.Name = "ForgotPassSendCode";
            this.Text = "Forgot Password?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtForgotEmailRecovery;
        private System.Windows.Forms.TextBox txtForgotCodeVerify;
        private System.Windows.Forms.Button btnFogotSend;
        private System.Windows.Forms.Button btnForgotVerify;
        private System.Windows.Forms.Label lblForgotEmailRecovery;
        private System.Windows.Forms.Label lblForgotCode;
    }
}