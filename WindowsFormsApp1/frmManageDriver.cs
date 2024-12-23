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
    public partial class frmManageDriver : Form
    {
        public frmManageDriver()
        {
            InitializeComponent();
        }

       DataTable dtDrivers ;
        private void frmManageDriver_Load(object sender, EventArgs e)
        {
            dtDrivers=clsDrivers.GetAllDrivers();
            dgvUsers.DataSource = dtDrivers;
            lblRecords.Text = dgvUsers.RowCount.ToString();
        }

        //private void _ApplyFilter(string filterBy, object key)
        //{
        //    DataView view = dtDrivers.DefaultView; // Create a DataView for filtering

        //    if (int.TryParse(key.ToString(), out int numericKey)) // Check if the filter value is numeric
        //    {
        //        view.RowFilter = $"{filterBy} = {key}"; // Apply exact match filter for numeric values
        //    }
        //    else
        //    {
        //        view.RowFilter = $"{filterBy} LIKE '%{key}%'"; // Apply partial match filter for text values
        //    }
        //}

        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(cbFilterUsers.Text) && !string.IsNullOrEmpty(txtSearch.Text)) // Check if inputs are valid
            //{
            //    _ApplyFilter(cbFilterUsers.Text, txtSearch.Text); // Apply the filter based on user inputs
            //}

        }
    }
}
