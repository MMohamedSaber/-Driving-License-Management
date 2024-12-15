using DVLBuisnesLayer;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UCFilteringData : UserControl
    {
        private clsPerson _Person = new clsPerson(); // Instance of the clsPerson business layer

        public UCFilteringData()
        {
            InitializeComponent();
        }

        // Property to retrieve the PersonID
        public int PersonID
        {
            get
            {
                // Ensure ucPersonDetails1.PersonID is valid and can be parsed as an integer
                if (int.TryParse(ucPersonDetails1.PersonID, out int personID))
                {
                    return personID;
                }
                else
                {
                    return -1; // Return -1 or a default value if the ID is invalid
                }
            }
        }


       
        public string txtSearch
        {
            set
            {
                txtSearchKey.Text= value;
                txtSearchKey.Refresh();
            }
        }

        // Populates details of a person into the UserControl
        private void _PopulatePersonDetails(clsPerson person)
        {
            ucPersonDetails1.PersonID = person.ID.ToString(); // Assign the ID to ucPersonDetails1
            ucPersonDetails1.FullName = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
            ucPersonDetails1.NationalNo = person.NationalNo;
            ucPersonDetails1.Email = person.Email;
            ucPersonDetails1.Address = person.Address;
            ucPersonDetails1.Gender = person.Gender.ToString();
            ucPersonDetails1.Phone = person.Phone;
            ucPersonDetails1.DateOfBirth = person.DateOfBirth;
            ucPersonDetails1.Country = clsCountries.Find(person.NationalityCountryID).CountryName;
            ucPersonDetails1.ImagePath = person.ImagePath; // Load image
        }

        // Search box text changed event handler
        private void txtSearchKey_TextChanged_1(object sender, EventArgs e)
        {
            cbFeltringData.Enabled = string.IsNullOrEmpty(txtSearchKey.Text); // Enable/disable ComboBox based on input
        }

        // Input validation for search key
        private void txtSearchKey_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cbFeltringData.SelectedIndex == 1 && char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }
        }

        // Finds and shows data based on search criteria
        private void _FindDataToShow()
        {
            if (cbFeltringData.SelectedItem.ToString() == "NationalNo")
            {
                if (!string.IsNullOrWhiteSpace(txtSearchKey.Text))
                {
                    _Person = clsPerson.Find(txtSearchKey.Text); // Find person by NationalNo

                    if (_Person != null)
                    {
                        _PopulatePersonDetails(_Person); // Populate person details
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

        // Button click handler for search

            private void btnSearch_Click(object sender, EventArgs e)
            {
                _FindDataToShow(); // Execute search
            }


      
            
        // Button click handler for adding a new person
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPerson frm = new AddEditPerson(-1);
            frm.DataBack += _PopulatePersonDetails; // Assign callback to populate details
            frm.ShowDialog();
        }

        // User control load event handler
        private void UCFilteringData_Load(object sender, EventArgs e)
        {
            cbFeltringData.SelectedIndex = 0; // Set default selected index
        }

        public void DiableFilter()
        {
            groupBox1.Enabled=false;
                _FindDataToShow();
        }
        private void ucPersonDetails1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
