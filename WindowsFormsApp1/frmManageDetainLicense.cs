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
    public partial class frmManageDetainLicense : Form
    {
        public frmManageDetainLicense()
        {
            InitializeComponent();
        }
        DataTable DetainendLicenses;

        private void frmManageDetainLicense_Load(object sender, EventArgs e)
        {
            DetainendLicenses = clsDetain.GettAllDetainedLicese();
            DGVLocalDrivingLicenseApplications.DataSource = DetainendLicenses;
            lblRecords.Text = DGVLocalDrivingLicenseApplications.RowCount.ToString();
            DGVLocalDrivingLicenseApplications.ContextMenuStrip = contextMenuStrip1;
            cbFilterDetained.SelectedIndex = 0;
        }



        private void _ApplyFilter(string filterBy, object key)
        {
            DataView view = DetainendLicenses.DefaultView; // Create a DataView for filtering




            if (int.TryParse(key.ToString(), out int numericKey)) // Check if the filter value is numeric
            {
                view.RowFilter = $"{filterBy} = {key}"; // Apply exact match filter for numeric values
            }
            else
            {
                view.RowFilter = $"{filterBy} LIKE '%{key}%'"; // Apply partial match filter for text values
            }


        }

        private void cbFilterDetained_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = cbFilterDetained.SelectedIndex == 0 ? false : true;

            if (!string.IsNullOrEmpty(cbFilterDetained.Text) && !string.IsNullOrEmpty(txtSearch.Text)) // Check if inputs are valid
            {

                _ApplyFilter(cbFilterDetained.Text, txtSearch.Text); // Apply the filter based on user inputs
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbFilterDetained.Text) && !string.IsNullOrEmpty(txtSearch.Text)) // Check if inputs are valid
            {
                _ApplyFilter(cbFilterDetained.Text, txtSearch.Text); // Apply the filter based on user inputs
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LicenseID = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[1].Value;
             int PersonID=clsLicense.GetLicenseByID(LicenseID).ApplicationInfo.ApplicantPersonID;

            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm .ShowDialog();
        }

        private void showLicenseHistroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            int ApplicationID = clsLicense.GetLicenseByID((int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[1].Value).ApplicationID;
            int localLicenseID= clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByAppID(ApplicationID).LocalLicenseID;


            frmShowLicenseInfo frm =new frmShowLicenseInfo(localLicenseID);
            frm .ShowDialog();  

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLicense.GetLicenseByID((int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[1].Value).ApplicationID;
            int localLicenseID = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByAppID(ApplicationID).LocalLicenseID;


            frmShowDriverHistory frm =new frmShowDriverHistory(ApplicationID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void releaseDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }
    }
}
