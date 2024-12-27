using DVLBuisnesLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddEditPerson : Form
    {
       public delegate void FillDataInfo(clsPerson person);
        public event FillDataInfo DataBack;


        // Private member variables
        private clsPerson _Person;
        private int _PersonId;
        private enum enMode { AddMode = 0, UpdateMode = 1 }
        private enMode Mode = enMode.AddMode;


        public AddEditPerson( )
        {
            InitializeComponent();
            
            Mode= enMode.AddMode;
           
        }
        // Constructor that initializes the form and determines if adding or updating a person
        public AddEditPerson(int personID)
        {
            InitializeComponent();
            _PersonId = personID;
            Mode= enMode.UpdateMode;

        }

        



        // Load data into the form fields based on the current mode
        private void _ResetDefaultValues()
        {
            _FillCountryInComboBox(); // Populate the country ComboBox

            if (Mode == enMode.AddMode)
            {
                lblTitle.Text = "Add New Contact";
                _Person = new clsPerson();

              
            }else
            {
                lblTitle.Text = "Update Person";

            }

            if (rbMale.Checked)
                ProfilePhoto.Image = Properties.Resources.Male_512;
            else
                ProfilePhoto.Image = Properties.Resources.Female_512;

            //hide and show remove photo button
            lbRemovePhoto.Visible = (ProfilePhoto.ImageLocation != null);

            //set make Date
            dtDateOFBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOFBirth.Value = dtDateOFBirth.MaxDate;

            //set Min Date
            dtDateOFBirth.MinDate= DateTime.Now.AddYears(-100);

            //set default Country
            cbCountry.SelectedIndex =cbCountry.FindString("Chile");

            txtFirstName.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            rbMale.Checked = true;

        }

        // Fill the country ComboBox with values from the database
        private void _FillCountryInComboBox()
        {
            DataTable dt = clsCountries.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        // Event handler for Female radio button selection
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                ProfilePhoto.Image = Properties.Resources.Female_512; // Set female profile icon
            }
        }

        // Event handler for Male radio button selection
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                ProfilePhoto.Image = Properties.Resources.Male_512; // Set male profile icon
            }
        }

        // Validate the email format
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address (e.g., example@domain.com)");
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
            }
        }

        private void _LoadData()
        {

            // Load existing person data for update mode
            _Person = clsPerson.Find(_PersonId);

            if (_Person == null)
            {
                MessageBox.Show($"No Person with ID={_PersonId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }
            lblTitle.Text = $"Update Person = {_Person.ID} ";
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtDateOFBirth.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;

            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.Find(_Person.NationalityCountryID).CountryName);



            // Load profile photo if available
            if(_Person.ImagePath!="")
            {
                ProfilePhoto.ImageLocation=_Person.ImagePath;
            }

            lbRemovePhoto.Visible = (_Person.ImagePath != "");


        }


        // Event handler for form load
        private void AddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == enMode.UpdateMode)
                _LoadData();

            
        }

        // Save or update person information
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Populate person details from input fields
            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.DateOfBirth = dtDateOFBirth.Value;
            _Person.Gender = rbMale.Checked ? 0 : 1;
            _Person.Address = txtAddress.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.NationalityCountryID = clsCountries.Find(cbCountry.Text).ID;
            _Person.ImagePath = ProfilePhoto.ImageLocation;
            // Attempt to save the person details to the database

            if (_Person.Save())
            {
                MessageBox.Show(Mode == enMode.AddMode ? "The Person Saved Successfully" : "The Person Updated Successfully");
                DataBack?.Invoke(_Person);
            }
            else
            {
                MessageBox.Show("Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for setting a profile photo
        private void lbsetPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FDSetPhoto.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            FDSetPhoto.FilterIndex = 1;
            FDSetPhoto.RestoreDirectory = true;

            if (FDSetPhoto.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = FDSetPhoto.FileName;
                ProfilePhoto.Load(selectedFilePath); // Load the selected photo
                lbRemovePhoto.Enabled = true; // Enable Remove Photo option
            }
        }

        // Event handler for removing the profile photo
        private void lbRemovePhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProfilePhoto.Image = null; // Clear the photo
            lbRemovePhoto.Enabled = false; // Disable the Remove Photo link label
        }

        // Validate National Number field
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "The National Number is empty");
            }

            if (clsPerson.IsExist(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "The National Number already exists");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        // Validate Address field
        private void txtAddress_Validating(object sender, CancelEventArgs e)
                {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "The Address Field is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        // Cancel the operation and close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
