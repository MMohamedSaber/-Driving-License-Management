namespace WindowsFormsApp1
{
    partial class UCFilteringData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.cbFeltringData = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucPersonDetails1 = new WindowsFormsApp1.UCPersonDetails();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddNewPerson);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearchKey);
            this.groupBox1.Controls.Add(this.cbFeltringData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::WindowsFormsApp1.Properties.Resources.AddPerson_32;
            this.btnAddNewPerson.Location = new System.Drawing.Point(385, 19);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(43, 38);
            this.btnAddNewPerson.TabIndex = 6;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::WindowsFormsApp1.Properties.Resources.SearchPerson;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.Location = new System.Drawing.Point(336, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 38);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(217, 28);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(100, 20);
            this.txtSearchKey.TabIndex = 5;
            this.txtSearchKey.TextChanged += new System.EventHandler(this.txtSearchKey_TextChanged_1);
            this.txtSearchKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchKey_KeyPress_1);
            // 
            // cbFeltringData
            // 
            this.cbFeltringData.FormattingEnabled = true;
            this.cbFeltringData.Items.AddRange(new object[] {
            "NationalNo",
            "PersonID"});
            this.cbFeltringData.Location = new System.Drawing.Point(72, 27);
            this.cbFeltringData.Name = "cbFeltringData";
            this.cbFeltringData.Size = new System.Drawing.Size(121, 21);
            this.cbFeltringData.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By :";
            // 
            // ucPersonDetails1
            // 
            this.ucPersonDetails1.Location = new System.Drawing.Point(3, 81);
            this.ucPersonDetails1.Name = "ucPersonDetails1";
            this.ucPersonDetails1.PersonID = "???";
            this.ucPersonDetails1.Size = new System.Drawing.Size(583, 190);
            this.ucPersonDetails1.TabIndex = 1;
            this.ucPersonDetails1.Load += new System.EventHandler(this.ucPersonDetails1_Load);
            // 
            // UCFilteringData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPersonDetails1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCFilteringData";
            this.Size = new System.Drawing.Size(596, 280);
            this.Load += new System.EventHandler(this.UCFilteringData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.ComboBox cbFeltringData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private UCPersonDetails ucPersonDetails1;
    }
}
