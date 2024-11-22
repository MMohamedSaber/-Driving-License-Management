namespace WindowsFormsApp1
{
    partial class frmUserDetails
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
            this.ucUserInformation1 = new WindowsFormsApp1.ucUserInformation();
            this.SuspendLayout();
            // 
            // ucUserInformation1
            // 
            this.ucUserInformation1.Location = new System.Drawing.Point(12, 12);
            this.ucUserInformation1.Name = "ucUserInformation1";
            this.ucUserInformation1.Size = new System.Drawing.Size(608, 304);
            this.ucUserInformation1.TabIndex = 0;
            this.ucUserInformation1.Load += new System.EventHandler(this.ucUserInformation1_Load);
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 324);
            this.Controls.Add(this.ucUserInformation1);
            this.Name = "frmUserDetails";
            this.Text = "frmUserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucUserInformation ucUserInformation1;
    }
}