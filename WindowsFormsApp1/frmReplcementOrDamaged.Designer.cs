namespace WindowsFormsApp1
{
    partial class frmReplcementOrDamaged
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.linkLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Fees = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCreatedUser = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplciationdate = new System.Windows.Forms.Label();
            this.lblRenewLicenseID = new System.Windows.Forms.Label();
            this.lblRenewApplicationID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.ctrlInterNationalDrivingLicense1 = new WindowsFormsApp1.ctrlInterNationalDrivingLicense();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(126, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(345, 24);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "Replacement For Damaged License";
            // 
            // linkLicenseInfo
            // 
            this.linkLicenseInfo.AutoSize = true;
            this.linkLicenseInfo.Location = new System.Drawing.Point(145, 524);
            this.linkLicenseInfo.Name = "linkLicenseInfo";
            this.linkLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.linkLicenseInfo.TabIndex = 23;
            this.linkLicenseInfo.TabStop = true;
            this.linkLicenseInfo.Text = "Show Licnese Info";
            this.linkLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseInfo_LinkClicked);
            // 
            // linkLicenseHistory
            // 
            this.linkLicenseHistory.AutoSize = true;
            this.linkLicenseHistory.Location = new System.Drawing.Point(12, 524);
            this.linkLicenseHistory.Name = "linkLicenseHistory";
            this.linkLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.linkLicenseHistory.TabIndex = 24;
            this.linkLicenseHistory.TabStop = true;
            this.linkLicenseHistory.Text = "Show Licnese History";
            this.linkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseHistory_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.lblOldLicenseID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.Fees);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblCreatedUser);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.lblApplciationdate);
            this.groupBox1.Controls.Add(this.lblRenewLicenseID);
            this.groupBox1.Controls.Add(this.lblRenewApplicationID);
            this.groupBox1.Location = new System.Drawing.Point(5, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 127);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application New License Info";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::WindowsFormsApp1.Properties.Resources.Number_32;
            this.pictureBox9.Location = new System.Drawing.Point(115, 31);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(28, 20);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 61;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::WindowsFormsApp1.Properties.Resources.License_View_32;
            this.pictureBox8.Location = new System.Drawing.Point(418, 58);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(28, 20);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 62;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::WindowsFormsApp1.Properties.Resources.Person_32;
            this.pictureBox6.Location = new System.Drawing.Point(418, 87);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(28, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 69;
            this.pictureBox6.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblOldLicenseID.Location = new System.Drawing.Point(452, 57);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(27, 16);
            this.lblOldLicenseID.TabIndex = 61;
            this.lblOldLicenseID.Text = "????";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(311, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 16);
            this.label10.TabIndex = 64;
            this.label10.Text = "Created by User:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(329, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 60;
            this.label11.Text = "OldLicenseID:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.money_321;
            this.pictureBox3.Location = new System.Drawing.Point(115, 83);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 68;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Calendar_321;
            this.pictureBox1.Location = new System.Drawing.Point(115, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // Fees
            // 
            this.Fees.AutoSize = true;
            this.Fees.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fees.ForeColor = System.Drawing.Color.Black;
            this.Fees.Location = new System.Drawing.Point(8, 85);
            this.Fees.Name = "Fees";
            this.Fees.Size = new System.Drawing.Size(100, 16);
            this.Fees.TabIndex = 65;
            this.Fees.Text = "Application Fees:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WindowsFormsApp1.Properties.Resources.Renew_Driving_License_322;
            this.pictureBox4.Location = new System.Drawing.Point(418, 31);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 68;
            this.pictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "ApplicationDate:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(307, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 65;
            this.label8.Text = "RenewLicenseID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "R.L.ApplicationID:";
            // 
            // lblCreatedUser
            // 
            this.lblCreatedUser.AutoSize = true;
            this.lblCreatedUser.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedUser.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedUser.Location = new System.Drawing.Point(452, 85);
            this.lblCreatedUser.Name = "lblCreatedUser";
            this.lblCreatedUser.Size = new System.Drawing.Size(27, 16);
            this.lblCreatedUser.TabIndex = 67;
            this.lblCreatedUser.Text = "????";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationFees.Location = new System.Drawing.Point(149, 83);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(14, 16);
            this.lblApplicationFees.TabIndex = 66;
            this.lblApplicationFees.Text = "0";
            // 
            // lblApplciationdate
            // 
            this.lblApplciationdate.AutoSize = true;
            this.lblApplciationdate.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplciationdate.ForeColor = System.Drawing.Color.Black;
            this.lblApplciationdate.Location = new System.Drawing.Point(149, 58);
            this.lblApplciationdate.Name = "lblApplciationdate";
            this.lblApplciationdate.Size = new System.Drawing.Size(14, 16);
            this.lblApplciationdate.TabIndex = 66;
            this.lblApplciationdate.Text = "4";
            // 
            // lblRenewLicenseID
            // 
            this.lblRenewLicenseID.AutoSize = true;
            this.lblRenewLicenseID.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblRenewLicenseID.Location = new System.Drawing.Point(452, 31);
            this.lblRenewLicenseID.Name = "lblRenewLicenseID";
            this.lblRenewLicenseID.Size = new System.Drawing.Size(27, 16);
            this.lblRenewLicenseID.TabIndex = 66;
            this.lblRenewLicenseID.Text = "????";
            // 
            // lblRenewApplicationID
            // 
            this.lblRenewApplicationID.AutoSize = true;
            this.lblRenewApplicationID.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lblRenewApplicationID.Location = new System.Drawing.Point(144, 31);
            this.lblRenewApplicationID.Name = "lblRenewApplicationID";
            this.lblRenewApplicationID.Size = new System.Drawing.Size(27, 16);
            this.lblRenewApplicationID.TabIndex = 66;
            this.lblRenewApplicationID.Text = "????";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLostLicense);
            this.groupBox2.Controls.Add(this.rbDamaged);
            this.groupBox2.Location = new System.Drawing.Point(502, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 75);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacement For:";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(6, 42);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(85, 17);
            this.rbLostLicense.TabIndex = 0;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Checked = true;
            this.rbDamaged.Location = new System.Drawing.Point(6, 19);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(105, 17);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Dmaged License";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::WindowsFormsApp1.Properties.Resources.Close_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCancel.Location = new System.Drawing.Point(443, 524);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(82, 36);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnIssue
            // 
            this.btnIssue.Image = global::WindowsFormsApp1.Properties.Resources.Renew_Driving_License_323;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIssue.Location = new System.Drawing.Point(531, 524);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnIssue.Size = new System.Drawing.Size(120, 36);
            this.btnIssue.TabIndex = 22;
            this.btnIssue.Text = "Issue Replacement";
            this.btnIssue.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // ctrlInterNationalDrivingLicense1
            // 
            this.ctrlInterNationalDrivingLicense1.Location = new System.Drawing.Point(5, 38);
            this.ctrlInterNationalDrivingLicense1.Name = "ctrlInterNationalDrivingLicense1";
            this.ctrlInterNationalDrivingLicense1.Size = new System.Drawing.Size(662, 358);
            this.ctrlInterNationalDrivingLicense1.TabIndex = 19;
            // 
            // frmReplcementOrDamaged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.linkLicenseInfo);
            this.Controls.Add(this.linkLicenseHistory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrlInterNationalDrivingLicense1);
            this.Name = "frmReplcementOrDamaged";
            this.Text = "frmReplcementOrDamaged";
            this.Load += new System.EventHandler(this.frmReplcementOrDamaged_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel linkLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLicenseHistory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Fees;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCreatedUser;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplciationdate;
        private System.Windows.Forms.Label lblRenewLicenseID;
        private System.Windows.Forms.Label lblRenewApplicationID;
        private System.Windows.Forms.Button btnIssue;
        private ctrlInterNationalDrivingLicense ctrlInterNationalDrivingLicense1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamaged;
    }
}