using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Auto_Court
{
    public partial class Review : Form
    {
        public Review()
        {
            InitializeComponent();
            LoadReviewData();
        }
        private void LoadReviewData()
        {
            try
            {
                string query_displayReview = "SELECT * FROM backend_review";
                DataTable reviewsTable = DBManager.ExecuteQueryWithParameters(query_displayReview);
                dgvReview.DataSource = reviewsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading review data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
