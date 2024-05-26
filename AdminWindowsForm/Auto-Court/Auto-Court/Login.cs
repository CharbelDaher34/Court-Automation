using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto_Court
{
    public partial class Login : Form
    {
        //public string MyConString = "Server=;Database=;Trusted_connection=;";
  
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string uname = txtUsername.Text;
            string password = txtPassword.Text;
            //MySqlConnection connection = new MySqlConnection(MyConString);
            //MySqlCommand cmd = new MySqlCommand("Select * from backend_admin where username=@Username and password=@Password", connection);
            //cmd.Parameters.AddWithValue("@Username", uname);
            //cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //connection.Open();
            //int i = cmd.ExecuteNonQuery();
            //connection.Close();
            //if(dt.Rows.Count>0)
            //{
            //    MessageBox.Show("Successfully logged in");
            //    //after successful it will redirect to next page.
            //    this.Hide();

            //}
            //else
            //{
            //    MessageBox.Show("Please enter Correct Username and Password");
            //}

            bool isAuthenticated = AuthenticateAdmin(uname, password);
            if(isAuthenticated)
            {
                AdminSession.Login(uname);
                MessageBox.Show("Successfully logged in");
                this.Hide();
                Options option = new Options();
                option.Show();
                //form x = new form();
                //x.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
            //string query = "SELECT * FROM backend_admin WHERE username=@Username AND password=@Password";
            //DataTable dt = DBManager.ExecuteQueryWithParameters(query, new MySqlParameter("@Username", uname), new MySqlParameter("@Password", password));
            //if(dt.Rows.Count>0)
            //{
            //    MessageBox.Show("Successfully logged in");
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Incorrect username or password");
            //}
        }
        private bool AuthenticateAdmin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM backend_admin WHERE username=@Username AND password=@Password";
            Console.WriteLine("Executing query: " + query);

            DataTable dt = DBManager.ExecuteQueryWithParameters(query, new MySqlParameter("@Username", username), new MySqlParameter("@Password", password));
            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            return false;
        }

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
