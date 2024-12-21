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
    public partial class frmAddNewUser : Form
    {
        // Enumeration to define modes for adding or updating a user
        private enum enMode { AddMode = 1, UpdateMode = 2 }
        private enMode _Mode = enMode.AddMode; // Default mode
        private int _PersonID; // Stores the ID of the person
        clsUsers _User = new clsUsers(); // Instance of the clsUsers business layer


        public frmAddNewUser()
        {
                
        }
        // Constructor to initialize the form
        public frmAddNewUser(int UserID)
        {
            InitializeComponent();
            _PersonID = UserID;

            // Determine the mode based on whether a valid UserID is passed
            _Mode = _PersonID == -1 ? enMode.AddMode : enMode.UpdateMode;
        }

        clsPerson _Person = new clsPerson(); // Instance of the clsPerson business layer


        private void _PopulatePersonDetails(clsPerson Person)
        {
            ucPersonDetails1.PersonID = Person.ID.ToString();
            ucPersonDetails1.FullName = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            ucPersonDetails1.NationalNo = Person.NationalNo;
            ucPersonDetails1.Email = Person.Email;
            ucPersonDetails1.Address = Person.Address;
            ucPersonDetails1.Gender = Person.Gender.ToString();
            ucPersonDetails1.Phone = Person.Phone;
            ucPersonDetails1.DateOfBirth = Person.DateOfBirth;
            ucPersonDetails1.Country = clsCountries.Find(Person.NationalityCountryID).CountryName;
            ucPersonDetails1.ImagePath = Person.ImagePath; // Load image
        }
        // Method to load data into the form based on the mode
        private void _LoadData()
        {
            cbFindPersonBy.SelectedIndex = 1; // Default search option

            if (_Mode == enMode.AddMode)
            {
                lblAddNewTitle.Text = "Add New User"; // Set title for Add mode
                return;
            }
            else
            {
                lblAddNewTitle.Text = "Update User"; // Set title for Update mode

                // Load person and user details
                _Person = clsPerson.Find(_PersonID);
                _User = clsUsers.Find(_PersonID);
                groupBox1.Enabled = false; // Disable group box for editing
                txtSearchKey.Text = _User.PersonID.ToString();

                if (_Person != null && _User != null)
                {
                    // Populate person details
                    _PopulatePersonDetails(_Person);

                    // Populate user details
                    lblUserID.Text = _User.UserID.ToString();
                    txtUserName.Text = _User.UserName;
                    txtPassword.Text = _User.Password;
                    txtConfirmPassword.Text = _User.Password;
                }
            }
        }

        // Method to search and display a person's data based on search criteria
        private void _FindDataToShow()
        {
            if (cbFindPersonBy.SelectedItem.ToString() == "NationalNo")
            {
                if (!string.IsNullOrWhiteSpace(txtSearchKey.Text))
                {
                    _Person = clsPerson.Find(txtSearchKey.Text); // Find person by NationalNo

                    if (_Person != null)
                    {
                        // Populate person details in the user control
                        _PopulatePersonDetails(_Person);
                    }
                    else
                    {
                        MessageBox.Show($"No person found with National No {txtSearchKey.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Search text is empty. Please fill it in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Event: Form load
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _LoadData(); // Load data on form initialization
        }

        // Event: Search key text changes
        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            cbFindPersonBy.Enabled = string.IsNullOrEmpty(txtSearchKey.Text); // Enable or disable the ComboBox
        }

        // Event: Open person edit link
        private void button3_Click(object sender, EventArgs e)
        {
           AddEditPerson frm=new AddEditPerson();
            frm.DataBack+= _PopulatePersonDetails;
            frm.ShowDialog();

        }

        // Event: Search user button click
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            _FindDataToShow(); // Execute search
        }

        // Event: Proceed to the next tab after verifying user existence
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchKey.Text))
            {
                if (clsUsers.IsUserExist(_Person.ID))
                {
                    MessageBox.Show("The person is already a user. Choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tbLoginInfo.SelectedTab = tabPage2; // Switch to the next tab
                }
            }
            else
            {
                MessageBox.Show("Search for a person first to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event: Validate the username field
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Add a username.");
            }
        }

        // Event: Validate the password field
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Enter your password.");
            }
        }

        // Event: Validate password confirmation
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
            }
        }

        // Event: Save the new or updated user data
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Please enter the username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save user data
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = CheckIsActive.Checked;
            _User.PersonID = clsPerson.Find(_Person.ID).ID;

            if (_User.Save())
            {
                MessageBox.Show("The user was saved successfully.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text = _User.UserID.ToString();
                lblAddNewTitle.Text = "Update User";
            }
            else
            {
                MessageBox.Show("Save failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event: Cancel the operation and close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFindPersonBy.SelectedIndex == 0 && char.IsLetter(e.KeyChar) && 
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}