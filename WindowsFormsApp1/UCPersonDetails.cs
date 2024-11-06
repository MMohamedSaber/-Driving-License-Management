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
    public partial class UCPersonDetails : UserControl
    {
        public UCPersonDetails()
        {
            InitializeComponent();
        }

       



        public string PersonID { set { lblPersonID.Text = value; } }
        public string FullName { set { lblName.Text = value; } }
        public string NationalNo{ set { lblNationalNo.Text = value; } }
        public string Email { set { lblEmail.Text = value; } }
        public string Gender { set { lblGender.Text = value; } }
        public string Address { set { lblAddress.Text = value; } }
        public DateTime DateOfBirth { set { lblDateOfBirth.Text = value.ToString("yyy-MM-dd"); } }
        public string Phone { set { lblPhone.Text = value; } }
        public string Country { set { lblCountry.Text = value; } }

       public string ImagePath {set {ProfilePhoto.Load(value); } }
        private void UCPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void lbEdithPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            // Try to parse the PersonID to an integer
            if (int.TryParse(lblPersonID.Text, out int personId))
            {
                // Pass the parsed integer to AddEditPerson
                AddEditPerson frm = new AddEditPerson(personId);
                frm.ShowDialog();
            }
            else
            {
                // Show an error message if parsing fails
                MessageBox.Show("Invalid Person ID. Unable to open edit form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
