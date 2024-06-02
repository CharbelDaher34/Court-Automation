using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Auto_Court
{
    public partial class Inventory : Form
    {
        private HashSet<int> modifiedRows = new HashSet<int>();
        public Inventory()
        {
            InitializeComponent();
            LoadInventoryData();
            dgvInventory.CellEndEdit += dgvInventory_CellEndEdit;
        }
        private void LoadInventoryData()
        {
            try
            {
                string query_displayInventory = "SELECT * FROM backend_inventorysports";
                DataTable inventoryTable = DBManager.ExecuteQueryWithParameters(query_displayInventory);
                dgvInventory.DataSource = inventoryTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dgvInventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRows.Add(e.RowIndex);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (txtItemName.Text == "" || txtUnitPriceHour.Text == "" || txtQuantity.Text == "" || txtTypeChoices.Text == "" )
            {
                MessageBox.Show("Missing Information");
                return;
            }
            else
            {
                try
                { 
                    string query_addInventory = "INSERT INTO backend_inventorysports (itemName, unitPrice_hour, quantity, typeChoices)" +
                        "VALUES(@ItemName,@UnitPrice_hour,@Quantity,@TypeChoices)";
                    MySqlParameter[] parameters =
                    {
                        new MySqlParameter("@itemName",txtItemName.Text),
                        new MySqlParameter("@unitPrice_hour",txtUnitPriceHour.Text),
                        new MySqlParameter("@Quantity",txtQuantity.Text),
                        new MySqlParameter("@TypeChoices",txtTypeChoices.Text)
                      
                    };
                    int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_addInventory, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Inventory added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetInventoryInput();
                        LoadInventoryData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error adding client: " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInventoryInput();
            
        }
        private void ResetInventoryInput()
        {
            txtItemName.Text = "";
            txtUnitPriceHour.Text = "";
            txtQuantity.Text = "";
            txtTypeChoices.Text = "";
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool anychanges = false;
                foreach (int rowIndex in modifiedRows)
                {
                    DataGridViewRow row = dgvInventory.Rows[rowIndex];
                    // Check if the row is dirty (i.e., has been edited)
                    if (!row.IsNewRow && row.Cells["itemName"].Value != null && row.Cells["unitPrice_hour"].Value != null && row.Cells["quantity"].Value != null &&
                    row.Cells["typeChoices"].Value != null )
                    {

                        // Get the inventory ID
                        int inventoryId = Convert.ToInt32(row.Cells["inventoryId"].Value);

                        // Get the updated values
                        string itemName = row.Cells["itemName"].Value.ToString();
                        string unitPrice_hour = row.Cells["unitPrice_hour"].Value.ToString();
                        string quantity = row.Cells["quantity"].Value.ToString();
                        string typeChoices = row.Cells["typeChoices"].Value.ToString();

                        // Construct the update query
                        string query_updateInventory = "UPDATE backend_inventorysports SET itemName=@ItemName,unitPrice_hour = @UnitPrice_hour, quantity=@Quantity, typeChoices = @TypeChoices WHERE inventoryId = @InventoryId";

                        // Define parameters
                        MySqlParameter[] parameters =
                        {
                            new MySqlParameter("@ItemName",itemName),
                            new MySqlParameter("@UnitPrice_hour", unitPrice_hour),
                            new MySqlParameter("@Quantity", quantity),
                            new MySqlParameter("@TypeChoices", typeChoices),
                            new MySqlParameter("@InventoryId",inventoryId)
                            
                        };

                        // Execute the update query
                        int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_updateInventory, parameters);

                        if (rowsAffected > 0)
                        {
                            anychanges = true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update inventory information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (anychanges)
                {
                    MessageBox.Show("Inventory information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                modifiedRows.Clear();
                // Refresh the inventory's DataGridView after updating
                LoadInventoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvInventory.SelectedRows[0];

                int inventoryId = Convert.ToInt32(selectedRow.Cells["inventoryId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this inventory?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query_deleteInventory = "DELETE FROM backend_inventorysports WHERE inventoryId=@InventoryId";

                        MySqlParameter parameterInventoryId = new MySqlParameter("@InventoryId", inventoryId);

                        int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_deleteInventory, parameterInventoryId);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inventory deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInventoryData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting inventory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an inventory to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Options option = new Options();
            option.Show();
        }

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
