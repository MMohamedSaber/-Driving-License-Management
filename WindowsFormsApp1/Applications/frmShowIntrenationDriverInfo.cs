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
    public partial class frmShowIntrenationDriverInfo : Form
    {
      private clsInternationalLicense _currentInterNational=new clsInternationalLicense();
        private clsLocalDrivingLicenseApplication _currentLocalDrivingLicenseApplication =new clsLocalDrivingLicenseApplication();
        private clsLicense _license=new clsLicense();
        private int _internationalID=-1;

        public frmShowIntrenationDriverInfo(int InterNationalLicenseID)
        {
            InitializeComponent();
            _internationalID = InterNationalLicenseID;
            _currentInterNational = clsInternationalLicense.Find(_internationalID);


        }


        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            


        }
        private void frmShowIntrenationDriverInfo_Load(object sender, EventArgs e)
        {


            //_currentLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.
            //    FindLocalDrivingLicenseAppByLocalLicenseID(_currentInterNational.ApplicationID);

            _license = clsLicense.FindByApplicationID(_currentInterNational.ApplicationID);



            ctrlDriverInternationalLicenseInfo1.InterNationalLicense=  _currentInterNational.InternationalLicenseID.ToString();
            ctrlDriverInternationalLicenseInfo1.InterNationalApplication=_currentInterNational.ApplicationID.ToString();
            ctrlDriverInternationalLicenseInfo1.Name = _currentInterNational.ApplicationInfo.ApplicantFullName;

            ctrlDriverInternationalLicenseInfo1.NationalNo = _currentInterNational.ApplicationInfo.ApplicantPersonInfo.NationalNo.ToString();

            ctrlDriverInternationalLicenseInfo1.LicenseID = _license.LicenseID.ToString();
            ctrlDriverInternationalLicenseInfo1.IssueDate = _license.IssueDate.ToString("dd/MM/yyyy");

            if (_currentInterNational.ApplicationInfo.ApplicantPersonInfo.Gender == 0)
                ctrlDriverInternationalLicenseInfo1.Gender = "Male";
            else ctrlDriverInternationalLicenseInfo1.Gender = "Female";

            if (_license.IsActive == true)
                ctrlDriverInternationalLicenseInfo1.IsActive = "Yes";
            else ctrlDriverInternationalLicenseInfo1.IsActive = "No";
            ctrlDriverInternationalLicenseInfo1.DateOfBirth = _currentInterNational.ApplicationInfo.ApplicantPersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            ctrlDriverInternationalLicenseInfo1.DriverID = _license.DriverID.ToString();
            ctrlDriverInternationalLicenseInfo1.ExpirationDate = _license.ExpirationDate.ToString("dd/MM/yyyy");

            ctrlDriverInternationalLicenseInfo1.mainphoto = _currentInterNational.ApplicationInfo.ApplicantPersonInfo.ImagePath;






        }
    }
}
