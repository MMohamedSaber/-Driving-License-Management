namespace WindowsFormsApp1
{
    partial class frmMangeLocalLicensApplication
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
            this.components = new System.ComponentModel.Container();
            this.DGVLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterApplications = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEditApp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.sctxSdulVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.sctxSdulWritinTest = new System.Windows.Forms.ToolStripMenuItem();
            this.sctxSdulStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxIssueLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxShowPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDrivingLicenseApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVLocalDrivingLicenseApplications
            // 
            this.DGVLocalDrivingLicenseApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLocalDrivingLicenseApplications.Location = new System.Drawing.Point(12, 223);
            this.DGVLocalDrivingLicenseApplications.Name = "DGVLocalDrivingLicenseApplications";
            this.DGVLocalDrivingLicenseApplications.Size = new System.Drawing.Size(845, 312);
            this.DGVLocalDrivingLicenseApplications.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(229, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage Local Driving License Application";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(250, 173);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(134, 20);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cbFilterApplications
            // 
            this.cbFilterApplications.FormattingEnabled = true;
            this.cbFilterApplications.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "NationalNo",
            "FullName",
            "Status"});
            this.cbFilterApplications.Location = new System.Drawing.Point(103, 173);
            this.cbFilterApplications.Name = "cbFilterApplications";
            this.cbFilterApplications.Size = new System.Drawing.Size(121, 21);
            this.cbFilterApplications.TabIndex = 8;
            this.cbFilterApplications.SelectedIndexChanged += new System.EventHandler(this.cbFilterApplications_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter by : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 538);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "# Records :  ";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(100, 538);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(25, 16);
            this.lblRecords.TabIndex = 12;
            this.lblRecords.Text = "???";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxShowDetails,
            this.ctxEditApp,
            this.ctxDeleteApp,
            this.ctxCancelApp,
            this.ctxScheduleTests,
            this.ctxIssueLicense,
            this.ctxShowLicense,
            this.ctxShowPerson});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(246, 180);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxShowDetails
            // 
            this.ctxShowDetails.Image = global::WindowsFormsApp1.Properties.Resources.PersonDetails_32;
            this.ctxShowDetails.Name = "ctxShowDetails";
            this.ctxShowDetails.Size = new System.Drawing.Size(245, 22);
            this.ctxShowDetails.Text = "Show Application Detailes";
            // 
            // ctxEditApp
            // 
            this.ctxEditApp.Image = global::WindowsFormsApp1.Properties.Resources.edit_321;
            this.ctxEditApp.Name = "ctxEditApp";
            this.ctxEditApp.Size = new System.Drawing.Size(245, 22);
            this.ctxEditApp.Text = "Edit Application";
            // 
            // ctxDeleteApp
            // 
            this.ctxDeleteApp.Image = global::WindowsFormsApp1.Properties.Resources.Delete_32_2;
            this.ctxDeleteApp.Name = "ctxDeleteApp";
            this.ctxDeleteApp.Size = new System.Drawing.Size(245, 22);
            this.ctxDeleteApp.Text = "Delete Application";
            // 
            // ctxCancelApp
            // 
            this.ctxCancelApp.Image = global::WindowsFormsApp1.Properties.Resources.Delete_321;
            this.ctxCancelApp.Name = "ctxCancelApp";
            this.ctxCancelApp.Size = new System.Drawing.Size(245, 22);
            this.ctxCancelApp.Text = "Cancel Application";
            this.ctxCancelApp.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // ctxScheduleTests
            // 
            this.ctxScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sctxSdulVisionTest,
            this.sctxSdulWritinTest,
            this.sctxSdulStreetTest});
            this.ctxScheduleTests.Image = global::WindowsFormsApp1.Properties.Resources.Schedule_Test_32;
            this.ctxScheduleTests.Name = "ctxScheduleTests";
            this.ctxScheduleTests.Size = new System.Drawing.Size(245, 22);
            this.ctxScheduleTests.Text = "Sechdual Test";
            this.ctxScheduleTests.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // sctxSdulVisionTest
            // 
            this.sctxSdulVisionTest.Image = global::WindowsFormsApp1.Properties.Resources.Vision_Test_32;
            this.sctxSdulVisionTest.Name = "sctxSdulVisionTest";
            this.sctxSdulVisionTest.Size = new System.Drawing.Size(180, 22);
            this.sctxSdulVisionTest.Text = "Schedual Vision Test";
            this.sctxSdulVisionTest.Click += new System.EventHandler(this.sctxSdulVisionTest_Click);
            // 
            // sctxSdulWritinTest
            // 
            this.sctxSdulWritinTest.Image = global::WindowsFormsApp1.Properties.Resources.Written_Test_32;
            this.sctxSdulWritinTest.Name = "sctxSdulWritinTest";
            this.sctxSdulWritinTest.Size = new System.Drawing.Size(180, 22);
            this.sctxSdulWritinTest.Text = "Schedual Writin Test";
            // 
            // sctxSdulStreetTest
            // 
            this.sctxSdulStreetTest.Image = global::WindowsFormsApp1.Properties.Resources.Street_Test_32;
            this.sctxSdulStreetTest.Name = "sctxSdulStreetTest";
            this.sctxSdulStreetTest.Size = new System.Drawing.Size(180, 22);
            this.sctxSdulStreetTest.Text = "Schedual Street Test";
            // 
            // ctxIssueLicense
            // 
            this.ctxIssueLicense.Name = "ctxIssueLicense";
            this.ctxIssueLicense.Size = new System.Drawing.Size(245, 22);
            this.ctxIssueLicense.Text = "Issue Driving License (First Time)";
            this.ctxIssueLicense.Click += new System.EventHandler(this.issueToolStripMenuItem_Click);
            // 
            // ctxShowLicense
            // 
            this.ctxShowLicense.Name = "ctxShowLicense";
            this.ctxShowLicense.Size = new System.Drawing.Size(245, 22);
            this.ctxShowLicense.Text = "Show License";
            // 
            // ctxShowPerson
            // 
            this.ctxShowPerson.Image = global::WindowsFormsApp1.Properties.Resources.PersonLicenseHistory_32;
            this.ctxShowPerson.Name = "ctxShowPerson";
            this.ctxShowPerson.Size = new System.Drawing.Size(245, 22);
            this.ctxShowPerson.Text = "Show Person License History";
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.AutoSize = true;
            this.btnAddNewApplication.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNewApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddNewApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewApplication.Image = global::WindowsFormsApp1.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.Location = new System.Drawing.Point(718, 134);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(70, 70);
            this.btnAddNewApplication.TabIndex = 13;
            this.btnAddNewApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(362, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // frmMangeLocalLicensApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 569);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterApplications);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVLocalDrivingLicenseApplications);
            this.Name = "frmMangeLocalLicensApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMangeLocalLicensApplication";
            this.Load += new System.EventHandler(this.frmMangeLocalLicensApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDrivingLicenseApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVLocalDrivingLicenseApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterApplications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxShowDetails;
        private System.Windows.Forms.ToolStripMenuItem ctxEditApp;
        private System.Windows.Forms.ToolStripMenuItem ctxDeleteApp;
        private System.Windows.Forms.ToolStripMenuItem ctxCancelApp;
        private System.Windows.Forms.ToolStripMenuItem ctxScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem ctxIssueLicense;
        private System.Windows.Forms.ToolStripMenuItem ctxShowLicense;
        private System.Windows.Forms.ToolStripMenuItem ctxShowPerson;
        private System.Windows.Forms.ToolStripMenuItem sctxSdulVisionTest;
        private System.Windows.Forms.ToolStripMenuItem sctxSdulWritinTest;
        private System.Windows.Forms.ToolStripMenuItem sctxSdulStreetTest;
    }
}