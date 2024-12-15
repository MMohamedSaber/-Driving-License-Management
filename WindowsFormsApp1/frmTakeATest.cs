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
using static DVLBuisnesLayer.clsTestType;

namespace WindowsFormsApp1
{
    public partial class frmTakeATest : Form
    {

        clsLocalDrivingLicenseApplication _LocalDriingLicenseApplication;
        int LocalDriingLicenseApplicationID=-1;
        private int TestAppointMentID = -1;
        clsTest Test;
        clsTestAppointment testAppointment;
        clsTestType.enTestType TestType;
        public frmTakeATest()
        {
            InitializeComponent();
        }

        public frmTakeATest(int LocalDrivnigID,clsTestType.enTestType testType)
        {
            InitializeComponent();
            LocalDriingLicenseApplicationID = LocalDrivnigID;
            TestType = testType;
        }


        void LoadData()
        {
            //Find Test AppointMent
             testAppointment = clsTestAppointment.
                FindTestAppointmentByLocalDrivingLicenseID(LocalDriingLicenseApplicationID, TestType);

            //Find Local Driving License To bring Data 
            _LocalDriingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByAppID
                (LocalDriingLicenseApplicationID);
            
            if (_LocalDriingLicenseApplication != null && testAppointment !=null)
            {
                lblDrivingLicenseAppID.Text = testAppointment.LocalDrivingLicenseApplicationID.ToString();

                lblLicenseClass.Text = _LocalDriingLicenseApplication.LicenseClassInfo.ClassName;

                lblName.Text = _LocalDriingLicenseApplication.ApplicantFullName;
                lblDate.Text = _LocalDriingLicenseApplication.ApplicationDate.ToString();
                //   lblTrial.Text = _LocalDriingLicenseApplication.
                lblFees.Text = _LocalDriingLicenseApplication.PaidFees.ToString();

                if(testAppointment.TestID != -1)
                    lblTestID.Text=testAppointment.TestID.ToString();
                else
                    lblTestID.Text ="Not Taken Yet";

            }




        }
        private void frmTakeATest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Test=new clsTest();

            if (rbPassed.Checked)
            {
                Test.TestResult = true;
            }else
            {
                Test.TestResult = false;

            }
            Test.TestAppointmentID = testAppointment.TestAppointmentID;
            Test.Notes=txtNotes.Text;
            Test.CreatedByUserID = testAppointment.CreatedByUserID;


            DialogResult result = MessageBox.Show(
    "Are you sure you want to save? After that you cannot change the Pass/Fail results after you save!",
    "Confirm",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning
);

            if (result == DialogResult.Yes)
            {
                if (Test.Save())
                {

                    MessageBox.Show("Saved Succeffulu", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    MessageBox.Show("Saved Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            LoadData();




        }
    }
}
