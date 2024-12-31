using DVLBuisnesLayer;
using DVLD;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent(); // Initialize the form and its components
        }

        DataTable DTUsersData; // DataTable to store user data fetched from the database

        // Refreshes the data displayed in the DataGridView by fetching user data from the database
        private void _RefreshDataTodvg()
        {
            DTUsersData = clsUsers.GettAllUsers(); // Load all users data from the database
            dgvUsers.DataSource = DTUsersData; // Set the DataTable as the DataGridView data source
            cbFilterUsers.SelectedIndex = 0; // Reset filter ComboBox to the default selection
            dgvUsers.ContextMenuStrip = contextMenuStrip1; // Assign context menu strip to DataGridView

            lblRecords.Text = dgvUsers.RowCount.ToString(); // Update label to show the total number of records
        }

        // Applies a filter to the DataGridView based on the selected column and search text
        private void _ApplyFilter(string filterBy, object key)
        {
            DataView view = DTUsersData.DefaultView; // Create a DataView for filtering

            if (int.TryParse(key.ToString(), out int numericKey)) // Check if the filter value is numeric
            {
                view.RowFilter = $"{filterBy} = {key}"; // Apply exact match filter for numeric values
            }
            else
            {
                view.RowFilter = $"{filterBy} LIKE '%{key}%'"; // Apply partial match filter for text values
            }
        }

        // Event handler for DataGridView cell click event (currently unused)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for future implementation when a cell is clicked
        }

        // Form Load event to initialize data and display it in DataGridView
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshDataTodvg(); // Load and display all user data when the form is loaded
        }

        // Event handler for filter ComboBox selection change
        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterUsers.SelectedIndex == 4) // Check if a specific filter option is selected
            {
                txtSearch.Visible = false; // Hide the search text box
                cbIsActive.Visible = true; // Show the activity status ComboBox
            }

            if (!string.IsNullOrEmpty(cbFilterUsers.Text) && !string.IsNullOrEmpty(txtSearch.Text)) // Check if inputs are valid
            {
                _ApplyFilter(cbFilterUsers.Text, txtSearch.Text); // Apply the filter based on user inputs
            }
        }

        // Event handler for search text box text change
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text)) // Check if the search text is empty
            {
                cbFilterUsers.Enabled = true; // Enable the filter ComboBox
            }
            else
            {
                cbFilterUsers.Enabled = false; // Disable the filter ComboBox to prevent conflicts
            }

            if (!string.IsNullOrEmpty(cbFilterUsers.Text) && !string.IsNullOrEmpty(txtSearch.Text)) // Check if inputs are valid
            {
                _ApplyFilter(cbFilterUsers.Text, txtSearch.Text); // Apply the filter dynamically
            }
        }

        // Button click event to open the form for adding a new user
        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser(-1); // Open the add user form with default ID
            frm.ShowDialog(); // Show the form as a dialog
            _RefreshDataTodvg();
        }

        // Event handler for key press in the search text box
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterUsers.SelectedIndex == 1) // If filtering by a text column
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)) // Allow only letters
                {
                    e.Handled = true; // Block non-letter input
                }
            }
            else if (cbFilterUsers.SelectedIndex == 2 || cbFilterUsers.SelectedIndex == 3 || cbFilterUsers.SelectedIndex == 4) // If filtering by a numeric column
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) // Allow only numbers
                {
                    e.Handled = true; // Block non-numeric input
                }
            }
            else
            {
                e.Handled = false; // Allow all characters for other cases
            }
        }

        // Event handler for the activity filter ComboBox selection change
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView view = DTUsersData.DefaultView; // Create a DataView for filtering
            string selectedValue = cbIsActive.SelectedItem.ToString(); // Get the selected activity filter

            if (selectedValue == "All") // Show all users
            {
                view.RowFilter = ""; // Clear the filter
            }
            else if (selectedValue == "Yes") // Show only active users
            {
                view.RowFilter = "IsActive = 1";
            }
            else if (selectedValue == "No") // Show only inactive users
            {
                view.RowFilter = "IsActive = 0";
            }

            dgvUsers.DataSource = view; // Update the DataGridView with the filtered data
        }

        // Event handler for the "Edit" context menu item
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser((int)dgvUsers.CurrentRow.Cells[1].Value); // Open edit form with selected user ID
            frm.Show(); // Show the form
        }

        // Event handler for the "Add New User" context menu item
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPerson frm = new AddEditPerson(-1); // Open the add person form with default ID
            frm.Show(); // Show the form
            _RefreshDataTodvg(); // Refresh the DataGridView after adding a user
        }

        // Event handler for the "Change Password" context menu item
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value); // Open change password form
            frm.Show(); // Show the form
        }

        // Event handler for the "Show Details" context menu item
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Here
            frmUserDetails frm = new frmUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value); // Open user details form
            frm.Show(); // Show the form
        }

        // Event handler for the "Delete" context menu item
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value; // Get the selected user's ID

            DialogResult result = MessageBox.Show( // Show confirmation dialog
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes) // If user confirms deletion


                if (result == DialogResult.Yes)
                {
                    bool isDeleted = clsUsers.DeleteUser(UserID); // Attempt to delete the person
                    if (isDeleted)
                    {
                        _RefreshDataTodvg(); // Refresh data if the person was deleted
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
    }


}