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
    public partial class frmUserDetails : Form
    {
        int _personID;
        clsPerson _persons;
        clsUsers _users;
        public frmUserDetails(int personId)
        {
            InitializeComponent();
            _personID=personId;
        }

        private void ucUserInformation1_Load(object sender, EventArgs e)
        {

        }
        void LoadUserDetails()
        {
            _persons = clsPerson.Find(_personID);
            _users = clsUsers.Find(_personID);

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

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            LoadUserDetails();
        }
    }
}
