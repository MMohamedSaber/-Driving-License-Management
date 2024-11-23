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
    public partial class frmUpdateApplicationType : Form
    {

        clsApplicationType _applicationType;
     private   int _applicationTypeId = -1;
        public frmUpdateApplicationType(int applicationTypeId)
        {
            InitializeComponent();
            _applicationTypeId = applicationTypeId;
        }


        private void _RefreshLoadApplicationTypeDate()
        {
            _applicationType = clsApplicationType.Find(_applicationTypeId);

            if (_applicationType != null)
            {
                lblID.Text = _applicationType.ID.ToString();
                txtTitle.Text = _applicationType.ApplicationTypeName;
                txtFees.Text=_applicationType.Fees.ToString();

            }

        }
        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _RefreshLoadApplicationTypeDate();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close  ();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          //  clsApplicationType applicationType = new clsApplicationType();

            if (string.IsNullOrEmpty(txtTitle.Text) && string.IsNullOrEmpty(txtFees.Text))
            {
                MessageBox.Show("The Title or the Fees is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          //  _applicationType = new clsApplicationType();
            //  applicationType.ID= _applicationTypeId;
            _applicationType.ApplicationTypeName = txtTitle.Text;
            _applicationType.Fees= Convert.ToDouble(txtFees.Text);


               
            DialogResult Result = MessageBox.Show("Are you sure that you want to save Changes", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {

                if (_applicationType.Save())
                {
                    MessageBox.Show("Changes Saved Successfully", "Confirm",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            _RefreshLoadApplicationTypeDate();


        }
    }
}
