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
    public partial class frmShowInternationalLicense : Form
    {
        public frmShowInternationalLicense()
        {
            InitializeComponent();
        }

        DataTable InterNationalLicesesTable;
        private void frmShowInternationalLicense_Load(object sender, EventArgs e)
        {
            InterNationalLicesesTable = clsInternationalLicense.GetAllInterNationalLicense();
            DGVinterNationalLicense.DataSource = InterNationalLicesesTable;
            lblRecords.Text = DGVinterNationalLicense.RowCount.ToString();
            DGVinterNationalLicense.ContextMenuStrip = contextMenuStrip1;
            cbFilterInerNationalLicense.SelectedIndex = 0;
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)DGVinterNationalLicense.CurrentRow.Cells[1].Value;
            clsApplication Application=clsApplication.FindBaseApplication(ApplicationID);

            frmPersonDetails frm = new frmPersonDetails(Application.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InterNationalLicenseInfo = (int)DGVinterNationalLicense.CurrentRow.Cells[0].Value;

            frmShowIntrenationDriverInfo frm = new frmShowIntrenationDriverInfo(InterNationalLicenseInfo);
            frm.ShowDialog();

        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)DGVinterNationalLicense.CurrentRow.Cells[1].Value;

            frmShowDriverHistory frm = new frmShowDriverHistory(ApplicationID);
            frm.ShowDialog();
        }

        private void btnAddNewInternationalL_Click(object sender, EventArgs e)
        {
            frmIssueInternationalDrivingLicense frm = new frmIssueInternationalDrivingLicense();
            frm.ShowDialog();
        }
        private void _ApplyFilter(string filterBy, object key)
        {
            DataView view = InterNationalLicesesTable.DefaultView; // Create a DataView for filtering

           


            if (int.TryParse(key.ToString(), out int numericKey)) // Check if the filter value is numeric
            {
                view.RowFilter = $"{filterBy} = {key}"; // Apply exact match filter for numeric values
            }
            else
            {
                view.RowFilter = $"{filterBy} LIKE '%{key}%'"; // Apply partial match filter for text values
            }
        }
        private void cbFilterInerNationalLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = cbFilterInerNationalLicense.SelectedIndex == 0 ? false : true;

            if (!string.IsNullOrEmpty(cbFilterInerNationalLicense.Text) && !string.IsNullOrEmpty(txtSearch.Text)) // Check if inputs are valid
            {

                _ApplyFilter(cbFilterInerNationalLicense.Text, txtSearch.Text); // Apply the filter based on user inputs
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {



            if (!string.IsNullOrEmpty(cbFilterInerNationalLicense.Text) && !string.IsNullOrEmpty(txtSearch.Text)) // Check if inputs are valid
            {
                _ApplyFilter(cbFilterInerNationalLicense.Text, txtSearch.Text); // Apply the filter based on user inputs
            }
        }
    }
}
