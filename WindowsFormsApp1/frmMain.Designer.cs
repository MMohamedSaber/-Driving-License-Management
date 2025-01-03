﻿namespace WindowsFormsApp1
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interNationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reNewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForDamagedOrLostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fffToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interNationalLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accounTSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accounTSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(20);
            this.menuStrip1.Size = new System.Drawing.Size(1252, 94);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fffToolStripMenuItem1,
            this.fffToolStripMenuItem2,
            this.fffToolStripMenuItem,
            this.manageApplicationTypeToolStripMenuItem,
            this.manageTestsToolStripMenuItem});
            this.applicationsToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Applications_64;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(190, 54);
            this.applicationsToolStripMenuItem.Text = "Applications";
            this.applicationsToolStripMenuItem.Click += new System.EventHandler(this.applicationsToolStripMenuItem_Click);
            // 
            // fffToolStripMenuItem1
            // 
            this.fffToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.reNewDrivingLicenseToolStripMenuItem,
            this.replacementForDamagedOrLostToolStripMenuItem,
            this.releaseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.fffToolStripMenuItem1.Image = global::WindowsFormsApp1.Properties.Resources.LocalDriving_License;
            this.fffToolStripMenuItem1.Name = "fffToolStripMenuItem1";
            this.fffToolStripMenuItem1.Size = new System.Drawing.Size(356, 56);
            this.fffToolStripMenuItem1.Text = "Driving License Services";
            this.fffToolStripMenuItem1.Click += new System.EventHandler(this.fffToolStripMenuItem1_Click);
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.interNationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.License_Type_32;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Local_32;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(317, 56);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // interNationalLicenseToolStripMenuItem
            // 
            this.interNationalLicenseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.International_322;
            this.interNationalLicenseToolStripMenuItem.Name = "interNationalLicenseToolStripMenuItem";
            this.interNationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(317, 56);
            this.interNationalLicenseToolStripMenuItem.Text = "InterNational License";
            this.interNationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.interNationalLicenseToolStripMenuItem_Click);
            // 
            // reNewDrivingLicenseToolStripMenuItem
            // 
            this.reNewDrivingLicenseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Renew_Driving_License_321;
            this.reNewDrivingLicenseToolStripMenuItem.Name = "reNewDrivingLicenseToolStripMenuItem";
            this.reNewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.reNewDrivingLicenseToolStripMenuItem.Text = "ReNew Driving License";
            this.reNewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.reNewDrivingLicenseToolStripMenuItem_Click);
            // 
            // replacementForDamagedOrLostToolStripMenuItem
            // 
            this.replacementForDamagedOrLostToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Damaged_Driving_License_32;
            this.replacementForDamagedOrLostToolStripMenuItem.Name = "replacementForDamagedOrLostToolStripMenuItem";
            this.replacementForDamagedOrLostToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.replacementForDamagedOrLostToolStripMenuItem.Text = "Replacement For Damaged or Lost";
            this.replacementForDamagedOrLostToolStripMenuItem.Click += new System.EventHandler(this.replacementForDamagedOrLostToolStripMenuItem_Click);
            // 
            // releaseToolStripMenuItem
            // 
            this.releaseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Detained_Driving_License_32;
            this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            this.releaseToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.releaseToolStripMenuItem.Text = "Release Detaind Driving License";
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Retake_Test_32;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(438, 56);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            // 
            // fffToolStripMenuItem2
            // 
            this.fffToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationToolStripMenuItem,
            this.interNationalLicenseApplicationToolStripMenuItem});
            this.fffToolStripMenuItem2.Image = global::WindowsFormsApp1.Properties.Resources.AddAppointment_321;
            this.fffToolStripMenuItem2.Name = "fffToolStripMenuItem2";
            this.fffToolStripMenuItem2.Size = new System.Drawing.Size(356, 56);
            this.fffToolStripMenuItem2.Text = "Manage Appointment";
            // 
            // localDrivingLicenseApplicationToolStripMenuItem
            // 
            this.localDrivingLicenseApplicationToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.New_Driving_License_32;
            this.localDrivingLicenseApplicationToolStripMenuItem.Name = "localDrivingLicenseApplicationToolStripMenuItem";
            this.localDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(430, 56);
            this.localDrivingLicenseApplicationToolStripMenuItem.Text = "LocalDrivingLicenseApplication";
            this.localDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // interNationalLicenseApplicationToolStripMenuItem
            // 
            this.interNationalLicenseApplicationToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.International_32;
            this.interNationalLicenseApplicationToolStripMenuItem.Name = "interNationalLicenseApplicationToolStripMenuItem";
            this.interNationalLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(430, 56);
            this.interNationalLicenseApplicationToolStripMenuItem.Text = "InterNational License Application";
            this.interNationalLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.interNationalLicenseApplicationToolStripMenuItem_Click);
            // 
            // fffToolStripMenuItem
            // 
            this.fffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicenseToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.fffToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Detain_641;
            this.fffToolStripMenuItem.Name = "fffToolStripMenuItem";
            this.fffToolStripMenuItem.Size = new System.Drawing.Size(356, 56);
            this.fffToolStripMenuItem.Text = "Detain License";
            // 
            // manageDetainedLicenseToolStripMenuItem
            // 
            this.manageDetainedLicenseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Detain_321;
            this.manageDetainedLicenseToolStripMenuItem.Name = "manageDetainedLicenseToolStripMenuItem";
            this.manageDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(358, 56);
            this.manageDetainedLicenseToolStripMenuItem.Text = "Manage Detained License";
            this.manageDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicenseToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Detain_321;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(358, 56);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Release_Detained_License_322;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(358, 56);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // manageApplicationTypeToolStripMenuItem
            // 
            this.manageApplicationTypeToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.code_12371942;
            this.manageApplicationTypeToolStripMenuItem.Name = "manageApplicationTypeToolStripMenuItem";
            this.manageApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(356, 56);
            this.manageApplicationTypeToolStripMenuItem.Text = "Manage Application Type";
            this.manageApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypeToolStripMenuItem_Click);
            // 
            // manageTestsToolStripMenuItem
            // 
            this.manageTestsToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Schedule_Test_321;
            this.manageTestsToolStripMenuItem.Name = "manageTestsToolStripMenuItem";
            this.manageTestsToolStripMenuItem.Size = new System.Drawing.Size(356, 56);
            this.manageTestsToolStripMenuItem.Text = "Manage Tests";
            this.manageTestsToolStripMenuItem.Click += new System.EventHandler(this.manageTestsToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Drivers_64;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(140, 54);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peopleToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(147, 54);
            this.peopleToolStripMenuItem.Text = "Peoples";
            this.peopleToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Add_New_User_72;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(125, 54);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accounTSettingToolStripMenuItem
            // 
            this.accounTSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.accounTSettingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accounTSettingToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.account_settings_64;
            this.accounTSettingToolStripMenuItem.Name = "accounTSettingToolStripMenuItem";
            this.accounTSettingToolStripMenuItem.Size = new System.Drawing.Size(204, 54);
            this.accounTSettingToolStripMenuItem.Text = "Account Settings";
            this.accounTSettingToolStripMenuItem.MouseHover += new System.EventHandler(this.accounTSettingToolStripMenuItem_MouseHover);
            // 
            // userInfoToolStripMenuItem
            // 
            this.userInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.PersonDetails_32;
            this.userInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.userInfoToolStripMenuItem.Name = "userInfoToolStripMenuItem";
            this.userInfoToolStripMenuItem.Size = new System.Drawing.Size(235, 38);
            this.userInfoToolStripMenuItem.Text = "User Info";
            this.userInfoToolStripMenuItem.Click += new System.EventHandler(this.userInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(235, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.sign_out_32__2;
            this.signOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(235, 38);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1252, 602);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("PT Simple Bold Ruled", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accounTSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fffToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fffToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interNationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reNewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForDamagedOrLostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interNationalLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}

