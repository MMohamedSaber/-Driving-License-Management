using DVLBuisnesLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmChangePassword : Form
    {
        int _PersonID; // Stores the ID of the person
        clsUsers _users; // Instance of the clsUsers business layer
        clsPerson _persons; // Instance of the clsPerson business layer

        // Constructor to initialize the form and set PersonID
        public frmChangePassword(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        // Method to load user and person details into the user interface
        private void _loadUserDetails()
        {
            _persons = clsPerson.Find(_PersonID); // Retrieve person details
            _users = clsUsers.Find(_PersonID);   // Retrieve user details

            if (_persons != null && _users != null)
            {
                // Populate person details
                ucUserInformation1.PersonID = _persons.ID.ToString();
                ucUserInformation1.FullName = $"{_persons.FirstName} {_persons.SecondName} {_persons.ThirdName} {_persons.LastName}";
                ucUserInformation1.NationalNo = _persons.NationalNo;
                ucUserInformation1.Email = _persons.Email;
                ucUserInformation1.Address = _persons.Address;
                ucUserInformation1.Gender = _persons.Gender.ToString();
                ucUserInformation1.Phone = _persons.Phone;
                ucUserInformation1.DateOfBirth = _persons.DateOfBirth;
                ucUserInformation1.Country = clsCountries.Find(_persons.NationalityCountryID).CountryName;
                ucUserInformation1.ImagePath = _persons.ImagePath;

                
                    // Populate user details
                    ucUserInformation1.UserID = _users.UserID.ToString();
                    ucUserInformation1.UserName = _users.UserName;
                    ucUserInformation1.IsActive = _users.IsActive ? "Yes" : "No";
                
            }
        }

        // Event handler: Load user details when the control is loaded
        private void ucUserInformation1_Load(object sender, EventArgs e)
        {
            _loadUserDetails();
        }

        // Validates the current password by checking its correctness
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!clsUsers.RightPassword(_users.UserName, txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "Password is not right!");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, string.Empty); // Clear error for this field
            }
        }

        // Utility method to validate if two password fields match
        void notMatchedPasswords(TextBox txt1, TextBox txt2)
        {
            if (txt1.Text.Trim() != txt2.Text.Trim())
            {
                errorProvider1.SetError(txt1, "The two new passwords are not matched.");
            }
            else
            {
                errorProvider1.SetError(txt1, string.Empty); // Clear error
            }
        }

        // Validates the new password
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            notMatchedPasswords(txtNewPassword, txtConfirmPassword);
        }

        // Validates the confirmation password
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            notMatchedPasswords(txtConfirmPassword, txtNewPassword);
        }

        // Event handler: Close the form when the cancel button is clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Utility method to display messages in a MessageBox
        private void ShowMessage(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        // Validates all password-related fields
        bool IsValidPasswords()
        {
            // Check if the current password is correct
            if (!clsUsers.RightPassword(_users.UserName.Trim(), txtCurrentPassword.Text.Trim()))
                return false;

            // Check if the new passwords match
            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                return false;

            return true; // Passwords are valid
        }

        // Event handler: Save the new password when the save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate passwords before proceeding
            if (!IsValidPasswords()) return;

            // Update the user's password
            _users = clsUsers.Find(_PersonID); // Fetch updated user details
            _users.Password = txtNewPassword.Text;
            ShowMessage("Password changed successfully.", "Confirm", MessageBoxIcon.Exclamation);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
