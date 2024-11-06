using cc;
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
    public partial class frmPersonDetails : Form
    {
      private  int ID = -1;
        private clsPerson _Person;

        public frmPersonDetails(int personID)
        {
            InitializeComponent();

            ID=personID;
        }


        private void _LoadDataInControle()
        {
            _Person = clsPerson.Find(ID);
            if (_Person != null) 
            {
                ucPersonDetails1.PersonID= _Person.ID.ToString();
                ucPersonDetails1.FullName= _Person.FirstName +" " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
                ucPersonDetails1.NationalNo= _Person.NationalNo;
                ucPersonDetails1.Email= _Person.Email;
                ucPersonDetails1.Address= _Person.Address;
                ucPersonDetails1.Gender = _Person.Gender.ToString();
                ucPersonDetails1.Phone = _Person.Phone;
                ucPersonDetails1.DateOfBirth= _Person.DateOfBirth;
                ucPersonDetails1.Country=clsCountries.Find(_Person.NationalityCountryID).CountryName;
                //   ucPersonDetails1.ImagePath.Imag= _Person.ImagePath;

                ucPersonDetails1.ImagePath = _Person.ImagePath;

            }
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
             _LoadDataInControle();
        }

        private void ucPersonDetails1_Load(object sender, EventArgs e)
        {
           


        }
    }
}
