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
using static DVLBuisnesLayer.clsTestType;

namespace WindowsFormsApp1
{
    public partial class frmIssueLicense : Form
    {

        clsDrivers Driver; 
        clsLicense License;

        clsLocalDrivingLicenseApplication localDrivingLicenseApp;
        int LocalDrivingLicenseApplicationID = -1;
        public frmIssueLicense(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            LocalDrivingLicenseApplicationID=localDrivingLicenseApplicationId;
        }

        private void _LoadDataToctrlLoacalLicenseInfo(int localDrivingLicenseApplicationId)
        {
             localDrivingLicenseApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByLocalLicenseID(localDrivingLicenseApplicationId);

            if (localDrivingLicenseApp == null)
            {
                MessageBox.Show("Invalid License ID or Data Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load appointments into the DataGridView
           


            // Populate control fields with license application information
            ctrlLocalDrivingLicenseInfo1.LocalLicenseID = localDrivingLicenseApp.LocalLicenseID.ToString();
            ctrlLocalDrivingLicenseInfo1.LicenseClassText = localDrivingLicenseApp.LicenseClassInfo.ClassName;
            ctrlLocalDrivingLicenseInfo1.PassedTestText = clsTest.GetPassedTestCount(localDrivingLicenseApp.LocalLicenseID).ToString();
            ctrlLocalDrivingLicenseInfo1.ApplicationID = localDrivingLicenseApp.ApplicationID.ToString();

            ctrlLocalDrivingLicenseInfo1.StatusText = localDrivingLicenseApp.ApplicationStatus.ToString();
            ctrlLocalDrivingLicenseInfo1.Fees = localDrivingLicenseApp.PaidFees.ToString();
            ctrlLocalDrivingLicenseInfo1.TypeText = localDrivingLicenseApp.ApplicationTypeInfo.ApplicationTypeName;
            ctrlLocalDrivingLicenseInfo1.ApplicantPerson = localDrivingLicenseApp.ApplicantFullName;
            ctrlLocalDrivingLicenseInfo1.DateText = localDrivingLicenseApp.ApplicationDate.ToString();
            ctrlLocalDrivingLicenseInfo1.StatusDateText = localDrivingLicenseApp.LastStatusDate.ToString();
            ctrlLocalDrivingLicenseInfo1.CreatedByText = localDrivingLicenseApp.CreatedByUserInfo.UserName;
        }
        private void frmIssueLicense_Load(object sender, EventArgs e)
        {
            _LoadDataToctrlLoacalLicenseInfo(LocalDrivingLicenseApplicationID);

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            Driver = new clsDrivers();
            License = new clsLicense();

            Driver.PersonID = localDrivingLicenseApp.ApplicantPersonID;
            Driver.CreatedByUser = localDrivingLicenseApp.CreatedByUserID;
            Driver.CreatedDate = localDrivingLicenseApp.ApplicationDate;


            License.ApplicationID = localDrivingLicenseApp.ApplicationID;
            License.LicenseClass = localDrivingLicenseApp.LicenseClassID;
            License.IssueDate = localDrivingLicenseApp.ApplicationDate;
            int validityLength = clsLicenseClasses.Find(License.LicenseClass).DefaultValidityLength;

            // Calculate the expiration date by adding the validity length to the application date
            License.ExpirationDate = localDrivingLicenseApp.ApplicationDate.AddYears(validityLength);
            License.Notes = txtNotes.Text;
            License.PaidFees = localDrivingLicenseApp.PaidFees;
            License.IsActive = true;
            License.IssueReason = 1;
            License.CreatedByUserID = localDrivingLicenseApp.CreatedByUserID;


            int applicationID = localDrivingLicenseApp.ApplicationID;

            if (clsLicense.HaveActiveLicense(License.LicenseClass, applicationID))
            {   
                MessageBox.Show("this Driver Have active License from this License Class .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Driver.Save())  // This will add or update the driver based on its Mode
            {
                // If driver is saved successfully, assign the driver ID to the license
                License.DriverID = Driver.DriverID;

                // Save the license information
                if (License.Save())  // Save license
                {
                    localDrivingLicenseApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                    MessageBox.Show("License Issued Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to issue license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Failed to save driver information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
