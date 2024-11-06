using cc;
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
        // Private member variables
        private clsPerson _Person;
        private int _PersonId;
        private enum Mode { AddMode = 0, UpdateMode = 1 }
        private Mode _Mode = Mode.AddMode;

        // Constructor that initializes the form and determines if adding or updating a person
        public AddEditPerson(int personID)
        {
            InitializeComponent();
            _PersonId = personID;

            _Mode = (_PersonId == -1) ? Mode.AddMode : Mode.UpdateMode;
        }

        // Load data into the form fields based on the current mode
        private void LoadData()
        {
            _FillCountryInComboBox(); // Populate the country ComboBox

            if (_Mode == Mode.AddMode)
            {
                lblTitle.Text = "Add New Contact";
                _Person = new clsPerson();
                return;
            }

            // Load existing person data for update mode
            _Person = clsPerson.Find(_PersonId);
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

            // Select the appropriate country in the ComboBox
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.Find(_Person.NationalityCountryID).CountryName);

            // Load profile photo if available
            if (_Person.ImagePath != null)
            {
                ProfilePhoto.Load(_Person.ImagePath);
            }
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

        // Event handler for form load
        private void AddEditPerson_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Save or update person information
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPerson Person1 = new clsPerson();

            // Populate person details from input fields
            Person1.NationalNo = txtNationalNo.Text;
            Person1.FirstName = txtFirstName.Text;
            Person1.SecondName = txtSecondName.Text;
            Person1.ThirdName = txtThirdName.Text;
            Person1.LastName = txtLastName.Text;
            Person1.DateOfBirth = dtDateOFBirth.Value;
            Person1.Gender = rbMale.Checked ? 0 : 1;
            Person1.Address = txtAddress.Text;
            Person1.Phone = txtPhone.Text;
            Person1.Email = txtEmail.Text;
            Person1.NationalityCountryID = clsCountries.Find(cbCountry.Text).ID;
            Person1.ImagePath = ProfilePhoto.ImageLocation;

            // Attempt to save the person details to the database
            if (Person1.Save())
            {
                MessageBox.Show(_Mode == Mode.AddMode ? "The Person Saved Successfully" : "The Person Updated Successfully");
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

            if (clsPerson.Find(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "The National Number already exists");
            }
        }

        // Validate Address field
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "The Address Field is empty");
            }
        }

        // Cancel the operation and close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Currently not used
        }
    }
}
