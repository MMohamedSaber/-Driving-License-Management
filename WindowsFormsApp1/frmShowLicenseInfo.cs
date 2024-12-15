using DVLBuisnesLayer;
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
    public partial class frmShowLicenseInfo : Form
    {
        int LocalDrivingLicenseAppID = -1;
        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
        clsLicense License;

        public frmShowLicenseInfo()
        {
            InitializeComponent();



        }

        public frmShowLicenseInfo(int localDrivingLicenseApplicaionID)
        {
            InitializeComponent();

            LocalDrivingLicenseAppID=localDrivingLicenseApplicaionID;



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.
                FindLocalDrivingLicenseAppByLocalLicenseID(LocalDrivingLicenseAppID);

            License=clsLicense.FindByApplicationID(LocalDrivingLicenseApplication.ApplicationID);

            ctrlDriverLicenseInfo1.ClassName=LocalDrivingLicenseApplication.LicenseClassInfo.ClassName.ToString();
            ctrlDriverLicenseInfo1.Name=LocalDrivingLicenseApplication.ApplicantFullName;

            ctrlDriverLicenseInfo1.NationalNo=LocalDrivingLicenseApplication.ApplicantPersonInfo.NationalNo.ToString();

            ctrlDriverLicenseInfo1.LicenseID = License.LicenseID.ToString();
            ctrlDriverLicenseInfo1.IssueDate = License.IssueDate.ToString("dd/MM/yyyy");
            ctrlDriverLicenseInfo1.IssueReason = License.IssueReason.ToString();
            ctrlDriverLicenseInfo1.Notes = License.Notes;

            if (LocalDrivingLicenseApplication.ApplicantPersonInfo.Gender==0)
                ctrlDriverLicenseInfo1.Gender = "Male";
            else ctrlDriverLicenseInfo1.Gender = "Female";

            if (License.IsActive == true)
                ctrlDriverLicenseInfo1.IsActive = "Yes";
            else ctrlDriverLicenseInfo1.IsActive = "No";
            ctrlDriverLicenseInfo1.DateOfBirth=LocalDrivingLicenseApplication.ApplicantPersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            ctrlDriverLicenseInfo1.DriverID= License.DriverID.ToString();
            ctrlDriverLicenseInfo1.ExpirationDate= License.ExpirationDate.ToString("dd/MM/yyyy");

            ctrlDriverLicenseInfo1.IsDetained = "No";
            ctrlDriverLicenseInfo1.mainphoto = LocalDrivingLicenseApplication.ApplicantPersonInfo.ImagePath;

         



        }
    }
}
