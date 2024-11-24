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
    public partial class frmUpdateTestType :Form 
    {

        clsTestType _testType;
        int _testTypeID;
        public frmUpdateTestType(int testTypeID)
        {
            InitializeComponent();
            _testTypeID = testTypeID;   
        }


        private void refreshData()
        {
            _testType = clsTestType.Find(_testTypeID);

            if (_testType != null)
            {
                lblTestTypeID.Text = _testTypeID.ToString();
                txtTitle.Text = _testType.TestTitle.ToString();
                txtDescriptioin.Text = _testType.TestDescription;
                txtFees.Text = _testType.Fees.ToString();
            }
        }
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            refreshData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescriptioin.Text) && string.IsNullOrEmpty(txtFees.Text) && string.IsNullOrWhiteSpace(txtTitle.Text))
              return;


            _testType.TestTitle = txtTitle.Text;
            _testType.TestDescription = txtDescriptioin.Text;
            _testType.Fees = Convert.ToDouble(txtFees.Text);



            DialogResult Result = MessageBox.Show("Are you sure that you want to save Changes", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {

                if (_testType.Save())
                {
                    MessageBox.Show("Changes Saved Successfully", "Confirm",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            this.Close();
            refreshData();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
