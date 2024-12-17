using DVLBuisnesLayer;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmIssueInternationalDrivingLicense : Form
    {
        // Holds the instance of the international license being created
        private clsInternationalLicense _internationalLicense;
        private clsLicense _currentLicense;

        private clsLocalDrivingLicenseApplication LocalLiense;
        private int LocallicenseID;


        public frmIssueInternationalDrivingLicense()
        {
            InitializeComponent();
            // Subscribe to the event to update the license ID when it changes in the control
            ctrlInterNationalDrivingLicense1.LicenseIDUpdated += UpdateLicenseID;
        }

        // Event handler for updating the License ID
        private void UpdateLicenseID(string licenseID)
        {
            lblLicenseID.Text = licenseID;
            LoadLicenseData();
        }

        // Form load event handler
        private void frmIssueInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        // Initialize form fields with default data
        private void InitializeForm()
        {
            lblApplciationdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            lblLicenseID.Text = ctrlInterNationalDrivingLicense1.LicenseID;
            lblFees.Text = GetLicenseFees();

            LoadLicenseData();
        }

        // Retrieve and display license fees
        private string GetLicenseFees()
        {
            var licenseType = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense);
            return licenseType?.Fees.ToString() ?? "N/A";
        }

        // Load license data based on the License ID
        private void LoadLicenseData()
        {
            if (int.TryParse(lblLicenseID.Text, out int licenseID))
            {
                _currentLicense = clsLicense.GetLicenseByID(licenseID);

                if (_currentLicense != null)
                {
                    lblCreatedUser.Text = _currentLicense.CreatedByUserID.ToString();
                }
                else
                {
                    ShowError("License not found.");
                }
            }
            else
            {
                ShowError("Invalid License ID.");
            }
        }

        // Button click event to issue the international driving license
        private void btnIssue_Click(object sender, EventArgs e)
        {
            // Ensure a license is loaded before proceeding
            if (_currentLicense == null)
            {
                ShowError("Please load a valid license before issuing an international license.");
                return;
            }

            // Validate if the license meets the requirements
            if (!ValidateLicenseRequirements())
            {
                return;
            }

            // Create the international license
            CreateInternationalLicense();

                // Save the international license to the database
                if (_internationalLicense.Save())
                {

                    ShowSuccess("The international license was issued successfully.");
                    lblInterNationalLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
                }
                else
                {
                    ShowError("Failed to issue the international license.");
                }
           
        }

        // Validate if the driver already has an international license and if they have a Class 3 license
        private bool ValidateLicenseRequirements()
        {
            if (clsInternationalLicense.IsInternationalLicenseExist(_currentLicense.LicenseID))
            {
                ShowError("The driver already has an international license.");
              _internationalLicense= clsInternationalLicense.FindByLocalLicense(_currentLicense.LicenseID);
                lblInterNationalAppID.Text =_internationalLicense.ApplicationID.ToString();
                lblInterNationalLicenseID.Text=_internationalLicense.InternationalLicenseID.ToString();
                return false;
            }

            if (!clsInternationalLicense.IsHaveLicenseOfClassThree(_currentLicense.LicenseID))
            {
                ShowError("The driver does not have a license of Class 3.");
                return false;
            }

            return true;
        }

        // Create a new international license instance with the relevant data
        private void CreateInternationalLicense()
        {


            _internationalLicense = new clsInternationalLicense
            {
                ApplicationID = _currentLicense.ApplicationID,
                DriverID = _currentLicense.DriverID,
                IssuedUseingLocalDrivingLicenseID = _currentLicense.LicenseID,
                IssuedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(1),
                IsActive = true,
                CreatedByUser = _currentLicense.CreatedByUserID
            };

            
        }

        // Display an error message to the user
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Display a success message to the user
        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // Check if lblInterNationalAppID.Text is a valid integer
            if (int.TryParse(lblInterNationalAppID.Text, out int appID))
            {
                // If valid, open the driver history form
                frmShowDriverHistory frm = new frmShowDriverHistory(appID);
                frm.ShowDialog();
            }
            else
            {
                // If not valid, show an error message
                ShowError($"There is no license with ID: {lblInterNationalAppID.Text}. Please ensure the license application ID is correct.");
            }
        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {




            // Check if lblInterNationalLicenseID.Text is a valid integer
            if (int.TryParse(lblInterNationalLicenseID.Text, out int licenseID))
            {
                // If valid, open the international driver info form
                frmShowIntrenationDriverInfo frm = new frmShowIntrenationDriverInfo(licenseID);
                frm.ShowDialog();
            }
            else
            {
                // If not valid, show an error message
                ShowError($"There is no license with ID: {lblInterNationalLicenseID.Text}. Please ensure the international license ID is correct.");
            }


        }
    }
}
