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
    public partial class Food : Form
    {
        private HashSet<int> modifiedRowsVM = new HashSet<int>();
        private HashSet<int> modifiedRowsD = new HashSet<int>();
        private HashSet<int> modifiedRowsF = new HashSet<int>();
       
        public Food()
        {
            InitializeComponent();
            LoadVendingMachineData();
            LoadDealerData();
            LoadFoodData();
            dgvVendingMachine.CellEndEdit += dgvVendingMachine_CellEndEdit;
            dgvDealer.CellEndEdit += dgvDealer_CellEndEdit;
            dgvFood.CellEndEdit += dgvFood_CellEndEdit;
        
        }
        private void LoadVendingMachineData()
        {
            try
            {
                string query_displayVendingMachine = "SELECT * FROM backend_vendingmachine";
                DataTable vendingmachineTable = DBManager.ExecuteQueryWithParameters(query_displayVendingMachine);
                dgvVendingMachine.DataSource = vendingmachineTable;

                string query_displayCourtSection = "SELECT courtSectionId, sectionName FROM backend_courtsection";
                DataTable courtsectionTable = DBManager.ExecuteQueryWithParameters(query_displayCourtSection);

                comboBoxCourtSectionId.Items.Clear();
                comboBoxCourtSectionId.Items.Add("");

                foreach (DataRow row in courtsectionTable.Rows)
                {
                    string sectionName = row["sectionName"].ToString();

                    int courtSectionId = Convert.ToInt32(row["courtSectionId"]);
                    comboBoxCourtSectionId.Items.Add(new CourtSectionItem(sectionName, courtSectionId));
                }}
            catch (Exception ex)
            {
                MessageBox.Show("Error loading vending machine data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
       
        }
        private void dgvVendingMachine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRowsVM.Add(e.RowIndex);
            }
        }

        private void btnAddVendingMachine_Click(object sender, EventArgs e)
        {
            CourtSectionItem selectedCourtSection = comboBoxCourtSectionId.SelectedItem as CourtSectionItem;
            if (selectedCourtSection == null)
            {
                MessageBox.Show("Invalid selection for court section.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {

                int courtSectionId = selectedCourtSection.Id;
                //MessageBox.Show("CourtSection " + courtSectionId);
                string query_addVendingMachine= "INSERT INTO backend_vendingmachine (courtSectionId_id) " +
                    "VALUES (@CourtSectionId_id)";
                MySqlParameter[] parameters =
                {
                        new MySqlParameter("@CourtSectionId_id",courtSectionId)

                    };
                int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_addVendingMachine, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Vending Machine added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetVendingMachineInput();
                    LoadVendingMachineData();
                    LoadFoodData();
                }
                else
                {
                    MessageBox.Show("Failed to add vending machine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error adding vending machine: " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdateVendingMachine_Click(object sender, EventArgs e)
        {
            try
            {
                bool anyChanges = false;


                foreach (int rowIndex in modifiedRowsVM)
                {
                    DataGridViewRow rowVM = dgvVendingMachine.Rows[rowIndex];
                    
                    // Check if the row is dirty (i.e., has been edited)
                    if (!rowVM.IsNewRow && rowVM.Cells["courtSectionId_id"].Value != null)
                    {

                        // Get the vendingMachine ID
                        int vendingMachineId = Convert.ToInt32(rowVM.Cells["vendingMachineId"].Value);

                        // Get the updated values
                        int courtSectionId_id = Convert.ToInt32(rowVM.Cells["courtSectionId_id"].Value);

                        // Construct the update query
                        string query_updateVendingMachine = "UPDATE backend_vendingmachine SET courtSectionId_id = @CourtSectionId_id WHERE vendingMachineId = @VendingMachineId";

                        // Define parameters
                        MySqlParameter[] parameters =
                        {
                            new MySqlParameter("@CourtSectionId_id", courtSectionId_id),
                            new MySqlParameter("@VendingMachineId",vendingMachineId)
                        };

                        // Execute the update query
                        int rowsAffectedVM = DBManager.ExecuteNonQueryWithParameters(query_updateVendingMachine, parameters);

                        if (rowsAffectedVM > 0)
                        {
                            anyChanges = true;


                        }
                        else
                        {
                            MessageBox.Show("Failed to update vending machine information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                if (anyChanges)
                {
                    MessageBox.Show("Vending machine information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                modifiedRowsVM.Clear();
                // Refresh the vendingMachine's DataGridView after updating
                LoadVendingMachineData();
                LoadFoodData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating vending machine information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteVendingMachine_Click(object sender, EventArgs e)
        {
            if (dgvVendingMachine.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRowV = dgvVendingMachine.SelectedRows[0];

                int vendingMachineId = Convert.ToInt32(selectedRowV.Cells["vendingMachineId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this vending machine ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query_deleteVendingMachine = "DELETE FROM backend_vendingmachine WHERE vendingMachineId=@VendingMachineId";

                        MySqlParameter parameterVendingMachineId = new MySqlParameter("@VendingMachineId", vendingMachineId);

                        int rowsAffectedV = DBManager.ExecuteNonQueryWithParameters(query_deleteVendingMachine, parameterVendingMachineId);

                        if (rowsAffectedV > 0)
                        {
                            MessageBox.Show("Vending machine deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadVendingMachineData();
                            LoadFoodData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete vending machine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting vending machine: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a vending machine to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetVendingMachineInput()
        {
            comboBoxCourtSectionId.SelectedIndex = -1;

        }
        private void btnResetVendingMachine_Click(object sender, EventArgs e)
        {
            ResetVendingMachineInput();
        }


        private void LoadDealerData()
        {
            try
            {
                string query_displayDealer = "SELECT * FROM backend_dealer";
                DataTable dealerTable = DBManager.ExecuteQueryWithParameters(query_displayDealer);
                dgvDealer.DataSource = dealerTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dealer data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dgvDealer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRowsD.Add(e.RowIndex);
            }
        }

        private void btnAddDealer_Click(object sender, EventArgs e)
        {

            if (txtDealerName.Text == "" || txtAddress.Text == "" || txtContactInfo.Text==""||txtMarginOfProfit.Text=="")
            {
                MessageBox.Show("Missing Information");
                return;
            }


            try
            {
                string query_addDealer = "INSERT INTO backend_dealer (name,address,contact_info,marginOfProfit) " +
                    "VALUES (@Name,@Address,@Contact_info,@MarginOfProfit)";
                MySqlParameter[] parameters =
                {
                        new MySqlParameter("@Name",txtDealerName.Text),
                        new MySqlParameter("@Address",txtAddress.Text),
                        new MySqlParameter("@Contact_info",txtContactInfo.Text),
                        new MySqlParameter("@MarginOfProfit",txtMarginOfProfit.Text)

                    };
                int rowsAffectedD = DBManager.ExecuteNonQueryWithParameters(query_addDealer, parameters);
                if (rowsAffectedD > 0)
                {
                    MessageBox.Show("Dealer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetDealerInput();
                    LoadDealerData();
                    LoadFoodData();
                }
                else
                {
                    MessageBox.Show("Failed to add dealer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error adding dealer: " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateDealer_Click(object sender, EventArgs e)
        {
            try
            {
                bool anyChanges = false;


                foreach (int rowIndex in modifiedRowsD)
                {
                    DataGridViewRow rowD = dgvDealer.Rows[rowIndex];
                    
                    // Check if the row is dirty (i.e., has been edited)
                    if (!rowD.IsNewRow && rowD.Cells["name"].Value != null && rowD.Cells["address"].Value != null &&
                    rowD.Cells["contact_info"].Value != null && rowD.Cells["marginOfProfit"].Value!=null)
                    {

                        // Get the dealer ID
                        int dealerId = Convert.ToInt32(rowD.Cells["dealer_id"].Value);

                        // Get the updated values
                        string name = rowD.Cells["name"].Value.ToString();
                        string address = rowD.Cells["address"].Value.ToString();
                        string contact_info = rowD.Cells["contact_info"].Value.ToString();
                        string marginOfProfit = rowD.Cells["marginOfProfit"].Value.ToString();


                        // Construct the update query
                        string query_updateDealer = "UPDATE backend_dealer SET name = @Name, address = @Address, contact_info = @Contact_info, marginOfProfit = @MarginOfProfit WHERE dealer_id = @Dealer_id";

                        // Define parameters
                        MySqlParameter[] parameters =
                        {
                            new MySqlParameter("@Name", name),
                            new MySqlParameter("@Address", address),
                            new MySqlParameter("@Contact_info", contact_info),
                            new MySqlParameter("@MarginOfProfit",marginOfProfit),
                            new MySqlParameter("Dealer_id",dealerId)
                        };

                        // Execute the update query
                        int rowsAffectedD = DBManager.ExecuteNonQueryWithParameters(query_updateDealer, parameters);

                        if (rowsAffectedD > 0)
                        {
                            anyChanges = true;


                        }
                        else
                        {
                            MessageBox.Show("Failed to update dealer information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                if (anyChanges)
                {
                    MessageBox.Show("Dealer information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                modifiedRowsD.Clear();
                // Refresh the dealer's DataGridView after updating
                LoadDealerData();
                LoadFoodData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating dealer information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteDealer_Click(object sender, EventArgs e)
        {
            if (dgvDealer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRowD = dgvDealer.SelectedRows[0];

                int dealerId = Convert.ToInt32(selectedRowD.Cells["dealer_id"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this dealer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query_deleteDealer = "DELETE FROM backend_dealer WHERE dealer_id=@Dealer_id";

                        MySqlParameter parameterDealerId = new MySqlParameter("@Dealer_id", dealerId);

                        int rowsAffectedD = DBManager.ExecuteNonQueryWithParameters(query_deleteDealer, parameterDealerId);

                        if (rowsAffectedD > 0)
                        {
                            MessageBox.Show("Dealer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDealerData();
                            LoadFoodData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete dealer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting dealer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a dealer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetDealerInput()
        {
            txtDealerName.Text = "";
            txtAddress.Text = "";
            txtContactInfo.Text = "";
            txtMarginOfProfit.Text = "";

        }
        private void btnResetDealer_Click(object sender, EventArgs e)
        {
            ResetDealerInput();
        }

        private void LoadFoodData()
        {
            try
            {
                string query_displayFood = "SELECT * FROM backend_food";
                DataTable foodTable = DBManager.ExecuteQueryWithParameters(query_displayFood);
                dgvFood.DataSource = foodTable;
                // vendingmachine combobox
                string query_displayVendingMachine = "SELECT vendingMachineId FROM backend_vendingmachine";
                DataTable vendingMachineTable = DBManager.ExecuteQueryWithParameters(query_displayVendingMachine);

                comboBoxVendingMachineId.Items.Clear();
                comboBoxVendingMachineId.Items.Add("");


                foreach (DataRow row in vendingMachineTable.Rows)
                {

                    int vendingMachineId = Convert.ToInt32(row["vendingMachineId"]);
                    comboBoxVendingMachineId.Items.Add(new VendingMachineItem(vendingMachineId));
                }

                // dealer combobox
                string query_displayDealer = "SELECT dealer_id, name FROM backend_dealer";
                DataTable dealerTable = DBManager.ExecuteQueryWithParameters(query_displayDealer);

                comboBoxDealerId.Items.Clear();
                comboBoxDealerId.Items.Add("");


                foreach (DataRow row in dealerTable.Rows)
                {
                    string dealerName = row["name"].ToString();

                    int dealerId = Convert.ToInt32(row["dealer_id"]);
                    comboBoxDealerId.Items.Add(new DealerItem(dealerName,dealerId));
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error loading food data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dgvFood_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRowsF.Add(e.RowIndex);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            DealerItem selectedDealer = comboBoxDealerId.SelectedItem as DealerItem;
            if (selectedDealer == null)
            {
                MessageBox.Show("Invalid selection for dealer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VendingMachineItem selectedVendingMachine = comboBoxVendingMachineId.SelectedItem as VendingMachineItem;
            if (selectedVendingMachine == null)
            {
                MessageBox.Show("Invalid selection for vending machine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtFoodName.Text== "" || txtDescription.Text == "" || txtUnitPrice.Text==""||txtQuantity.Text==""||txtMaxQuantity.Text=="")
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {

                int dealerId = selectedDealer.Id;
                int vendingMachineId = selectedVendingMachine.Id;
                //MessageBox.Show("Dealer " + dealerId);
                //MessageBox.Show("Vending machine " + vendingMachineId);
                string query_addFood = "INSERT INTO backend_food (name, description, unitPrice, quantity, Maxquantity, dealer_id_id, vendingMachineId_id) " +
                    "VALUES (@Name, @Description, @UnitPrice, @Quantity, @Maxquantity, @Dealer_id_id, @VendingMachineId_id)";
                MySqlParameter[] parameters =
                {
                        new MySqlParameter("@Name",txtFoodName.Text),
                        new MySqlParameter("@Description",txtDescription.Text),
                        new MySqlParameter("@UnitPrice",txtUnitPrice.Text),
                        new MySqlParameter("@Quantity",txtQuantity.Text),
                        new MySqlParameter("@Maxquantity",txtMaxQuantity.Text),
                        new MySqlParameter("@Dealer_id_id",dealerId),
                        new MySqlParameter("@VendingMachineId_id",vendingMachineId)

                    };
                int rowsAffectedF = DBManager.ExecuteNonQueryWithParameters(query_addFood, parameters);
                if (rowsAffectedF > 0)
                {
                    MessageBox.Show("Food item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFoodInput();
                    LoadFoodData();
                }
                else
                {
                    MessageBox.Show("Failed to add food item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error adding food item: " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {

            try
            {
                bool anyChanges = false;


                foreach (int rowIndex in modifiedRowsF)
                {
                    DataGridViewRow rowF = dgvFood.Rows[rowIndex];
                    
                    // Check if the row is dirty (i.e., has been edited)
                    if (!rowF.IsNewRow && rowF.Cells["name"].Value != null && rowF.Cells["description"].Value != null &&
                    rowF.Cells["unitPrice"].Value != null && rowF.Cells["quantity"].Value!=null && rowF.Cells["Maxquantity"].Value!=null 
                    && rowF.Cells["dealer_id_id"].Value!=null && rowF.Cells["vendingMachineId_id"].Value!=null)
                    {

                        // Get the food ID
                        int foodId = Convert.ToInt32(rowF.Cells["foodId"].Value);

                        // Get the updated values
                        string name = rowF.Cells["name"].Value.ToString();
                        string description = rowF.Cells["description"].Value.ToString();
                        string unitPrice = rowF.Cells["unitPrice"].Value.ToString();
                        string quantity = rowF.Cells["quantity"].Value.ToString();
                        string Maxquantity = rowF.Cells["Maxquantity"].Value.ToString();
                        
                        int dealer_id_id = Convert.ToInt32(rowF.Cells["dealer_id_id"].Value);
                        int vendingMachineId_id = Convert.ToInt32(rowF.Cells["vendingMachineId_id"].Value);


                        // Construct the update query
                        string query_updateFood = "UPDATE backend_food SET name = @Name, description = @Description, unitPrice = @UnitPrice, " +
                            "quantity=@Quantity, Maxquantity=@Maxquantity, dealer_id_id=@Dealer_id_id, vendingMachineId_id=@VendingMachineId_id WHERE foodId = @FoodId";

                        // Define parameters
                        MySqlParameter[] parameters =
                        {
                            new MySqlParameter("@Name", name),
                            new MySqlParameter("@Description", description),
                            new MySqlParameter("@UnitPrice", unitPrice),
                            new MySqlParameter("@quantity",quantity),
                            new MySqlParameter("@Maxquantity",Maxquantity),
                            new MySqlParameter("@Dealer_id_id",dealer_id_id),
                            new MySqlParameter("@VendingMachineId_id",vendingMachineId_id),
                            new MySqlParameter("@FoodId",foodId)
                        };

                        // Execute the update query
                        int rowsAffectedF = DBManager.ExecuteNonQueryWithParameters(query_updateFood, parameters);

                        if (rowsAffectedF > 0)
                        {
                            anyChanges = true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update food item information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                if (anyChanges)
                {
                    MessageBox.Show("Food item information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                modifiedRowsF.Clear();
                // Refresh the food's DataGridView after updating
                LoadFoodData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating food item information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRowF = dgvFood.SelectedRows[0];

                int foodId = Convert.ToInt32(selectedRowF.Cells["foodId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this food item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query_deleteFood = "DELETE FROM backend_food WHERE foodId=@FoodId";

                        MySqlParameter parameterFoodId = new MySqlParameter("@FoodId", foodId);

                        int rowsAffectedF = DBManager.ExecuteNonQueryWithParameters(query_deleteFood, parameterFoodId);

                        if (rowsAffectedF > 0)
                        {
                            MessageBox.Show("Food item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadFoodData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete food item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting food item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a food item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetFoodInput()
        {
            txtFoodName.Text = "";
            txtDescription.Text = "";
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtMaxQuantity.Text = "";
            comboBoxDealerId.SelectedIndex = -1;
            comboBoxVendingMachineId.SelectedIndex = -1;

        }
        private void btnResetFood_Click(object sender, EventArgs e)
        {
            ResetFoodInput();
        }

        private void btnCheckCS_Click(object sender, EventArgs e)
        {
            this.Hide();
            Court CheckCS = new Court();
            CheckCS.Show();
        }

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Options option = new Options();
            option.Show();
        }
    }
}
