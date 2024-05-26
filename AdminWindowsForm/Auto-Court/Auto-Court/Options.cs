using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Auto_Court
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (rdbClient.Checked)
            {
                this.Hide();

                Client addingClient  = new Client();
                addingClient.Show();

            }
            if (rdbCourt.Checked)
            {
                this.Hide();
                Court addingCourt = new Court();
                addingCourt.Show();
            }

            if (rdbInventory.Checked)
            {
                this.Hide();
                Inventory addingInventory = new Inventory();
                addingInventory.Show();
            }

            if (rdbReservation.Checked)
            {
                this.Hide();
                Reservation checkReservation = new Reservation();
                checkReservation.Show();
            }

            if (rdbFood.Checked)
            {
                this.Hide();
                Food addingFood = new Food();
                addingFood.Show();
            }

            if (rdbReview.Checked)
            {
                this.Hide();
                Review checkReview = new Review();
                checkReview.Show();
            }
        }

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
