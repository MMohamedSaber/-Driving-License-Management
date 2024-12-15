using DVLBuisnesLayer;
using System;
using System.Windows.Forms;
using static DVLBuisnesLayer.clsTestType;

namespace WindowsFormsApp1
{
    public partial class frmSchedualTest : Form
    {
        private int _testAppointmentID;
        private int _localLicenseApplication;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        clsTestAppointment TestAppointment = new clsTestAppointment();

        // Enum to represent the three modes
        enum enMode { AddTestMode = 1, UpdateTestMode =2 ,RetakeTestMode=3,LockedTest=4}
        enMode Mode;

        int TestType = -1;

        // Default constructor for Add Mode
        public frmSchedualTest(int localLicenseApplication , int mode , clsTestType.enTestType testType)
        {
            _localLicenseApplication = localLicenseApplication;
            InitializeComponent();
            TestType =(int) testType;
            switch (mode)
            {
                case 1:
                    Mode = enMode.AddTestMode;
                    break;
                case 2:
                    Mode = enMode.UpdateTestMode;
                    break;
                case 3:
                    Mode = enMode.RetakeTestMode;
                    break;
                case 4:
                    Mode = enMode.LockedTest;
                    break;
                default:
                    MessageBox.Show("Invalid mode specified. Defaulting to AddTestMode.", "Invalid Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Mode = enMode.AddTestMode;
                    break;
            }





        }


   

        // Method to fill data based on the current mode
        private void _FillData()
        {
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication
                .FindLocalDrivingLicenseAppByLocalLicenseID(_localLicenseApplication);

            lblDrivingLicenseAppID.Text = _localDrivingLicenseApplication.LocalLicenseID.ToString();
            lblLicenseClass.Text = _localDrivingLicenseApplication.LicenseClassID.ToString();
            lblName.Text = _localDrivingLicenseApplication.ApplicantFullName.ToString();
            lblFees.Text = clsTestType.Find(1).Fees.ToString();

           
                lblTotalFees.Text = (int.Parse(lblFees.Text) + int.Parse(lblRetakApplicationFees.Text)).ToString();
            
        }

        // Load data when the form loads
        private void LoadData()
        {
            _FillData();



            if (Mode == enMode.LockedTest)
            {
                lblmainTitle.Text = "Update Scheduled Test";
                dateTimePicker1.Enabled = false;
                btnSave.Enabled = false;
                lblLockedValidation.Text = "Person already sat for the test appointment.";
                return;

            }

            if (Mode == enMode.UpdateTestMode)
            {
                lblmainTitle.Text = "Update Scheduled Test";
                TestAppointment = clsTestAppointment.FindTestAppointmentByLocalDrivingLicenseID(_localLicenseApplication,clsTestType.enTestType.VisionTest);
                return;

            }

            if (Mode == enMode.RetakeTestMode) 
            {

                lblmainTitle.Text = "Schedule Retake Test";
                lblRetakApplicationFees.Text = clsApplicationType
                    .Find((int)clsApplication.enApplicationType.RetakeTest)
                   .Fees
                  .ToString();
                return;

            }
           



        }

        private void frmSchedualTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Save button click event
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            TestAppointment.TestTypeID = (clsTestType.enTestType)clsTestType.Find(TestType).TestID;
            
            
            TestAppointment.LocalDrivingLicenseApplicationID = int.Parse(lblDrivingLicenseAppID.Text);
            TestAppointment.AppointmentDate = dateTimePicker1.Value;
            TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            TestAppointment.CreatedByUserID = _localDrivingLicenseApplication.CreatedByUserID;
            TestAppointment.IsLocked = false;

            // Handle saving logic
            if (TestAppointment.Save())
            {
                MessageBox.Show("The appointment was saved successfully.", "Info", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Save failed.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
