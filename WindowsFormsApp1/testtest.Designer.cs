namespace WindowsFormsApp1
{
    partial class testtest
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
            this.SuspendLayout();
            // 
            // ucFilteringData1
            // 
            this.ucFilteringData1.Location = new System.Drawing.Point(62, 43);
            this.ucFilteringData1.Name = "ucFilteringData1";
            this.ucFilteringData1.Size = new System.Drawing.Size(596, 280);
            this.ucFilteringData1.TabIndex = 0;
            // 
            // testtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucFilteringData1);
            this.Name = "testtest";
            this.Text = "testtest";
            this.ResumeLayout(false);

        }

        #endregion

        private UCFilteringData ucFilteringData1;
    }
}