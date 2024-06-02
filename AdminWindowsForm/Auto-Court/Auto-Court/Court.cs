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
    public partial class Court : Form
    {
        private HashSet<int> modifiedRowsCS = new HashSet<int>();
        private HashSet<int> modifiedRowsC = new HashSet<int>();
        public Court()
        {
            InitializeComponent();
            LoadCourtData();
            LoadCourtSectionData();
            dgvCourt.CellEndEdit += dgvCourt_CellEndEdit;
            dgvCourtSection.CellEndEdit += dgvCourtSection_CellEndEdit;
        }
        private void LoadCourtData()
        {
            try
            {
                string query_displayCourt = "SELECT * FROM backend_court";
                DataTable courtsTable = DBManager.ExecuteQueryWithParameters(query_displayCourt);
                dgvCourt.DataSource = courtsTable;

                string query_displayAdmins = "SELECT adminId, username FROM backend_admin";
                DataTable adminsTable = DBManager.ExecuteQueryWithParameters(query_displayAdmins);

                comboBoxAdmin.Items.Clear();
                comboBoxAdmin.Items.Add("");

                foreach (DataRow row in adminsTable.Rows)
                {
                    string adminName = row["username"].ToString();

                    int adminId = Convert.ToInt32(row["adminId"]);
                    comboBoxAdmin.Items.Add(new AdminItem(adminName, adminId));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading court data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dgvCourtSection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRowsCS.Add(e.RowIndex);
            }
        }
        private void dgvCourt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRowsC.Add(e.RowIndex);
            }
        }
        private void LoadCourtSectionData()
        {
            try
            {
                string query_displayCourtSection = "SELECT * FROM backend_courtsection";
                DataTable courtsectionTable = DBManager.ExecuteQueryWithParameters(query_displayCourtSection);
                dgvCourtSection.DataSource = courtsectionTable;

                string query_displayCourts = "SELECT courtId, name FROM backend_court";
                DataTable courtsTable = DBManager.ExecuteQueryWithParameters(query_displayCourts);

                comboBoxCourtId.Items.Clear();
                comboBoxCourtId.Items.Add("");

                foreach (DataRow row in courtsTable.Rows)
                {
                    string courtName = row["name"].ToString();

                    int courtId = Convert.ToInt32(row["courtId"]);
                    comboBoxCourtId.Items.Add(new CourtItem(courtName, courtId));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courtsection data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddCourt_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" || txtLocation.Text == "" || comboBoxAdmin.SelectedItem == null)
            {
                MessageBox.Show("Missing Information");
                return;

            }
            AdminItem selectedAdmin = comboBoxAdmin.SelectedItem as AdminItem;
            if (selectedAdmin == null)
            {
                MessageBox.Show("Invalid selection for admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
                try
                {

                    int adminId = selectedAdmin.Id;
                    //MessageBox.Show("ADMIN " + adminId);
                    string query_addCourt = "INSERT INTO backend_court(name, location, adminId_id)" +
                        "VALUES(@Name,@Location,@AdminId_id)";
                    MySqlParameter[] parameters =
                    {
                        new MySqlParameter("@Name",txtName.Text),
                        new MySqlParameter("@Location",txtLocation.Text),
                        new MySqlParameter("@AdminId_id",adminId)

                    };
                    int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_addCourt, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Court added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCourtInput();
                        LoadCourtData();
                        LoadCourtSectionData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add court.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error adding court: " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
        
        private void ResetCourtInput()
        {
            txtName.Clear();
            //txtName.Text = "";
            txtLocation.Text = "";
            comboBoxAdmin.SelectedIndex = -1;
         
        }
        private void ResetCourtSectionInput()
        {
            txtPrice.Clear();
            comboBoxCourtId.SelectedIndex = -1;
            txtSectionName.Clear();
            txtSectionType.Clear();
            txtFansCapacity.Clear();
            // Assuming default time is current time or any specific time you want to reset to
            dtPCloseTime.Value = DateTime.Now.Date + new TimeSpan(0, 0, 0); // Resetting to the start of the day, adjust as needed
            dtPOpenTime.Value = DateTime.Now.Date + new TimeSpan(0, 0, 0); // Resetting to the start of the day, adjust as needed

        }

        private void btnAddCourtSection_Click(object sender, EventArgs e)
        {
            if (txtSectionName.Text == "" || txtSectionType.Text == ""||txtFansCapacity.Text==""||txtPrice.Text==""||comboBoxCourtId.SelectedItem==null)
            {
                MessageBox.Show("Missing Information");
                return;
            }
            CourtItem selectedCourt = comboBoxCourtId.SelectedItem as CourtItem;
            if (selectedCourt == null)
            {
                MessageBox.Show("Invalid selection for court.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

                try
                {

                    int courtId = selectedCourt.Id;
                    //MessageBox.Show("court " + courtId);
                    TimeSpan selectedOpenTime = dtPOpenTime.Value.TimeOfDay;
                    TimeSpan selectedCloseTime = dtPCloseTime.Value.TimeOfDay;
                    string query_addCourtSection = "INSERT INTO backend_courtsection(sectionName, sectionType, fansCapacity, courtId_id,closeTime,openTime,pricePerHour)" +
                        "VALUES(@SectionName,@SectionType,@FansCapacity,@CourtId_id,@CloseTime,@OpenTime,@PricePerHour)";
                    MySqlParameter[] parameters =
                    {
                        new MySqlParameter("@SectionName",txtSectionName.Text),
                        new MySqlParameter("@SectionType",txtSectionType.Text),
                        new MySqlParameter("@FansCapacity",txtFansCapacity.Text),
                        new MySqlParameter("@CourtId_id",courtId),
                        new MySqlParameter("@CloseTime",selectedCloseTime),
                        new MySqlParameter("@OpenTime",selectedOpenTime),
                        new MySqlParameter("@PricePerHour",txtPrice.Text)

                     };
                    int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_addCourtSection, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Court section added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCourtSectionInput();
                        LoadCourtSectionData();
                        LoadCourtData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add court section.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error adding court section: " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            
        }

        private void btnResetCourt_Click(object sender, EventArgs e)
        {
            ResetCourtInput();
        }

        private void btnDeleteCourtSection_Click(object sender, EventArgs e)
        {
            if (dgvCourtSection.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRowCS = dgvCourtSection.SelectedRows[0];

                int courtSectionId = Convert.ToInt32(selectedRowCS.Cells["courtSectionId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this court section?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query_deleteCourtSection = "DELETE FROM backend_courtsection WHERE courtSectionId=@CourtSectionId";

                        MySqlParameter parameterCourtSectionId = new MySqlParameter("@CourtSectionId", courtSectionId);

                        int rowsAffectedCS = DBManager.ExecuteNonQueryWithParameters(query_deleteCourtSection, parameterCourtSectionId);

                        if (rowsAffectedCS > 0)
                        {
                            MessageBox.Show("Court section deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCourtSectionData();
                            LoadCourtData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete court section.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting court section: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a court section to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetCourtSection_Click(object sender, EventArgs e)
        {
            ResetCourtSectionInput();
        }

        private void btnEditCourtSection_Click(object sender, EventArgs e)
        {
            try { 
                bool anychanges = false;
            
                
                foreach (int rowIndex in modifiedRowsCS)
                {
                    DataGridViewRow rowCS = dgvCourtSection.Rows[rowIndex];
                    // Check if the row has been edited
                    
                    // Check if the row is dirty (i.e., has been edited)
                    if (!rowCS.IsNewRow&&rowCS.Cells["sectionName"].Value != null && rowCS.Cells["sectionType"].Value != null &&
                    rowCS.Cells["fansCapacity"].Value != null && rowCS.Cells["courtId_id"].Value != null &&
                    rowCS.Cells["closeTime"].Value != null && rowCS.Cells["openTime"].Value != null &&
                    rowCS.Cells["pricePerHour"].Value != null)
                    {

                        // Get the courtSection ID
                        int courtSectionId = Convert.ToInt32(rowCS.Cells["courtSectionId"].Value);

                        // Get the updated values
                        string sectionName = rowCS.Cells["sectionName"].Value.ToString();
                        string sectionType = rowCS.Cells["sectionType"].Value.ToString();
                        string fansCapacity = rowCS.Cells["fansCapacity"].Value.ToString();
                        int courtId_id = Convert.ToInt32(rowCS.Cells["courtId_id"].Value);
                        TimeSpan selectedOpenTime = TimeSpan.Parse(rowCS.Cells["openTime"].Value.ToString());
                        TimeSpan selectedCloseTime = TimeSpan.Parse(rowCS.Cells["closeTime"].Value.ToString());
                        string pricePerHour = rowCS.Cells["pricePerHour"].Value.ToString();
                        

                        // Construct the update query
                        string query_updateCourtSection = "UPDATE backend_courtsection SET sectionName = @SectionName, sectionType = @SectionType, fansCapacity = @FansCapacity, courtId_id = @CourtId_id, closeTime = @CloseTime, openTime = @OpenTime, pricePerHour = @PricePerHour WHERE courtSectionId = @CourtSectionId";

                        // Define parameters
                        MySqlParameter[] parameters =
                        {
                            new MySqlParameter("@SectionName", sectionName),
                            new MySqlParameter("@SectionType", sectionType),
                            new MySqlParameter("@FansCapacity", fansCapacity),
                            new MySqlParameter("@CourtId_id", courtId_id),
                            new MySqlParameter("@CloseTime", selectedCloseTime),
                            new MySqlParameter("@OpenTime", selectedOpenTime),
                            new MySqlParameter("@PricePerHour", pricePerHour),
                            new MySqlParameter("@CourtSectionId",courtSectionId)
   
                            
                            
                        };

                        // Execute the update query
                        int rowsAffectedCS = DBManager.ExecuteNonQueryWithParameters(query_updateCourtSection, parameters);
                        
                        if (rowsAffectedCS > 0)
                        {
                            anychanges = true;
                           
                            
                        }
                        else
                        {
                            MessageBox.Show("Failed to update court section information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }
                    }
                }
                if (anychanges)
                {
                    MessageBox.Show("Court section information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                modifiedRowsCS.Clear();
                    // Refresh the DataGridView after updating
                    LoadCourtSectionData();
                    LoadCourtData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating court section information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCourt_Click(object sender, EventArgs e)
        {
            try
            {
                bool anyChanges = false;


                foreach (int rowIndex in modifiedRowsC)
                {
                    DataGridViewRow rowC = dgvCourt.Rows[rowIndex];
                  
                    // Check if the row is dirty (i.e., has been edited)
                    if (!rowC.IsNewRow && rowC.Cells["name"].Value != null && rowC.Cells["location"].Value != null &&
                    rowC.Cells["adminId_id"].Value != null )
                    {

                        // Get the court ID
                        int courtId = Convert.ToInt32(rowC.Cells["courtId"].Value);

                        // Get the updated values
                        string name = rowC.Cells["name"].Value.ToString();
                        string location = rowC.Cells["location"].Value.ToString();
                        int adminId_id = Convert.ToInt32(rowC.Cells["adminId_id"].Value);
                 
                        // Construct the update query
                        string query_updateCourt = "UPDATE backend_court SET name = @Name, location = @Location, adminId_id = @AdminId_id WHERE courtId = @CourtId";

                        // Define parameters
                        MySqlParameter[] parameters =
                        {
                            new MySqlParameter("@Name", name),
                            new MySqlParameter("@Location", location),
                            new MySqlParameter("@AdminId_id", adminId_id),
                            new MySqlParameter("@CourtId",courtId)



                        };

                        // Execute the update query
                        int rowsAffectedC = DBManager.ExecuteNonQueryWithParameters(query_updateCourt, parameters);

                        if (rowsAffectedC > 0)
                        {
                            anyChanges = true;


                        }
                        else
                        {
                            MessageBox.Show("Failed to update court information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                if (anyChanges)
                {
                    MessageBox.Show("Court information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                modifiedRowsC.Clear();
                // Refresh the Court's DataGridView after updating
                LoadCourtData();
                LoadCourtSectionData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating court information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCourt_Click(object sender, EventArgs e)
        {
            if (dgvCourt.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRowC = dgvCourt.SelectedRows[0];

                int courtId = Convert.ToInt32(selectedRowC.Cells["courtId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this court ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query_deleteCourt = "DELETE FROM backend_court WHERE courtId=@CourtId";

                        MySqlParameter parameterCourtId = new MySqlParameter("@CourtId", courtId);

                        int rowsAffectedC = DBManager.ExecuteNonQueryWithParameters(query_deleteCourt, parameterCourtId);

                        if (rowsAffectedC > 0)
                        {
                            MessageBox.Show("Court deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCourtData();
                            LoadCourtSectionData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete court.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting court: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a court to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToFood_Click(object sender, EventArgs e)
        {
            this.Hide();
            Food CheckFood = new Food();
            CheckFood.Show();
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
