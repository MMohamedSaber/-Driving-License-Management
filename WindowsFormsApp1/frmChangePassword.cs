using DVLBuisnesLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmChangePassword : Form
    {
        int  _UerID; // Stores the ID of the person
        clsUsers _users; // Instance of the clsUsers business layer
        clsPerson _persons; // Instance of the clsPerson business layer

        // Constructor to initialize the form and set PersonID
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UerID = userID;
        }

        // Method to load user and person details into the user interface
        private void _loadUserDetails()
        {
            // Retrieve user details
            _users = clsUsers.FindByUserID(_UerID);
            if (_users != null)
            {
                // Populate person details
                ucUserInformation1.PersonID = _users.PersonInfo.ID.ToString();
                ucUserInformation1.FullName = 
                    $"{_users.PersonInfo.FirstName} " +
                    $"{_users.PersonInfo.SecondName}" +
                    $" {_users.PersonInfo.ThirdName}" +
                    $" {_users.PersonInfo.LastName}";
                ucUserInformation1.NationalNo = _users.PersonInfo.NationalNo;
                ucUserInformation1.Email = _users.PersonInfo.Email;
                ucUserInformation1.Address = _users.PersonInfo.Address;
                ucUserInformation1.Gender = _users.PersonInfo.Gender.ToString();
                ucUserInformation1.Phone = _users.PersonInfo.Phone;
                ucUserInformation1.DateOfBirth = _users.PersonInfo.DateOfBirth;
                ucUserInformation1.Country = clsCountries.Find(_users.PersonInfo.NationalityCountryID).CountryName;
                ucUserInformation1.ImagePath = _users.PersonInfo.ImagePath;

                
                    // Populate user details
                    ucUserInformation1.UserID   =  _users.UserID.ToString();
                    ucUserInformation1.UserName =  _users.UserName;
                    ucUserInformation1.IsActive =  _users.IsActive ? "Yes" : "No";
                
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
            _users = clsUsers.Find(_UerID); // Fetch updated user details
            _users.Password = txtNewPassword.Text;
            ShowMessage("Password changed successfully.", "Confirm", MessageBoxIcon.Exclamation);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
