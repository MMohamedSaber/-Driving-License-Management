using DVLBuisnesLayer;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmTest : Form
    {
        // Enum representing different test modes
        enum enMode { VisionTest = 1, WritinTest = 2, StreetTest = 3 }

        // Variables to store the current mode, application ID, and test type
        enMode Mode;
        int ApplicationID = -1;
        int TestType = -1;

        // Constructor with parameters to initialize ApplicationID and TestMode
        public frmTest(int applicationID, int TestMode)
        {
            InitializeComponent();
            this.ApplicationID = applicationID;

            // Set the mode based on the TestMode value
            Mode = (enMode)TestMode;

            // Configure the form title and test type based on the selected mode
            switch (Mode)
            {
                case enMode.VisionTest:
                    lblTestFormTitle.Text = "Vision Test Appointment";
                    TestType = (int)clsTestType.enTestType.VisionTest;
                    break;
                case enMode.WritinTest:
                    lblTestFormTitle.Text = "Writing Test Appointment";
                    TestType = (int)clsTestType.enTestType.WritTest;
                    break;
                case enMode.StreetTest:
                    lblTestFormTitle.Text = "Street Test Appointment";
                    TestType = (int)clsTestType.enTestType.StreetTest;
                    break;
            }
        }

        // Default constructor
        public frmTest()
        {
            InitializeComponent();
        }

        // Method to load data into the control fields based on the ApplicationID
        private void _LoadDataToctrlLoacalLicenseInfo(int ApplicationID)
        {
            var localDrivingLicenseApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseAppByLocalLicenseID(ApplicationID);

            if (localDrivingLicenseApp == null)
            {
                MessageBox.Show("Invalid License ID or Data Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load appointments into the DataGridView
            dataGridView1.DataSource = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(
                localDrivingLicenseApp.LocalLicenseID,
                (clsTestType.enTestType)TestType
            );

            dataGridView1.ContextMenuStrip = contextMenuStrip1;

            // Populate control fields with license application information
            ctrlLocalDrivingLicenseInfo1.LocalLicenseID = localDrivingLicenseApp.LocalLicenseID.ToString();
            ctrlLocalDrivingLicenseInfo1.LicenseClassText = localDrivingLicenseApp.LicenseClassInfo.ClassName;
            ctrlLocalDrivingLicenseInfo1.PassedTestText = clsTest.GetPassedTestCount(localDrivingLicenseApp.LocalLicenseID).ToString();
            ctrlLocalDrivingLicenseInfo1.ApplicationID = localDrivingLicenseApp.ApplicationID.ToString();
            ctrlLocalDrivingLicenseInfo1.StatusText = localDrivingLicenseApp.ApplicationStatus.ToString();
            ctrlLocalDrivingLicenseInfo1.Fees = localDrivingLicenseApp.PaidFees.ToString();
            ctrlLocalDrivingLicenseInfo1.TypeText = localDrivingLicenseApp.ApplicationTypeInfo.ApplicationTypeName;
            ctrlLocalDrivingLicenseInfo1.ApplicantPerson = localDrivingLicenseApp.ApplicantFullName;
            ctrlLocalDrivingLicenseInfo1.DateText = localDrivingLicenseApp.ApplicationDate.ToString();
            ctrlLocalDrivingLicenseInfo1.StatusDateText = localDrivingLicenseApp.LastStatusDate.ToString();
            ctrlLocalDrivingLicenseInfo1.CreatedByText = localDrivingLicenseApp.CreatedByUserInfo.UserName;
        }

        // Event handler for form load to initialize data
        private void frmVisionTextAppointment_Load(object sender, EventArgs e)
        {
            _LoadDataToctrlLoacalLicenseInfo(ApplicationID);
        }

        // Method to schedule a test based on the license ID and test mode
        private void ScheduleTest(int licenseID, int SchedualTestMode, int TestMode)
        {
            frmSchedualTest frm = new frmSchedualTest(licenseID, SchedualTestMode, (clsTestType.enTestType)TestMode);
            frm.ShowDialog();
            _LoadDataToctrlLoacalLicenseInfo(ApplicationID);
        }

        // Event handler for button click to schedule a test
        private void button1_Click(object sender, EventArgs e)
        {
            // Validate license ID input
            if (!int.TryParse(ctrlLocalDrivingLicenseInfo1.LocalLicenseID, out int licenseID))
            {
                MessageBox.Show("Invalid License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if there is already an active appointment for this license
            if (clsTestAppointment.IsHaveActiveAppointment(licenseID, (clsTestType.enTestType)TestType))
            {
                MessageBox.Show("This License Already Has an Active Appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the test has already been passed
            bool isVisionTestPassed = clsTest.IsPassedTest(licenseID, TestType);

            if (isVisionTestPassed)
            {
                MessageBox.Show("You Have Already Passed this Test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Schedule the test if no appointment exists
            if (!clsTestAppointment.IsAppointmentExist(licenseID, TestType))
            {
                ScheduleTest(licenseID, 1, TestType);
                return;
            }

            // If appointment exists, schedule a retake
            ScheduleTest(licenseID, 3, TestType);
        }

        // Event handler for the test context menu item click
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validate license ID input
            if (!int.TryParse(ctrlLocalDrivingLicenseInfo1.LocalLicenseID, out int licenseID))
            {
                MessageBox.Show("Invalid License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Determine if the appointment is locked and set the test type accordingly
            int TestMode = clsTestAppointment.IsAppointmentLocked(licenseID, TestType)? 4 : 2;
            ScheduleTest(licenseID, TestMode, TestType);
        }

        // Event handler for the "Take Test" context menu item click
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validate license ID input
            if (!int.TryParse(ctrlLocalDrivingLicenseInfo1.LocalLicenseID, out int licenseID))
            {
                MessageBox.Show("Invalid License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the vision test has already been passed
            if (clsTest.IsPassedTest(licenseID, TestType))
            {
                MessageBox.Show("You already passed the test.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


         

            // Open the "Take Test" form
            frmTakeATest frm = new frmTakeATest(licenseID,(clsTestType.enTestType) TestType);
            frm.ShowDialog();
            _LoadDataToctrlLoacalLicenseInfo(ApplicationID);
        }

        // Event handler for the cancel button click to close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
