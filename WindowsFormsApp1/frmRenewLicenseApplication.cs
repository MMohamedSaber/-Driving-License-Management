using DVLBuisnesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmRenewLicenseApplication : Form
    {
        private clsLicense _expiredLicense = new clsLicense();
        private clsLicense _newLicense     =    new clsLicense();
        private clsLocalDrivingLicenseApplication _localApplication
            = new clsLocalDrivingLicenseApplication();
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
            ctrlInterNationalDrivingLicense1.LicenseIDUpdated += UpdateLicenseID;

        }

       private void  UpdateLicenseID(string licenseID)
        {
            lblOldLicenseID.Text= licenseID;
            loadLicenceData();
        }


        private void loadLicenceData()
        {
            // Attempt to parse the license ID from the label
            if (int.TryParse(lblOldLicenseID.Text, out int licenseID))
            {
                // Retrieve the license details by ID
                _expiredLicense = clsLicense.GetLicenseByID(licenseID);

                if (_expiredLicense != null)
                {
                    // Check if the license is expired
                    if (!IsLicenseExpired(_expiredLicense.ExpirationDate))
                    {
                        // License is not expired
                        ShowError($"The License with ID {_expiredLicense.LicenseID} is not expired yet.");

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
                    lblExpirationDate.Text = DateTime.Now.AddYears(_expiredLicense.LicenseClasseInfo.DefaultValidityLength).ToString();
                    lblCreatedUser.Text = _expiredLicense.CreatedByUserID.ToString();
                    lblLicenseFees.Text = _expiredLicense.LicenseClasseInfo.ClassFees.ToString();
                    lblTotalFees.Text = GetTotalFees();
                }
                else
                {
                    // License not found in the database
                    ShowError("License not found.");
                }
            }
            else
            {
                // Invalid license ID format
                ShowError("Invalid License ID format.");
            }
        }
        

        private bool IsLicenseExpired( DateTime Date)
        {

            return Date < DateTime.Now;
            //if (_damagedOrLostLicense.ExpirationDate > DateTime.Now)
            //{
                

            //    btnIssue.Enabled = false;

            //    ShowError($"The License with {_damagedOrLostLicense.LicenseID} Not Expired Yet.");
            //}
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private string  GetTotalFees()
        {



            int applicationFees = 0;
            int licenseFees = 0;

            if (!int.TryParse(lblApplicationFees.Text, out applicationFees))
            {
                MessageBox.Show("Invalid Application Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!int.TryParse(lblLicenseFees.Text, out licenseFees))
            {
                MessageBox.Show("Invalid License Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           return  lblTotalFees.Text = (applicationFees + licenseFees).ToString();
        }
        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {

            InitializeForm();


        }

        private void InitializeForm()
        {
            lblApplciationdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblOldLicenseID.Text = ctrlInterNationalDrivingLicense1.LicenseID;
            lblApplicationFees.Text = GetApplicationFees((int)clsApplication.enApplicationType.RenewDrivingLicense);

           // LoadLicenseData();
        }


        private string GetApplicationFees(int ApplicationType)
        {
            clsApplicationType licenseType = clsApplicationType.Find(ApplicationType);
            return licenseType?.Fees.ToString() ?? "N/A";
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {



            _localApplication.ApplicantPersonID = _expiredLicense.ApplicationInfo.ApplicantPersonID;
            _localApplication.ApplicationDate = DateTime.Now;
            _localApplication.ApplicationTypeID =clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ID;
            _localApplication.ApplicationStatus = (clsApplication.enApplicationStatus.Completed);//here
            _localApplication.LastStatusDate = DateTime.Now;
            _localApplication.PaidFees = (float)clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            _localApplication.CreatedByUserID = _expiredLicense.CreatedByUserID;
            _localApplication.LicenseClassID = _expiredLicense.LicenseClass;


            _newLicense.DriverID=_expiredLicense.DriverID;
            _newLicense.LicenseClass= _expiredLicense.LicenseClass;
            _newLicense.IssueDate=DateTime.Now;
            _newLicense.ExpirationDate= DateTime.Now.AddYears
                (clsLicenseClasses.Find(_localApplication.LicenseClassID).DefaultValidityLength);
            _newLicense.Notes= txtNotes.Text;
            _newLicense.PaidFees =Convert.ToSingle(lblTotalFees.Text);
            _newLicense.IsActive = true;
            _newLicense.IssueReason = 2;
            _newLicense.CreatedByUserID= _expiredLicense.CreatedByUserID;

            if (_localApplication.Save())
            {

                _newLicense.ApplicationID = _localApplication.ApplicationID;
                    _expiredLicense.IsActive = false;

                if (_newLicense.Save() && _expiredLicense.Save())
                {

                    MessageBox.Show("The New License Saved Successfuly","Confirm",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);

                    lblRenewApplicationID.Text = _localApplication.ApplicationID.ToString();
                    lblRenewLicenseID.Text = _newLicense.LicenseID.ToString();
                
                    _newLicense.ApplicationID = _localApplication.ApplicationID;
                    clsTest.GetPassedTestCount(_newLicense.LicenseID).ToString();

                    btnIssue.Enabled = false;
                }
            }
        }

        private void linkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

            frmShowDriverHistory frm =new frmShowDriverHistory(_expiredLicense.ApplicationID);
            frm.ShowDialog();
        }

        private void ctrlInterNationalDrivingLicense1_Load(object sender, EventArgs e)
        {

        }
    }
}
