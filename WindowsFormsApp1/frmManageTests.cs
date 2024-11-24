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
    public partial class frmManageTests : Form
    {

     
        public frmManageTests()
        {
            InitializeComponent();

        }

        private void _LoadTestTypeData()
        {
            dgvTestType.DataSource = clsTestType.GetAllTestType();
           lblRecordsTestTypes.Text=dgvTestType.RowCount.ToString();
            dgvTestType.ContextMenuStrip = contextMenuStrip1;

        }


        private void frmManageTests_Load(object sender, EventArgs e)
        {

            _LoadTestTypeData();



        }

        private void dgvTestType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm=new frmUpdateTestType((int)dgvTestType.CurrentRow.Cells[0].Value);
           frm.ShowDialog();
            
        }
    }
}
