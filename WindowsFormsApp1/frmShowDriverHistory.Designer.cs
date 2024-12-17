namespace WindowsFormsApp1
{
    partial class frmShowDriverHistory
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
            this.ucFilteringData1 = new WindowsFormsApp1.UCFilteringData();
            this.ctrDriverLicense1 = new WindowsFormsApp1.ctrDriverLicense();
            this.SuspendLayout();
            // 
            // ucFilteringData1
            // 
            this.ucFilteringData1.Location = new System.Drawing.Point(12, 12);
            this.ucFilteringData1.Name = "ucFilteringData1";
            this.ucFilteringData1.Size = new System.Drawing.Size(609, 266);
            this.ucFilteringData1.TabIndex = 0;
            this.ucFilteringData1.Load += new System.EventHandler(this.ucFilteringData1_Load);
            // 
            // ctrDriverLicense1
            // 
            this.ctrDriverLicense1.Location = new System.Drawing.Point(12, 295);
            this.ctrDriverLicense1.Name = "ctrDriverLicense1";
            this.ctrDriverLicense1.Size = new System.Drawing.Size(609, 303);
            this.ctrDriverLicense1.TabIndex = 1;
            // 
            // frmShowDriverHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 610);
            this.Controls.Add(this.ctrDriverLicense1);
            this.Controls.Add(this.ucFilteringData1);
            this.Name = "frmShowDriverHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowDriverHistory";
            this.Load += new System.EventHandler(this.frmShowDriverHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCFilteringData ucFilteringData1;
        private ctrDriverLicense ctrDriverLicense1;
    }
}