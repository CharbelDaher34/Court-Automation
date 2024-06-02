using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Auto_Court
{
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
            LoadReservationData();
            PopulateFilterOptions();
        }
        private void LoadReservationData()
        {
            try
            {
                string query_displayReservation = "SELECT * FROM backend_reservation";
                DataTable reservationsTable = DBManager.ExecuteQueryWithParameters(query_displayReservation);
                dgvReservation.DataSource = reservationsTable;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PopulateFilterOptions()
        {
            
            string query_clients = "SELECT DISTINCT CONCAT(c.firstName,' ',c.lastName) AS fullName FROM backend_client c JOIN backend_reservation r ON c.clientId=r.clientId_id";
            DataTable clientsTable = DBManager.ExecuteQueryWithParameters(query_clients);
            comboBoxClient.Items.Clear();

            comboBoxClient.Items.Add("");
            foreach(DataRow row_client in clientsTable.Rows)
            {
                    comboBoxClient.Items.Add(row_client["fullName"].ToString());
            }
                

            string query_dates = "SELECT DISTINCT DATE_FORMAT (date,'%Y-%m-%d') AS reservationDate FROM backend_reservation";
            DataTable datesTable = DBManager.ExecuteQueryWithParameters(query_dates);
            comboBoxDate.Items.Clear();

            comboBoxDate.Items.Add("");
            foreach(DataRow row_date in datesTable.Rows)
            {
                comboBoxDate.Items.Add(row_date["reservationDate"].ToString());
            }

            string query_times = "SELECT DISTINCT startTime FROM backend_reservation";
            DataTable timesTable = DBManager.ExecuteQueryWithParameters(query_times);
            comboBoxTime.Items.Clear();

            comboBoxTime.Items.Add("");
            foreach(DataRow row_time in timesTable.Rows)
            {
                comboBoxTime.Items.Add(row_time["startTime"].ToString());
            }

            string query_prices = "SELECT DISTINCT pricePerHour AS price FROM backend_courtsection c JOIN backend_reservation r ON c.courtSectionId=r.courtsectionID_id";
            DataTable pricesTable = DBManager.ExecuteQueryWithParameters(query_prices);
            comboBoxPrice.Items.Clear();

            comboBoxPrice.Items.Add("");
            foreach(DataRow row_price in pricesTable.Rows)
            {
                comboBoxPrice.Items.Add(row_price["price"].ToString());
            }
        }

        private void ResetFilterInput()
        {
            comboBoxClient.SelectedIndex = -1;
            comboBoxDate.SelectedIndex = -1;
            comboBoxTime.SelectedIndex = -1;
            comboBoxPrice.SelectedIndex = -1;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string clientFilter = comboBoxClient.SelectedItem?.ToString();
            //MessageBox.Show(clientFilter);
            string dateFilter = comboBoxDate.SelectedItem?.ToString();
            //MessageBox.Show(dateFilter);
            string timeFilter = comboBoxTime.SelectedItem?.ToString();
            //MessageBox.Show(timeFilter);
            string priceFilter = comboBoxPrice.SelectedItem?.ToString();
            //MessageBox.Show(priceFilter);

            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM backend_reservation r JOIN backend_client c ON r.clientId_id=c.clientId " +
                "JOIN backend_courtsection cs ON cs.courtsectionID=r.courtSectionId_id WHERE 1=1 ");
            if (string.IsNullOrEmpty(clientFilter) && string.IsNullOrEmpty(dateFilter) && string.IsNullOrEmpty(timeFilter) && string.IsNullOrEmpty(priceFilter))
            {
                MessageBox.Show("Select at least one filter");
                return;
            }
            if(!string.IsNullOrEmpty(clientFilter))
            {
                queryBuilder.Append($"AND CONCAT(c.firstName,' ',c.lastName)='{clientFilter}'");
            }

            if(!string.IsNullOrEmpty(dateFilter))
            {
                queryBuilder.Append($"AND r.date ='{dateFilter}'");
            }

            if(!string.IsNullOrEmpty(timeFilter))
            {
                queryBuilder.Append($"AND r.startTime='{timeFilter}'");
            }

            if(!string.IsNullOrEmpty(priceFilter))
            {
                queryBuilder.Append($"AND cs.pricePerHour='{priceFilter}'");
            }

            string query = queryBuilder.ToString();
            //MessageBox.Show(query);
            DataTable filteredData = DBManager.ExecuteQueryWithParameters(query);

            dgvReservation.DataSource = filteredData;
            ResetFilterInput();
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
