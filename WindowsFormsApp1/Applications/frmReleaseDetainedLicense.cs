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
using static DVLBuisnesLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private clsLicense _currentLicense = new clsLicense();
        private clsDetain _currentDetaine = new clsDetain();
        private clsLocalDrivingLicenseApplication _newApplication = new clsLocalDrivingLicenseApplication();    
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            ctrlInterNationalDrivingLicense1.LicenseIDUpdated += UpdateLicenseID;
        }

        private void UpdateLicenseID(string licenseID)
        {
            lblLicenseID.Text = licenseID;
            loadLicenceData();
        }

        private void loadLicenceData()
        {
            // Attempt to parse the license ID from the label
            if (int.TryParse(lblLicenseID.Text, out int licenseID))
            {
                // Retrieve the license details by ID
                _currentLicense = clsLicense.GetLicenseByID(licenseID);
                _currentDetaine=clsDetain.FindDetainByLicenseID(licenseID);
                if (_currentLicense != null)
                {
                    if (!clsDetain.IsLicenseDetained(licenseID))
                    {
                        btnRelease.Enabled = false;
                        ShowError($"The License with {licenseID} Is  Not Detained");
                    }
                    else
                    {
                        btnRelease.Enabled = true;

                    }

                    // Check if the license is expired
                    lblLicenseID.Text = licenseID.ToString();
                    lblDetainDate.Text = DateTime.Now.ToString("dd/MMMM/yyyy");
                    lblCreatedUser.Text = _currentLicense.UserInfo.UserName.ToString();
                    lblDetainID.Text = _currentDetaine.DetainID.ToString();
                    lblApplicationFees.Text=clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).Fees.ToString();
                    lblFineFees.Text = _currentDetaine.FineFees.ToString();

                    lblTotalFees.Text = (_currentDetaine.FineFees + int.Parse(lblApplicationFees.Text)).ToString();


                }
                else
                {
                    // License not found in the database
                    ShowError("License not found.");
                }
            }

        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            _newApplication.ApplicationID = _currentLicense.ApplicationID;
            _newApplication.ApplicantPersonID = _currentLicense.ApplicationInfo.ApplicantPersonID;
                _newApplication.ApplicationDate = DateTime.Now;
            _newApplication.ApplicationTypeID = clsApplicationType.Find((int)clsApplication
                .enApplicationType.ReleaseDetainedDrivingLicense).ID;
            _newApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            _newApplication.LastStatusDate = DateTime.Now;
            _newApplication.PaidFees = Convert.ToSingle(lblTotalFees.Text);
            _newApplication.CreatedByUserID = _currentLicense.CreatedByUserID;
            _newApplication.LicenseClassID = _currentLicense.LicenseClass;

            _currentDetaine.IsReleased = true;

            if (_newApplication.Save()&& _currentDetaine.Save())
            {
                MessageBox.Show("The License Realsed Successfuly","Confirm",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnRelease.Enabled = false;
                lblApplicationID.Text = _newApplication.ApplicationID.ToString();
                
            }else
            {
                ShowError("Something went worng");
            }

        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLocalDrivingLicenseApplication _currentLocal = clsLocalDrivingLicenseApplication
                .FindLocalDrivingLicenseAppByAppID(_currentLicense.ApplicationID);
            int LocalLicense = _currentLocal.LocalLicenseID;
            

            if (_currentLicense.ApplicationID != 0)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LocalLicense);
                frm.ShowDialog();
            }

        }

        private void linkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_currentLicense.ApplicationID != 0)
            {
                frmShowDriverHistory frm = new frmShowDriverHistory(_currentLicense.ApplicationID);
                frm.ShowDialog();
            }
        }
    }
    }
