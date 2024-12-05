using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLBuisnesLayer;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace WindowsFormsApp1
{
    public partial class frmLocalLicenseApplication : Form
    {

        enum enMode { addMode = 1, updateMode = 2 }
        enMode Mode = enMode.addMode;


        clsLicenseClasses _LicenseClasses;
        clsPerson _person;
        string UserName;


        clsLocalDrivingLicenseApplication _LocalDrivngLiceseApplication;
        public frmLocalLicenseApplication(int LocalDrivngLiceseApplicationID, string userName)
        {
            InitializeComponent();
            UserName = userName;

            Mode = LocalDrivngLiceseApplicationID != -1 ? enMode.updateMode : enMode.addMode;

        }


        private void _fillLicenseClassCB()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
            cbLicenseClass.SelectedIndex = 0;


        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void frmLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            //fill combo box with licenses
            _fillLicenseClassCB();

            if (Mode == enMode.addMode)
            {
                lblAddNewTitle.Text = "Add New Local Driving License Application";
                _LocalDrivngLiceseApplication = new clsLocalDrivingLicenseApplication(); 
                lblApplicationDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                lblApplicationFees.Text = clsApplicationType.
                    Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblUserCreation.Text = clsUsers.Find(UserName).UserName;

            }


           


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            clsLocalDrivingLicenseApplication _LocalDrivngLiceseApplication = new clsLocalDrivingLicenseApplication();

            // Set application data
            _LocalDrivngLiceseApplication.ApplicantPersonID = ucFilteringData1.PersonID;

            // Validate and parse the application date
            if (DateTime.TryParse(lblApplicationDate.Text, out DateTime applicationDate))
            {
                _LocalDrivngLiceseApplication.ApplicationDate = applicationDate;
            }

            _LocalDrivngLiceseApplication.ApplicationTypeID = clsApplicationType.Find((int)
                clsApplication.enApplicationType.NewDrivingLicense).ID;
            _LocalDrivngLiceseApplication.ApplicationStatus = (clsApplication.enApplicationStatus.New);
            _LocalDrivngLiceseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivngLiceseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivngLiceseApplication.CreatedByUserID = clsUsers.Find(UserName).UserID;
            _LocalDrivngLiceseApplication.LicenseClassID = cbLicenseClass.SelectedIndex + 1;


            if (clsLocalDrivingLicenseApplication.GetActiveApplicationIDForLicenseClass(
                                                                      _LocalDrivngLiceseApplication.ApplicantPersonID,
                                                                      _LocalDrivngLiceseApplication.LicenseClassID))
            {

                MessageBox.Show("There Is an Active Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (_LocalDrivngLiceseApplication.Save())
            {
                MessageBox.Show("Application Added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Application Not Added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }


        private void tabPage2_Click(object sender, EventArgs e)
        {


        }
    }
}
