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
    public partial class frmReplcementOrDamaged : Form
    {
        private clsLicense _damagedOrLostLicense = new clsLicense();
        private clsLicense _newLicense = new clsLicense();
        private clsLocalDrivingLicenseApplication _localApplication
            = new clsLocalDrivingLicenseApplication();
        public frmReplcementOrDamaged()
        {
            InitializeComponent();
            ctrlInterNationalDrivingLicense1.LicenseIDUpdated += UpdateLicenseID;
        }


        private void UpdateLicenseID(string licenseID)
        {
            lblOldLicenseID.Text = licenseID;
            loadLicenceData();
        }

        private void loadLicenceData()
        {
            // Attempt to parse the license ID from the label
            if (int.TryParse(lblOldLicenseID.Text, out int licenseID))
            {
                // Retrieve the license details by ID
                _damagedOrLostLicense = clsLicense.GetLicenseByID(licenseID);

                if (_damagedOrLostLicense != null)
                {
                    // Check if the license is expired
                    if (!IsLicenseActive(licenseID))
                    {
                        // License is not expired
                        ShowError($"The License with ID {_damagedOrLostLicense.LicenseID} is not Active.");

                        // Disable issuing and link controls
                        btnIssue.Enabled = false;
                        linkLicenseInfo.Enabled = false;
                    }
                    else
                    {
                        // License is expired
                        btnIssue.Enabled = true;
                        linkLicenseInfo.Enabled = true;
                    }

                    // Populate the license details in the labels
                    lblApplciationdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblCreatedUser.Text = _damagedOrLostLicense.CreatedByUserID.ToString();
                }
                else
                {
                    // License not found in the database
                    ShowError("License not found.");
                }
            }
            
        }

        private bool IsLicenseActive(int licenseID )
        {

            return clsLicense.IsLicenseActive(licenseID);

        }
       
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmReplcementOrDamaged_Load(object sender, EventArgs e)
        {
            linkLicenseInfo.Enabled = false;
            loadLicenceData();
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lblTitle.Text = "Replacement For Damaged License";
            }
            else
            {
                lblTitle.Text = "Replacement For Lost License";
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _localApplication.ApplicantPersonID = _damagedOrLostLicense.ApplicationInfo.ApplicantPersonID;
            _localApplication.ApplicationDate = DateTime.Now;
            _localApplication.ApplicationTypeID = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ID;
            _localApplication.ApplicationStatus = (clsApplication.enApplicationStatus.Completed);//here
            _localApplication.LastStatusDate = DateTime.Now;
            _localApplication.PaidFees = (float)clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            _localApplication.CreatedByUserID = _damagedOrLostLicense.CreatedByUserID;
            _localApplication.LicenseClassID = _damagedOrLostLicense.LicenseClass;



            _newLicense.DriverID = _damagedOrLostLicense.DriverID;
            _newLicense.LicenseClass = _damagedOrLostLicense.LicenseClass;
            _newLicense.IssueDate = DateTime.Now;
            _newLicense.ExpirationDate = DateTime.Now.AddYears
                (clsLicenseClasses.Find(_localApplication.LicenseClassID).DefaultValidityLength);
            _newLicense.IsActive = true;
            
            
            if(rbDamaged.Checked)
            _newLicense.IssueReason = 3;
            else _newLicense.IssueReason = 4;

            _newLicense.CreatedByUserID = _damagedOrLostLicense.CreatedByUserID;

            if (_localApplication.Save())
            {

                _newLicense.ApplicationID = _localApplication.ApplicationID;
                _damagedOrLostLicense.IsActive = false;

                if (_newLicense.Save() && _damagedOrLostLicense.Save())
                {

                    MessageBox.Show("The New License Saved Successfuly", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblRenewApplicationID.Text = _localApplication.ApplicationID.ToString();
                    lblRenewLicenseID.Text = _newLicense.LicenseID.ToString();

                    _newLicense.ApplicationID = _localApplication.ApplicationID;
                    clsTest.GetPassedTestCount(_newLicense.LicenseID).ToString();

                    btnIssue.Enabled = false;
                    linkLicenseInfo.Enabled = false;

                }
            }

        }

        private void linkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!int.TryParse(lblRenewApplicationID.Text, out int appID))
            {
                // If not valid, show an error message
                ShowError($"There is no license with ID: {lblRenewApplicationID.Text}. Please ensure the license application ID is correct.");
                return;
            }

            if (_newLicense.ApplicationID != 0)
            {
                frmShowDriverHistory frm = new frmShowDriverHistory(_newLicense.ApplicationID);
                frm.ShowDialog();
            }
            else
            {
                frmShowDriverHistory frm = new frmShowDriverHistory(_damagedOrLostLicense.ApplicationID);
                frm.ShowDialog();
            }
            
        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowLicenseInfo frm = new frmShowLicenseInfo(_newLicense.ApplicationID);  
            frm.ShowDialog();
        
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

       
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
