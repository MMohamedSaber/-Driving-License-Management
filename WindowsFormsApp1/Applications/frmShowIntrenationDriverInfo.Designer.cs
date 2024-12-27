namespace WindowsFormsApp1
{
    partial class frmShowIntrenationDriverInfo
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
            this.lblAddNewTitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ctrlDriverInternationalLicenseInfo1 = new WindowsFormsApp1.ctrlDriverInternationalLicenseInfo();
            this.SuspendLayout();
            // 
            // lblAddNewTitle
            // 
            this.lblAddNewTitle.AutoSize = true;
            this.lblAddNewTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddNewTitle.Location = new System.Drawing.Point(117, 30);
            this.lblAddNewTitle.Name = "lblAddNewTitle";
            this.lblAddNewTitle.Size = new System.Drawing.Size(304, 24);
            this.lblAddNewTitle.TabIndex = 5;
            this.lblAddNewTitle.Text = "Driver International License Info";
            // 
            // ctrlDriverInternationalLicenseInfo1
            // 
            this.ctrlDriverInternationalLicenseInfo1.Location = new System.Drawing.Point(12, 91);
            this.ctrlDriverInternationalLicenseInfo1.Name = "ctrlDriverInternationalLicenseInfo1";
            this.ctrlDriverInternationalLicenseInfo1.Size = new System.Drawing.Size(624, 239);
            this.ctrlDriverInternationalLicenseInfo1.TabIndex = 6;
            // 
            // frmShowIntrenationDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 334);
            this.Controls.Add(this.ctrlDriverInternationalLicenseInfo1);
            this.Controls.Add(this.lblAddNewTitle);
            this.Name = "frmShowIntrenationDriverInfo";
            this.Text = "frmShowIntrenationDriverInfo";
            this.Load += new System.EventHandler(this.frmShowIntrenationDriverInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddNewTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ctrlDriverInternationalLicenseInfo ctrlDriverInternationalLicenseInfo1;
    }
}