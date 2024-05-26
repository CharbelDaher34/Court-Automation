using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto_Court
{
    public partial class Client : Form
    {
        private HashSet<int> modifiedRows = new HashSet<int>();


        public Client()
        {
            InitializeComponent();
            LoadClientData();
            dgvClient.CellEndEdit += dgvClient_CellEndEdit;
        }
        private void LoadClientData()
        {
            try
            {
                string query_displayClient = "SELECT * FROM backend_client";
                DataTable clientsTable = DBManager.ExecuteQueryWithParameters(query_displayClient);
                dgvClient.DataSource = clientsTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading client data: " + ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void dgvClient_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRows.Add(e.RowIndex);
            }
        }

        

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtPhoneNumber.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtCountry.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                gender = rdbFemale.Checked ? "F" : "M";
                try
                {
                    DateTime dateOfBirth = dtpDateOfBirth.Value;
                    //DateTime dateOfBirth;
                    //if(!DateTime.TryParse(txtDateOfBirth.Text, out dateOfBirth))
                    //{
                    //    MessageBox.Show("Invalid Date of Birth", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}
                    string query_addClient = "INSERT INTO backend_client (password, firstName, lastName, email, number, address, country, date_of_birth, sex)" +
                        "VALUES(@Password,@FirstName,@LastName,@Email,@Number,@Address,@Country,@Date_of_birth,@Sex)";
                    MySqlParameter[] parameters =
                    {
                        new MySqlParameter("@Password",txtPassword.Text),
                        new MySqlParameter("@Email",txtEmail.Text),
                        new MySqlParameter("@FirstName",txtFirstName.Text),
                        new MySqlParameter("@LastName",txtLastName.Text),
                        new MySqlParameter("@Number",txtPhoneNumber.Text),
                        new MySqlParameter("@Address",txtAddress.Text),
                        new MySqlParameter("@Country",txtCountry.Text),
                        //new MySqlParameter("@Date_of_birth",txtDateOfBirth.Text),
                        new MySqlParameter("@Date_of_birth",dateOfBirth.Date),
                        new MySqlParameter("@Sex",gender),
                    };
                    int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_addClient, parameters);
                    if(rowsAffected>0)
                    {
                        MessageBox.Show("Client added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetClientInput();
                        LoadClientData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error adding client: "+Ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }
        private void ResetClientInput()
        {
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            rdbFemale.Checked = false;
            rdbMale.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetClientInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvClient.SelectedRows.Count>0)
            {
                DataGridViewRow selectedRow = dgvClient.SelectedRows[0];

                int clientId = Convert.ToInt32(selectedRow.Cells["clientId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result==DialogResult.Yes)
                {
                    try
                    {
                        string query_deleteClient = "DELETE FROM backend_client WHERE clientId=@ClientId";

                        MySqlParameter parameterClientId = new MySqlParameter("@ClientId", clientId);

                        int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_deleteClient, parameterClientId);

                        if(rowsAffected>0)
                        {
                            MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadClientData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error deleting client: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a client to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool anychanges = false;
                foreach (int rowIndex in modifiedRows)
                {
                    DataGridViewRow row = dgvClient.Rows[rowIndex];
                    // Check if the row is dirty (i.e., has been edited)
                    if (!row.IsNewRow && row.Cells["password"].Value != null && row.Cells["firstName"].Value != null && row.Cells["lastName"].Value != null &&
                    row.Cells["email"].Value != null && row.Cells["number"].Value != null &&
                    row.Cells["address"].Value != null && row.Cells["country"].Value != null &&
                    row.Cells["sex"].Value != null && row.Cells["date_of_birth"].Value != null)
                    {

                        // Get the client ID
                        int clientId = Convert.ToInt32(row.Cells["clientId"].Value);

                        // Get the updated values
                        string password = row.Cells["password"].Value.ToString();
                        string firstName = row.Cells["firstName"].Value.ToString();
                        string lastName = row.Cells["lastName"].Value.ToString();
                        string email = row.Cells["email"].Value.ToString();
                        string phoneNumber = row.Cells["number"].Value.ToString();
                        string address = row.Cells["address"].Value.ToString();
                        string location = row.Cells["country"].Value.ToString();
                        string sex = row.Cells["sex"].Value.ToString();
                        DateTime dateOfBirth = Convert.ToDateTime(row.Cells["date_of_birth"].Value);

                        // Construct the update query
                        string query_updateClient = "UPDATE backend_client SET password=@Password,firstName = @FirstName, lastName = @LastName, email = @Email, number = @Number, address = @Address, country = @Country, sex = @Sex, date_of_birth = @Date_of_birth WHERE clientId = @ClientId";

                        // Define parameters
                        MySqlParameter[] parameters =
                        {
                            new MySqlParameter("@Password",password),
                            new MySqlParameter("@FirstName", firstName),
                            new MySqlParameter("@LastName", lastName),
                            new MySqlParameter("@Email", email),
                            new MySqlParameter("@Number", phoneNumber),
                            new MySqlParameter("@Address", address),
                            new MySqlParameter("@Country", location),
                            new MySqlParameter("@Sex", sex),
                            new MySqlParameter("@Date_of_birth", dateOfBirth),
                            new MySqlParameter("@ClientId", clientId)
                        };

                        // Execute the update query
                        int rowsAffected = DBManager.ExecuteNonQueryWithParameters(query_updateClient, parameters);

                        if (rowsAffected > 0)
                        {
                            anychanges = true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update client information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (anychanges)
                {
                MessageBox.Show("Client information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                modifiedRows.Clear();
                // Refresh the DataGridView after updating
                LoadClientData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating client information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Options option = new Options();
            option.Show();
        }
    }
}
