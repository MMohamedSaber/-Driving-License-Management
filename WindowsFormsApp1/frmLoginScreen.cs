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
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           string UserName=txtUserName.Text;
           string Password=txtPassword.Text;

            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                if (clsUsers.Find(UserName, Password))
                {
                    Form1 frm = new Form1();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username/Passord", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Fill The Field", "Asking", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "The User Name is empty");
            }

            //if (clsPerson.Find(txtNationalNo.Text))
            //{
            //    errorProvider1.SetError(txtNationalNo, "The National Number already exists");
            //}
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "The Password Field is empty");
            }
        }
    }
}
