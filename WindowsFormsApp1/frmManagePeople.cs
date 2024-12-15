using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLBuisnesLayer;

namespace WindowsFormsApp1
{
    public partial class frmManagePeople : Form
    {
        // DataTable to hold people data
        DataTable peopleTable;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Refresh the DataGridView with the latest data from the database.
        /// </summary>
        public void _RefreshDataToTable()
        {
            peopleTable = clsPerson.LoadAllData(); // Load all people data from the database
            dgvPeople.DataSource = peopleTable; // Bind the DataTable to the DataGridView
            dgvPeople.ContextMenuStrip = contextMenuStrip1; // Assign the context menu to the DataGridView
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshDataToTable(); // Load data when the form is loaded
        }

        /// <summary>
        /// Handle the close menu item click event.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        /// <summary>
        /// Apply the filter when the selected index in the ComboBox changes.
        /// </summary>
        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbFilterData.Text) && !string.IsNullOrEmpty(txtSearchKey.Text))
            {
                _ApplyFilter(cbFilterData.Text, txtSearchKey.Text); // Apply filter when a different column is selected
            }
        }

        

        /// <summary>
        /// Open the Add/Edit Person form in Add mode.
        /// </summary>
        void _LoadAddNewPage()
        {
            AddEditPerson frm = new AddEditPerson(); // -1 indicates adding a new person
            frm.ShowDialog(); // Show the form as a dialog
            _RefreshDataToTable(); // Refresh the DataGridView after adding a new person
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadAddNewPage(); // Handle the "Add New" button click
        }

        /// <summary>
        /// Apply filter dynamically as the user types in the search box.
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchKey.Text))
            {
                cbFilterData.Enabled = true; // Enable the ComboBox when search is empty
            }
            else
            {
                cbFilterData.Enabled = false; // Disable the ComboBox when typing in search
            }
            _ApplyFilter(cbFilterData.Text, txtSearchKey.Text); // Apply the filter
        }





        /// <summary>
        /// Apply a filter to the DataGridView based on the specified column and key.
        /// </summary>
        private void _ApplyFilter(string filterBy, object key)
        {
            DataView view = peopleTable.DefaultView;

            // Check if the key is numeric
            if (int.TryParse(key.ToString(), out int numericKey))
            {
                view.RowFilter = $"{filterBy} = {key}"; // Exact match for numbers
            }
            else
            {
                view.RowFilter = $"{filterBy} LIKE '%{key}%'"; // Partial match for text
            }

            dgvPeople.DataSource = view; // Bind the filtered view to the DataGridView
        }

        /// <summary>
        /// Open the Add/Edit Person form in Edit mode with the selected person's ID.
        /// </summary>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dgvPeople.CurrentRow.Cells[0].Value; // Get the selected person's ID
            AddEditPerson frm = new AddEditPerson(personId); // Open the form in Edit mode
            frm.ShowDialog();
            _RefreshDataToTable(); // Refresh the DataGridView after editing
        }

        /// <summary>
        /// Delete the selected person after confirmation.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dgvPeople.CurrentRow.Cells[0].Value; // Get the selected person's ID

            // Show a confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this person?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool isDeleted = clsPerson.DeletePerson(personId); // Attempt to delete the person
                if (isDeleted)
                {
                    _RefreshDataToTable(); // Refresh data if the person was deleted
                }
                else
                {
                    MessageBox.Show(
                        "Person was not deleted because it has data linked to it.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        /// <summary>
        /// Open the Person Details form to view additional details of the selected person.
        /// </summary>
        private void udateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dgvPeople.CurrentRow.Cells[0].Value; // Get the selected person's ID
            frmPersonDetails frm = new frmPersonDetails(personId); // Open the form with the person's ID
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // Handle the opening event for the context menu (if needed)
        }

        private void cbFilterData_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
