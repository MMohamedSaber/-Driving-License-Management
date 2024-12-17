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
    public partial class frmShowDriverHistory : Form
    {

        int _applicationID = -1;
        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
        clsLicense License;
        public frmShowDriverHistory()
        {

            InitializeComponent();

        } 
        
        public frmShowDriverHistory(int ApplicationID)
        {
            InitializeComponent();
            _applicationID = ApplicationID;
        }



     

        private void frmShowDriverHistory_Load(object sender, EventArgs e)
        {
             LocalDrivingLicenseApplication =
                  clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByAppID(_applicationID);

            License=clsLicense.FindByApplicationID(LocalDrivingLicenseApplication.ApplicationID);

            ucFilteringData1.txtSearch = LocalDrivingLicenseApplication.ApplicantPersonInfo.NationalNo.ToString();
            ucFilteringData1.DiableFilter();

            ctrDriverLicense1.LoadDriverInDgv(License.DriverID);

        }

        private void ucFilteringData1_Load(object sender, EventArgs e)
        {

        }
    }
}
