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
    public partial class ctrlLocalDrivingLicenseInfo : UserControl
    {// Property for lblEditPerson




        // Property for lblApplicant
        public string ApplicantPerson
        {
        //  get { return clsPerson.Find(); }
            set { lblApplicant.Text = value; }
        }

        // Property for lblCreatedBy
        public string CreatedByText
        {
         //   get { return lblCreatedBy.Text; }
            set { lblCreatedBy.Text = value; }
        }

        // Property for lblDate
        public string DateText
        {
          //  get { return lblDate.Text; }
            set { lblDate.Text = value; }
        }

        // Property for lblDrivingLicenseID
        public string LocalLicenseID
        {
            get { return lblDrvingLicenseID.Text; }
            set { lblDrvingLicenseID.Text = value; }
        }

        // Property for lblFees
        public string Fees
        {
            get { return lblFees.Text; }
            set { lblFees.Text = value; }
        }

        // Property for lblID
        public string ApplicationID
        {
            get { return lblID.Text; }
            set { lblID.Text = value; }
        }

        // Property for lblLicenseClass
        public string LicenseClassText
        {
            get { return lblLicenseClass.Text; }
            set { lblLicenseClass.Text = value; }
        }

        // Property for lblPassedTest
        public string PassedTestText
        {
            get { return lblPassedTest.Text; }
            set { lblPassedTest.Text = value; }
        }

        // Property for lblStatus
        public string StatusText
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }

        // Property for lblStatusDate
        public string StatusDateText
        {
            get { return lblStatusDate.Text; }
            set { lblStatusDate.Text = value; }
        }

        // Property for lblType
        public string TypeText
        {
            get { return lblType.Text; }
            set { lblType.Text = value; }
        }
        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }





        private void ctrlLocalDrivingLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void lbEdithPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       int personID=clsApplication.FindBaseApplication(int.Parse(ApplicationID)).ApplicantPersonID;

             frmPersonDetails frm = new frmPersonDetails(personID);
                frm.ShowDialog();
            


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
