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
    public partial class ctrlInterNationalDrivingLicense : UserControl
    {
        public string LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }

        // Declare an event to notify when a new License ID is set
        public event Action<string> LicenseIDUpdated;

        public ctrlInterNationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

           
            if (int.TryParse(txtSearchKey.Text, out int licenseID))
            {
                

                clsLicense License = clsLicense.GetLicenseByID(licenseID);

                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.
                         FindLocalDrivingLicenseAppByAppID(License.ApplicationID);
                if (License != null)
                {
                    // Populate the control with license data
                    ctrlDriverLicenseInfo1.ClassName = LocalDrivingLicenseApplication.LicenseClassInfo.ClassName.ToString();
                    ctrlDriverLicenseInfo1.Name = LocalDrivingLicenseApplication.ApplicantFullName;

                    ctrlDriverLicenseInfo1.NationalNo = LocalDrivingLicenseApplication.ApplicantPersonInfo.NationalNo.ToString();

                    ctrlDriverLicenseInfo1.LicenseID = License.LicenseID.ToString();
                    ctrlDriverLicenseInfo1.IssueDate = License.IssueDate.ToString("dd/MM/yyyy");

                    if (License.IssueReason == 1)
                        ctrlDriverLicenseInfo1.IssueReason = "First Time";
                    else
                        ctrlDriverLicenseInfo1.IssueReason = "Second Time";

                    ctrlDriverLicenseInfo1.Notes = License.Notes;

                    if (LocalDrivingLicenseApplication.ApplicantPersonInfo.Gender == 0)
                        ctrlDriverLicenseInfo1.Gender = "Male";
                    else ctrlDriverLicenseInfo1.Gender = "Female";

                    if (License.IsActive == true)
                        ctrlDriverLicenseInfo1.IsActive = "Yes";
                    else ctrlDriverLicenseInfo1.IsActive = "No";
                    ctrlDriverLicenseInfo1.DateOfBirth = LocalDrivingLicenseApplication.ApplicantPersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
                    ctrlDriverLicenseInfo1.DriverID = License.DriverID.ToString();
                    ctrlDriverLicenseInfo1.ExpirationDate = License.ExpirationDate.ToString("dd/MM/yyyy");

                    ctrlDriverLicenseInfo1.IsDetained = "No";
                    ctrlDriverLicenseInfo1.mainphoto = LocalDrivingLicenseApplication.ApplicantPersonInfo.ImagePath;

                    // Raise the event to notify listeners (such as the form) about the updated License ID
                    LicenseIDUpdated?.Invoke(ctrlDriverLicenseInfo1.LicenseID);
                }
                else
                {
                    MessageBox.Show("License not found", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Invalid License ID", "Error", MessageBoxButtons.OK);
            }
        }

        private void ctrlInterNationalDrivingLicense_Load(object sender, EventArgs e)
        {

        }
    }

}
