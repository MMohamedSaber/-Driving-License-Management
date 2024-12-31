using DVLBuisnesLayer;
using DVLD;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmUserDetails : Form
    {
        int _userID;
        clsUsers User =new clsUsers();
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUserDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading user details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadUserDetails()
        {
            User = clsUsers.FindByUserID(_userID);

            if (User == null || User.PersonInfo == null)
            {
                MessageBox.Show("No user information available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PopulatePersonDetails();
            PopulateUserDetails();
        }

        private void PopulatePersonDetails()
        {
            
                ucUserInformation1.PersonID = User.PersonInfo.ID.ToString();
                ucUserInformation1.FullName =
                    $"{User.PersonInfo.FirstName} " +
                    $"{User.PersonInfo.SecondName} " +
                    $"{User.PersonInfo.ThirdName} " +
                    $"{User.PersonInfo.LastName}";
                ucUserInformation1.NationalNo = User.PersonInfo.NationalNo;
                ucUserInformation1.Email = User.PersonInfo.Email;
                ucUserInformation1.Address = User.PersonInfo.Address;
                ucUserInformation1.Gender = User.PersonInfo.Gender.ToString();
                ucUserInformation1.Phone = User.PersonInfo.Phone;
                ucUserInformation1.DateOfBirth = User.PersonInfo.DateOfBirth;
                ucUserInformation1.Country = clsCountries.Find(User.PersonInfo.NationalityCountryID)?.CountryName ?? "Unknown";
                ucUserInformation1.ImagePath = User.PersonInfo.ImagePath;
            
        }

        private void PopulateUserDetails()
        {
           
                ucUserInformation1.UserID = User.UserID.ToString();
                ucUserInformation1.UserName = User.UserName;
                ucUserInformation1.IsActive = User.IsActive ? "Yes" : "No";
            
        }
    }
}
