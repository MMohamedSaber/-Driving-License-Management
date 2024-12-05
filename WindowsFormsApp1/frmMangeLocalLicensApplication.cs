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
    public partial class frmMangeLocalLicensApplication : Form
    {
        public frmMangeLocalLicensApplication()
        {
            InitializeComponent();
        }

        DataTable dtLocalDrivingLicenseApplications=clsLocalDrivingLicenseApplication.GetAllApplications();

        private void _RefreshDataToDGV()
        {
            DGVLocalDrivingLicenseApplications.DataSource = dtLocalDrivingLicenseApplications;
            DGVLocalDrivingLicenseApplications.ContextMenuStrip = contextMenuStrip1;
            txtSearch.Visible = false;
            lblRecords.Text = DGVLocalDrivingLicenseApplications.RowCount.ToString();
            cbFilterApplications.SelectedIndex = 0;
        }
        private void frmMangeLocalLicensApplication_Load(object sender, EventArgs e)
        {
            _RefreshDataToDGV();
        }

        private void _ApplayFilter( string FilterBy,object Key )
        {
            DataView view = dtLocalDrivingLicenseApplications.DefaultView; // Create a DataView for filtering

            if (cbFilterApplications.SelectedItem == "None")
                return;


            if (int.TryParse(Key.ToString(), out int numericKey)) // Check if the filter value is numeric
            {
                view.RowFilter = $"{FilterBy} = {Key}"; // Apply exact match filter for numeric values
            }
            else
            {
               
                
                    view.RowFilter = $"{FilterBy} LIKE '%{Key}%'"; // Apply partial match filter for text values

                
            }
        }
        private void cbFilterApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            // handling hiding Key Search
            txtSearch.Visible= cbFilterApplications.SelectedIndex == 0 ? false: true ;
            _ApplayFilter(cbFilterApplications.Text, txtSearch.Text);
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplayFilter(cbFilterApplications.Text, txtSearch.Text);

        }
        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmLocalLicenseApplication frm = new frmLocalLicenseApplication(-1,"Msaqer77");
            frm.ShowDialog();
            _RefreshDataToDGV();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                  clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByLicenseID(LocalLicenseID);

            DialogResult Result=MessageBox.Show("Are Sure You Want To Cancel This Application","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                LocalDrivingLicenseApplication.Cancel();
            }

        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctxSdulStreetTest.Enabled = false;
            sctxSdulWritinTest.Enabled = false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxIssueLicense.Enabled = false;
            ctxShowLicense.Enabled = false;
        }

        private void sctxSdulVisionTest_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmVisionTextAppointment frm = new frmVisionTextAppointment(ApplicationID);
            frm.ShowDialog();
            }
    }
}
