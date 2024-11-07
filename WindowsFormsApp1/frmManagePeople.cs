using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLBuisnesLayer;



namespace WindowsFormsApp1
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }


        DataTable peopleTable;

      public  void _RefreshDataToTable()
        {
            peopleTable = clsPerson.LoadAllData();
            dgvPeople.DataSource = peopleTable;
            dgvPeople.ContextMenuStrip = contextMenuStrip1;

        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshDataToTable();
            cbFilterData.SelectedIndex = 0;
        }



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e) 
        {


            ApplyFilter();
        //{
        //    DataView PeopleDataVieu = peopleTable.DefaultView;

            //    if (cbFilterData.SelectedItem != null)
            //    {
            //        string selectedColumn = cbFilterData.SelectedItem.ToString();

            //        // Check if the selected item is a valid column in the DataTable
            //        if (peopleTable.Columns.Contains(selectedColumn))
            //        {
            //            PeopleDataVieu.RowFilter = $"[{selectedColumn}] IS NOT NULL"; // To display all rows for the column
            //        }
            //        else
            //        {
            //            PeopleDataVieu.RowFilter = ""; // Clear filter if invalid column
            //        }
            //    }
        }
        private void ApplyFilter()
        {
            if (peopleTable == null)
                return;

            DataView PeopleDataVieu = peopleTable.DefaultView;
            string selectedColumn = cbFilterData.SelectedItem?.ToString();//The ?. operator is used to prevent errors if no item is selected in the ComboBox. If nothing is selected, selectedColumn will be set to null instead of causing an exception.

            string searchText = textBox1.Text.Trim();

            // Ensure the selected column exists in the DataTable
            if (!string.IsNullOrEmpty(selectedColumn) && peopleTable.Columns.Contains(selectedColumn))
            {
                // Set RowFilter to display rows matching the search text in the selected column
                PeopleDataVieu.RowFilter = string.IsNullOrEmpty(searchText)
                    ? $"[{selectedColumn}] IS NOT NULL" // Show all non-null rows for the column if search text is empty
                    : $"[{selectedColumn}] LIKE '%{searchText}%'";
            }
            else
            {
                PeopleDataVieu.RowFilter = ""; // Clear filter if no valid column is selected
            }
        }

        void _LoadAddNewPage()
        {
            AddEditPerson frm = new AddEditPerson(-1);
            frm.ShowDialog();
            _RefreshDataToTable();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _LoadAddNewPage();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadAddNewPage();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AddEditPerson frm = new AddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshDataToTable();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonNumber = (int)dgvPeople.CurrentRow.Cells[0].Value;

            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (!clsPerson.IsAssociated(PersonNumber))
                {
                    clsPerson.DeletePerson(PersonNumber);
                    _RefreshDataToTable();
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void udateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
