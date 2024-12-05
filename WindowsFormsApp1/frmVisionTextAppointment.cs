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
    public partial class frmVisionTextAppointment : Form
    {

        int ApplicationID = -1;
        public frmVisionTextAppointment(int ApplicationID)
        {
            InitializeComponent();
            this.ApplicationID=ApplicationID;
        }

        private void _LoadDataToctrlLoacalLicenseInfo(int ID)
        {
            clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByLicenseID(ID);

            if (_LocalDrivingLicenseApplication != null)
            {
                ctrlLocalDrivingLicenseInfo1.LocalLicenseID = _LocalDrivingLicenseApplication.LocalLicenseID.ToString();
                ctrlLocalDrivingLicenseInfo1.LicenseClassText = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
                // ctrlLocalDrivingLicenseInfo1.PassedTestText = _LocalDrivingLicenseApplication.test
                ctrlLocalDrivingLicenseInfo1.ApplicationID = _LocalDrivingLicenseApplication.ApplicationID.ToString();
                ctrlLocalDrivingLicenseInfo1.StatusText = _LocalDrivingLicenseApplication.ApplicationStatus.ToString();
                ctrlLocalDrivingLicenseInfo1.Fees = _LocalDrivingLicenseApplication.PaidFees.ToString();
                ctrlLocalDrivingLicenseInfo1.TypeText = _LocalDrivingLicenseApplication.ApplicationTypeInfo.ApplicationTypeName;
                ctrlLocalDrivingLicenseInfo1.ApplicantPerson = _LocalDrivingLicenseApplication.ApplicantFullName.ToString();
                ctrlLocalDrivingLicenseInfo1.DateText = _LocalDrivingLicenseApplication.ApplicationDate.ToString();
                ctrlLocalDrivingLicenseInfo1.StatusDateText = _LocalDrivingLicenseApplication.LastStatusDate.ToString();
                ctrlLocalDrivingLicenseInfo1.CreatedByText = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName.ToString();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVisionTextAppointment_Load(object sender, EventArgs e)
        {
            _LoadDataToctrlLoacalLicenseInfo(ApplicationID);
        }
    }
}
