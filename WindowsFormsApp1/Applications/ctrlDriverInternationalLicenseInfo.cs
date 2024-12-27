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
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {




      
        public string Name
        {
            set
            {

                lblName.Text = value;
            }
        }

        public string InterNationalLicense
        {
            set
            {
                lblInternLicenseID.Text = value;
            }
        }



        public string InterNationalApplication
        {
            set
            {
                lblApplicationID.Text = value;
            }
        }


        public string LicenseID
        {
            //get
            //{
            //    return lblLicenseID.Text;
            //}
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

     

        public string mainphoto
        {
            set
            {
                ProfilePhoto.ImageLocation = value;
            }
        }




        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
