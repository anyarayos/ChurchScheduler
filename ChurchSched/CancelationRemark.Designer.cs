
namespace ChurchSched
{
    partial class frmCancelationRemark
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
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(12, 40);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(525, 199);
            this.txtRemark.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reason / Remark : ";
            // 
            // btnCancelConfirm
            // 
            this.btnCancelConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelConfirm.Location = new System.Drawing.Point(231, 247);
            this.btnCancelConfirm.Name = "btnCancelConfirm";
            this.btnCancelConfirm.Size = new System.Drawing.Size(84, 28);
            this.btnCancelConfirm.TabIndex = 2;
            this.btnCancelConfirm.Text = "Confirm";
            this.btnCancelConfirm.UseVisualStyleBackColor = true;
            this.btnCancelConfirm.Click += new System.EventHandler(this.btnCancelConfirm_Click);
            // 
            // frmCancelationRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 287);
            this.Controls.Add(this.btnCancelConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemark);
            this.Name = "frmCancelationRemark";
            this.Text = "Cancelation Remark";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelConfirm;
    }
}