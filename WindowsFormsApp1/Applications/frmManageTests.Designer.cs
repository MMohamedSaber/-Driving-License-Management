namespace WindowsFormsApp1
{
    partial class frmManageTests
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsTestTypes = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvTestType = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "# Records :  ";
            // 
            // lblRecordsTestTypes
            // 
            this.lblRecordsTestTypes.AutoSize = true;
            this.lblRecordsTestTypes.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsTestTypes.Location = new System.Drawing.Point(108, 511);
            this.lblRecordsTestTypes.Name = "lblRecordsTestTypes";
            this.lblRecordsTestTypes.Size = new System.Drawing.Size(25, 16);
            this.lblRecordsTestTypes.TabIndex = 7;
            this.lblRecordsTestTypes.Text = "???";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(186, 212);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 27);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Manage Test Types";
            // 
            // dgvTestType
            // 
            this.dgvTestType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestType.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTestType.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTestType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestType.Location = new System.Drawing.Point(21, 262);
            this.dgvTestType.Name = "dgvTestType";
            this.dgvTestType.Size = new System.Drawing.Size(616, 246);
            this.dgvTestType.TabIndex = 4;
            this.dgvTestType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestType_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.TestType_512;
            this.pictureBox1.Location = new System.Drawing.Point(236, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // editTestToolStripMenuItem
            // 
            this.editTestToolStripMenuItem.Name = "editTestToolStripMenuItem";
            this.editTestToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editTestToolStripMenuItem.Text = "EditTest";
            this.editTestToolStripMenuItem.Click += new System.EventHandler(this.editTestToolStripMenuItem_Click);
            // 
            // frmManageTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 549);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordsTestTypes);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvTestType);
            this.Name = "frmManageTests";
            this.Text = "frmManageTests";
            this.Load += new System.EventHandler(this.frmManageTests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsTestTypes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvTestType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editTestToolStripMenuItem;
    }
}