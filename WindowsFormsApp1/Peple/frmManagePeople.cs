using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLBuisnesLayer;

namespace WindowsFormsApp1
{
    public partial class frmManagePeople : Form
    {
        // Holds the complete dataset of people from the database
        private static DataTable _dtAllPeople = clsPerson.LoadAllData();

        // Filters dataset for columns relevant to display in the DataGridView
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                           "FirstName", "SecondName", "ThirdName", "LastName",
                                                           "Gender", "DateOfBirth", "NationalityCountryID",
                                                           "Phone", "Email");

        public frmManagePeople()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Refreshes the people list by reloading data from the database.
        /// </summary>
        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPerson.LoadAllData();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                           "FirstName", "SecondName", "ThirdName", "LastName",
                                                           "Gender", "DateOfBirth", "NationalityCountryID",
                                                           "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;
        }

        /// <summary>
        /// Initializes the form and sets up the DataGridView columns on load.
        /// </summary>
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _dtPeople;
            cbFilterData.SelectedIndex = 0; // Default selection for the ComboBox

            if (dgvPeople.Rows.Count > 0)
            {
                // Configure column headers and widths for better user experience
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gender";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Applies a filter when the ComboBox selection changes.
        /// </summary>
        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbFilterData.Text) && !string.IsNullOrEmpty(txtSearchKey.Text))
            {
                _ApplyFilter(cbFilterData.Text, txtSearchKey.Text);
            }
        }

        /// <summary>
        /// Opens the Add/Edit Person form in Add mode.
        /// </summary>
        private void _LoadAddNewPage()
        {
            AddEditPerson frm = new AddEditPerson();
            frm.ShowDialog(); // Show as a modal dialog
            _RefreshPeoplList(); // Refresh data after adding a new person
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadAddNewPage();
        }

        /// <summary>
        /// Dynamically applies a filter as the user types in the search box.
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cbFilterData.Enabled = string.IsNullOrEmpty(txtSearchKey.Text); // Toggle ComboBox based on search
            _ApplyFilter(cbFilterData.Text, txtSearchKey.Text);
        }

        /// <summary>
        /// Filters the DataGridView based on the selected column and search key.
        /// </summary>
        private void _ApplyFilter(string filterBy, object key)
        {
            DataView view = _dtPeople.DefaultView;

            // Determine filter type (numeric vs. text)
            if (int.TryParse(key.ToString(), out int numericKey))
            {
                view.RowFilter = $"{filterBy} = {key}"; // Exact match for numeric values
            }
            else
            {
                view.RowFilter = $"{filterBy} LIKE '%{key}%'"; // Partial match for text values
            }

            dgvPeople.DataSource = view;
        }

        /// <summary>
        /// Opens the Add/Edit Person form in Edit mode for the selected person.
        /// </summary>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dgvPeople.CurrentRow.Cells[0].Value;
            AddEditPerson frm = new AddEditPerson(personId);
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        /// <summary>
        /// Deletes the selected person after user confirmation.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dgvPeople.CurrentRow.Cells[0].Value;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this person?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool isDeleted = clsPerson.DeletePerson(personId);
                if (isDeleted)
                {
                    _RefreshPeoplList();
                }
                else
                {
                    MessageBox.Show(
                        "Person was not deleted because it has linked data.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        /// <summary>
        /// Opens the Person Details form for the selected person.
        /// </summary>
        private void udateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmPersonDetails frm = new frmPersonDetails(personId);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // Placeholder for context menu opening logic if needed
        }

        /// <summary>
        /// Restricts input in the search box based on the selected filter column.
        /// </summary>
        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterData.Text == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Prevent non-numeric input for numeric filters
                }
            }
        }
    }
}
