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
    public partial class frmDetainLicense : Form
    {
        private clsLicense _currentLicense = new clsLicense();
        private clsDetain  _currentDetaine=new clsDetain();
        public frmDetainLicense()
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

                if (_currentLicense != null)
                {
                    if (clsDetain.IsLicenseDetained(licenseID))
                    {
                        btnDetain.Enabled = false;
                        ShowError($"The License with {licenseID} Is Already Detained");
                    }
                    else
                    {
                        btnDetain.Enabled = true;

                    }

                    // Check if the license is expired
                    lblLicenseID.Text = licenseID.ToString();
                    lblDetainDate.Text = DateTime.Now.ToString("dd/MMMM/yyyy");
                    lblCreatedUser.Text=_currentLicense.UserInfo.UserName.ToString();
                    
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
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            loadLicenceData();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            _currentDetaine = AddNewDetain();

            if (_currentDetaine.Save())
            {
                MessageBox.Show("The License wiht {_currentDetaine.LicenseID}",
                    "Informaton", MessageBoxButtons.OK, MessageBoxIcon.Information);
                linkLicenseInfo.Enabled = true;
                btnDetain.Enabled = false;
            }  

        }


        private clsDetain AddNewDetain()
        {
            return new clsDetain
            {
                LicenseID = _currentLicense.LicenseID,
                DetainDate = DateTime.Now,
                FineFees = Convert.ToSingle(txtFineFees.Text),
                CreatedbyUserID = _currentLicense.CreatedByUserID,
                IsReleased = false,
                ReleaseDate = null,
                ReleasedByUserID = _currentLicense.CreatedByUserID,
                ReleasApplicationID = _currentLicense.ApplicationID
            };
        }

        private void linkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (_currentLicense.ApplicationID != 0)
            {
                frmShowDriverHistory frm = new frmShowDriverHistory(_currentLicense.ApplicationID);
                frm.ShowDialog();
            }
           

        }

        private void linkLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_currentLicense.ApplicationID != 0)
            {
                frmShowDriverHistory frm = new frmShowDriverHistory(_currentLicense.ApplicationID);
                frm.ShowDialog();
            }
        }
    }
}
