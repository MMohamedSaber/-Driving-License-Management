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

        DataTable dtLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllApplications();

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

        private void _ApplayFilter(string FilterBy, object Key)
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
            txtSearch.Visible = cbFilterApplications.SelectedIndex == 0 ? false : true;
            _ApplayFilter(cbFilterApplications.Text, txtSearch.Text);
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplayFilter(cbFilterApplications.Text, txtSearch.Text);

        }
        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmLocalLicenseApplication frm = new frmLocalLicenseApplication(-1, "Msaqer77");
            frm.ShowDialog();
            _RefreshDataToDGV();
        }
        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmIssueLicense frm =new frmIssueLicense(LocalLicenseID);
            frm.ShowDialog();
            _RefreshDataToDGV();

        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                  clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByLocalLicenseID(LocalLicenseID);

            DialogResult Result = MessageBox.Show("Are Sure You Want To Cancel This Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                LocalDrivingLicenseApplication.Cancel();
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((string)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[6].Value == "New")
            {
                ctxShowDetails.Enabled = true;
                ctxEditApp.Enabled = true;
                ctxDeleteApp.Enabled = true;
                ctxCancelApp.Enabled = true;
                ctxScheduleTests.Enabled = true;
                ctxIssueLicense.Enabled = false;
                ctxShowLicense.Enabled = true;
                ctxShowPerson.Enabled = false;
            }
            else if ((string)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[6].Value == "Completed")
            {

                ctxShowDetails.Enabled = true;
                ctxEditApp.Enabled = false;
                ctxDeleteApp.Enabled = false;
                ctxCancelApp.Enabled = false;
                ctxScheduleTests.Enabled = false;
                ctxIssueLicense.Enabled = false;
                ctxShowLicense.Enabled = true;
                ctxShowPerson.Enabled = true;
            }
            else
            {
                ctxShowDetails.Enabled = false;
                ctxEditApp.Enabled = false;
                ctxDeleteApp.Enabled = false;
                ctxCancelApp.Enabled = false;
                ctxScheduleTests.Enabled = false;
                ctxIssueLicense.Enabled = false;
                ctxShowLicense.Enabled = false;
                ctxShowPerson.Enabled = false;
            }
        }
        private void sctxSdulVisionTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseId = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmTest frm = new frmTest(LocalDrivingLicenseId, 1);
            frm.ShowDialog();
            _RefreshDataToDGV();

        }

        private void sctxSdulWritinTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseId = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmTest frm = new frmTest(LocalDrivingLicenseId, 2);
            frm.ShowDialog();
            _RefreshDataToDGV();
        }
        private void ctxScheduleTests_MouseHover(object sender, EventArgs e)
        {
            int LocalDrivingLicenseId = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            if (clsTest.IsPassedTest(LocalDrivingLicenseId, (int)clsTestType.enTestType.VisionTest))
            {
                sctxSdulVisionTest.Enabled = false;
                sctxSdulWritinTest.Enabled = true;
                sctxSdulStreetTest.Enabled = false;
            }

            if (clsTest.IsPassedTest(LocalDrivingLicenseId, (int)clsTestType.enTestType.WritTest))
            {
                sctxSdulVisionTest.Enabled = false;
                sctxSdulWritinTest.Enabled = false;
                sctxSdulStreetTest.Enabled = true; 
            }


            if (clsTest.IsPassedTest(LocalDrivingLicenseId, (int)clsTestType.enTestType.StreetTest))
            {
                sctxSdulVisionTest.Enabled = false;
                sctxSdulWritinTest.Enabled = false;
                sctxSdulStreetTest.Enabled = false;

               
            }
        }

        private void ctxScheduleTests_Click(object sender, EventArgs e)
        {

        }

        private void sctxSdulStreetTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseId = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmTest frm = new frmTest(LocalDrivingLicenseId, 3);
            frm.ShowDialog();
            _RefreshDataToDGV();
        }

        private void ctxShowLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseId = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LocalDrivingLicenseId);
            frm.ShowDialog();
        }

        private void ctxShowPerson_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)DGVLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;


            frmShowDriverHistory frm = new frmShowDriverHistory(LocalLicenseID);
            frm.ShowDialog();


        }
    }
}
