namespace WindowsFormsApp1
{
    partial class frmIssueLicense
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.btnIssue = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlLocalDrivingLicenseInfo1 = new WindowsFormsApp1.ctrlLocalDrivingLicenseInfo();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Notes: ";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(83, 330);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(590, 71);
            this.txtNotes.TabIndex = 9;
            this.txtNotes.Text = "";
            // 
            // btnIssue
            // 
            this.btnIssue.Image = global::WindowsFormsApp1.Properties.Resources.IssueDrivingLicense_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.Location = new System.Drawing.Point(591, 402);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(82, 36);
            this.btnIssue.TabIndex = 10;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // button1
            // 
            this.button1.Image = global::WindowsFormsApp1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(477, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ctrlLocalDrivingLicenseInfo1
            // 
            this.ctrlLocalDrivingLicenseInfo1.ApplicationID = "????";
            this.ctrlLocalDrivingLicenseInfo1.Fees = "????";
            this.ctrlLocalDrivingLicenseInfo1.LicenseClassText = "????";
            this.ctrlLocalDrivingLicenseInfo1.LocalLicenseID = "????";
            this.ctrlLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLocalDrivingLicenseInfo1.Name = "ctrlLocalDrivingLicenseInfo1";
            this.ctrlLocalDrivingLicenseInfo1.PassedTestText = "????";
            this.ctrlLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(671, 312);
            this.ctrlLocalDrivingLicenseInfo1.StatusDateText = "????";
            this.ctrlLocalDrivingLicenseInfo1.StatusText = "????";
            this.ctrlLocalDrivingLicenseInfo1.TabIndex = 0;
            this.ctrlLocalDrivingLicenseInfo1.TypeText = "????";
            // 
            // frmIssueLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlLocalDrivingLicenseInfo1);
            this.Name = "frmIssueLicense";
            this.Text = "frmIssueLicense";
            this.Load += new System.EventHandler(this.frmIssueLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLocalDrivingLicenseInfo ctrlLocalDrivingLicenseInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button button1;
    }
}