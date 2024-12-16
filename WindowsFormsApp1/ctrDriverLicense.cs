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
    public partial class ctrDriverLicense : UserControl
    {

        public ctrDriverLicense()
        {
            InitializeComponent();
        }

        

        public void LoadDriverInDgv(int DriverID)
        {

            dataGridView3.DataSource = clsDrivers.GetDriverRowByDriverID(DriverID);
            dgvInterNationalLicense.DataSource = clsInternationalLicense.GetDriverRowByDriverID(DriverID);
        }

        

       
    }
}
