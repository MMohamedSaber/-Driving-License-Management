using DVLBuisnesLayer;
using DVLD;
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
    public partial class frmMain : Form
    {
        int _personID=-1;
        string _userName;
        frmLoginScreen _formLogin;
        public frmMain(frmLoginScreen frm)
        {
            InitializeComponent();
            _formLogin=frm; 


        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm=new frmManagePeople();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void accounTSettingToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(accounTSettingToolStripMenuItem.GetCurrentParent(),
            //    accounTSettingToolStripMenuItem.Bounds.Location);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _formLogin.Show();
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm =new frmManageUsers();
            frm.Show();
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(clsGlobal.CurrentUser.UserID);
            frm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.Show();
        }

        private void manageApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationType frm = new frmManageApplicationType();
            frm.Show();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTests frm = new frmManageTests();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicenseApplication frm = new frmLocalLicenseApplication(-1, _userName);
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeLocalLicensApplication frm = new frmMangeLocalLicensApplication();
            frm.ShowDialog();
        }

        private void interNationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmIssueInternationalDrivingLicense frm =new frmIssueInternationalDrivingLicense();
            frm.ShowDialog();
        }

        private void interNationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicense frm = new frmShowInternationalLicense();
            frm.ShowDialog();
        }

        private void fffToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void reNewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication frm = new frmRenewLicenseApplication();
            frm.ShowDialog();

        }

        private void replacementForDamagedOrLostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplcementOrDamaged frm = new frmReplcementOrDamaged();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainLicense frm = new frmManageDetainLicense();
            frm.ShowDialog(); 
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDriver frm = new frmManageDriver();
            frm.ShowDialog();
        }
    }
}
