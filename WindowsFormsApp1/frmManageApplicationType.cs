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
    public partial class frmManageApplicationType : Form
    {
        public frmManageApplicationType()
        {
            InitializeComponent();


        }


       private void LoadAppTypesData()
        {
          

         dataGridView1.DataSource = clsApplicationType.GettApplicationType();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            lblRecordsTypes.Text=dataGridView1.RowCount.ToString(); 

        }
        private void frmManageApplicationType_Load(object sender, EventArgs e)
        {
            LoadAppTypesData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);  
            frm.ShowDialog();


        }
    }
}
