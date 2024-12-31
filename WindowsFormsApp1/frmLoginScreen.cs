using DVLBuisnesLayer;
using DVLD;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            clsUsers user = clsUsers.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {

                if (chRememberMe.Checked)
                {
                    if (!clsGlobal.SetRememberUserNameAndPassword(txtUserName.Text, txtPassword.Text))
                        Console.WriteLine($"UserName and Passwod did not Save ,Check Rgistry/try statment ");
              
                }
                else
                {
                    if (!clsGlobal.SetRememberUserNameAndPassword("", ""))
                        Console.WriteLine($"UserName and Passwod did not Save ,Check Rgistry/try statment ");


                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
                                       {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "The User Name is empty");
            }

            
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
                            {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "The Password Field is empty");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {

            string UserName="";
            string Password="";

            if (clsGlobal.GetRememberUserNameAndPassword(ref  UserName, ref   Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chRememberMe.Checked = true;
            }
            else
                chRememberMe.Checked = false;
        }
    }
}
