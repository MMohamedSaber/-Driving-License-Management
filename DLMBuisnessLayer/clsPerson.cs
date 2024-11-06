using DLMDataAccessLayer;
using System;
using System.Data;

namespace DVLBuisnesLayer
{
    public class clsPerson
    {
        // Enum to distinguish between adding and updating modes
        private enum Mode { AddMode = 0, UpdateMode = 1 };
        private Mode _Mode = Mode.AddMode;

        // Public properties representing the fields of a person
        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        // Default constructor
        public clsPerson() { }

        // Private constructor used for initializing a person with complete data
        private clsPerson(int id, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
                          DateTime dateOfBirth, int gender, string address, string phone, string email,
                          int nationalityCountryID, string imagePath)
        {
            ID = id;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;

            _Mode = Mode.AddMode; // Initialize in add mode by default
        }

        // Static method to check if a person exists by NationalNo
        public static bool Find(string nationalNo)
        {
            return clsPoepleDataAccess.IsPersonExist(nationalNo);
        }

        // Static method to load all data from the person table
        public static DataTable LoadAllData()
        {
            return clsPoepleDataAccess.GetAllDataFromPersonTable();
        }

        // Static method to find a person by ID and return a clsPerson object with loaded data
        public static clsPerson Find(int id)
        {
            // Variables to hold retrieved values
            string nationalNo = "", firstName = "", secondName = "", thirdName = "", lastName = "",
                   address = "", phone = "", email = "", imagePath = "";
            DateTime dateOfBirth = new DateTime();
            int gender = -1;
            int nationalityCountryID = -1;

            // Attempt to retrieve person information
            bool isFound = clsPoepleDataAccess.GetPoepleInfo(id, ref nationalNo, ref firstName, ref secondName,
                                                             ref thirdName, ref lastName, ref dateOfBirth, ref gender,
                                                             ref address, ref phone, ref email,
                                                             ref nationalityCountryID, ref imagePath);
            // Return a new clsPerson instance if found, otherwise null
            return isFound ? new clsPerson(id, nationalNo, firstName, secondName, thirdName, lastName,
                                           dateOfBirth, gender, address, phone, email, nationalityCountryID, imagePath) : null;
        }

        // Private method to add a new person to the database
        private bool _AddNewPerson()
        {
            // Insert new person data and retrieve generated ID
            ID = clsPoepleDataAccess.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                                                  Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            return ID != 0; // Return true if the ID is valid
        }

        // Private method to update an existing person in the database
        private bool _UpdateMode()
        {
            return clsPoepleDataAccess.UpdatePerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                                    DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
        }

        //static method to delete person
public static bool DeletePerson(int ID)
        {
            return clsPoepleDataAccess.DeletePerson(ID);
        }

        // Public method to save person data, handling both add and update modes
        public bool Save()
        {
            switch (_Mode)
            {
                case Mode.AddMode:
                    if (_AddNewPerson())
                    {
                        _Mode = Mode.UpdateMode; // Switch to update mode after adding
                        return true;
                    }
                    return false;

                case Mode.UpdateMode:
                    return _UpdateMode(); // Update if already in update mode

                default:
                    return false;
            }
        }
    }
}
