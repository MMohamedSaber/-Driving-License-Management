using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public string ClassName {
            set
            {

                lblclassName.Text = value;
            }
        }
        public string Name
        {
            set
            {

                lblPersonname.Text = value;
            }
        }
        public string LicenseID
        {
            get
            {
                return lblLicenseID.Text;
            }
            set
            {

                lblLicenseID.Text = value;
            }
        }
        public string NationalNo
        {
            set
            {

                lblNationalNo.Text = value;
            }
        }
        public string Gender
        {
            set
            {

                lblGender.Text = value;
            }
        }
        public string IssueDate
        {
            set
            {

                lblIssueDate.Text = value;
            }
        }
        public string IssueReason
        {
            set
            {

                lblIssueReason.Text = value;
            }
        }
        public string Notes {
                set
            {

                    lblNotes.Text = value;
                }
            }
        public string IsActive
        {
            set
            {

                lblIsActive.Text = value;
            }
        }
        public string DateOfBirth
        {
            set
            {

                lblDateOfBirth.Text = value;
            }
        }
        public string DriverID
        {
            set
            {

                lblDriverID.Text = value;
            }
        }
        public string ExpirationDate 
            {
            set
            {

                lblExpirationDate.Text = value;
            }
}

    public string IsDetained
        {
            set
            {

                lblIsDetained.Text = value;
            }
        }

        public string mainphoto
        {
            set 
            {
                ProfilePhoto.ImageLocation= value;
            }
        }

        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
