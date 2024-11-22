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


    public partial class ucUserInformation : UserControl
    {
        public string PersonID { set { ucPersonDetails1.PersonID= value; } }
        public string FullName { set { ucPersonDetails1.FullName= value; } }
        public string NationalNo { set { ucPersonDetails1.NationalNo= value; } }
        public string Email { set { ucPersonDetails1.Email= value; } }
        public string Gender{ set { ucPersonDetails1.Gender= value; } }
        public string Address{ set { ucPersonDetails1.Address= value; } }
        public DateTime DateOfBirth{ set { ucPersonDetails1.DateOfBirth= value; } }
        public string Phone{ set { ucPersonDetails1.Phone= value; } }
        public string Country{ set { ucPersonDetails1.Country= value; } }

        public string ImagePath { set {ucPersonDetails1.ImagePath= value; } }

        public string UserID { set { lblUserID.Text = value; } }
        public string UserName { set { lblUserName.Text = value; } }
        public string IsActive { set { lblIsActive.Text = value; } }
        






        public ucUserInformation()
        {
            InitializeComponent();
        }

       
    }
}
