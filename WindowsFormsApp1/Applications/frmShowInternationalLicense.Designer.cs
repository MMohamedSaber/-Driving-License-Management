namespace WindowsFormsApp1
{
    partial class frmShowInternationalLicense
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
            this.btnAddNewInternationalL = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterInerNationalLicense = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVinterNationalLicense = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVinterNationalLicense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNewInternationalL
            // 
            this.btnAddNewInternationalL.AutoSize = true;
            this.btnAddNewInternationalL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNewInternationalL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddNewInternationalL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewInternationalL.Image = global::WindowsFormsApp1.Properties.Resources.New_Application_64;
            this.btnAddNewInternationalL.Location = new System.Drawing.Point(718, 142);
            this.btnAddNewInternationalL.Name = "btnAddNewInternationalL";
            this.btnAddNewInternationalL.Size = new System.Drawing.Size(70, 70);
            this.btnAddNewInternationalL.TabIndex = 22;
            this.btnAddNewInternationalL.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnAddNewInternationalL.UseVisualStyleBackColor = true;
            this.btnAddNewInternationalL.Click += new System.EventHandler(this.btnAddNewInternationalL_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "# Records :  ";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(100, 546);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(25, 16);
            this.lblRecords.TabIndex = 21;
            this.lblRecords.Text = "???";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(250, 181);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(134, 20);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cbFilterInerNationalLicense
            // 
            this.cbFilterInerNationalLicense.FormattingEnabled = true;
            this.cbFilterInerNationalLicense.Items.AddRange(new object[] {
            "None",
            "InternationalLicenseID",
            "DriverID",
            "IsActive"});
            this.cbFilterInerNationalLicense.Location = new System.Drawing.Point(103, 181);
            this.cbFilterInerNationalLicense.Name = "cbFilterInerNationalLicense";
            this.cbFilterInerNationalLicense.Size = new System.Drawing.Size(121, 21);
            this.cbFilterInerNationalLicense.TabIndex = 18;
            this.cbFilterInerNationalLicense.SelectedIndexChanged += new System.EventHandler(this.cbFilterInerNationalLicense_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Filter by : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(358, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(273, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Manage InterNational license ";
            // 
            // DGVinterNationalLicense
            // 
            this.DGVinterNationalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVinterNationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVinterNationalLicense.Location = new System.Drawing.Point(12, 231);
            this.DGVinterNationalLicense.Name = "DGVinterNationalLicense";
            this.DGVinterNationalLicense.Size = new System.Drawing.Size(845, 312);
            this.DGVinterNationalLicense.TabIndex = 14;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.ctxShowLicenseDetails,
            this.ctxShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 70);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // ctxShowLicenseDetails
            // 
            this.ctxShowLicenseDetails.Name = "ctxShowLicenseDetails";
            this.ctxShowLicenseDetails.Size = new System.Drawing.Size(225, 22);
            this.ctxShowLicenseDetails.Text = "Show License Details";
            this.ctxShowLicenseDetails.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // ctxShowPersonLicenseHistory
            // 
            this.ctxShowPersonLicenseHistory.Name = "ctxShowPersonLicenseHistory";
            this.ctxShowPersonLicenseHistory.Size = new System.Drawing.Size(225, 22);
            this.ctxShowPersonLicenseHistory.Text = "Show Person License Histroy";
            this.ctxShowPersonLicenseHistory.Click += new System.EventHandler(this.showToolStripMenuItem1_Click);
            // 
            // frmShowInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 594);
            this.Controls.Add(this.btnAddNewInternationalL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterInerNationalLicense);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVinterNationalLicense);
            this.Name = "frmShowInternationalLicense";
            this.Text = "frmShowInternationalLicense";
            this.Load += new System.EventHandler(this.frmShowInternationalLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVinterNationalLicense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewInternationalL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterInerNationalLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVinterNationalLicense;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem ctxShowPersonLicenseHistory;
    }
}