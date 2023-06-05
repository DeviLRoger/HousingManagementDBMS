using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        // All buttons are working fine
        public Login()
        {
            MessageBox.Show("Welcome to Aashray 🏠!", " WELCOME ");
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user="";

            try
            {
                user = comboBox1.SelectedItem.ToString();
            }
            catch 
            {
                textBox3.Text = "Invalid user choice.";
            }
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            int result;

            // updated apartmentDB to apartment1DB and its working

            string connectionString = "Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = null;
                command = new SqlCommand("SELECT COUNT(*) FROM Signin WHERE username = @Username AND pass = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                result = (int)command.ExecuteScalar();
                int result2 = 0;
                if (result > 0 || user=="Admin")
                {
                    if (user == "Admin")
                    {
                        if (username == "11111" && password=="Admin")
                        {
                            MessageBox.Show("Successfully Logged in.", "OK");
                            textBox3.Text = "Successfully Logged in.";
                            this.Hide();
                            Admin f2 = new Admin(username);
                            f2.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid user choice or username or password.", "WARNING !!");
                            textBox3.Text = "Invalid user choice or username or password.";
                        }
                            
                    }
                    else if (user == "Owner")
                    {
                        command = new SqlCommand("SELECT COUNT(*) FROM Owner_table WHERE userName = @Username", connection);
                        command.Parameters.AddWithValue("@Username", username);
                        result2= (int)command.ExecuteScalar();
                        if (result2 > 0)
                        {
                            MessageBox.Show("Successfully Logged in.", "OK");
                            textBox3.Text = "Successfully Logged in.";
                            this.Hide();
                            Owner f3 = new Owner(username);
                            f3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid user choice or username or password.", "WARNING !!");
                            textBox3.Text = "Invalid user choice or username or password.";
                        }
                            
                    }
                    else if (user == "Tenant")
                    {
                        command = new SqlCommand("SELECT COUNT(*) FROM Tenant WHERE userName = @Username", connection);
                        command.Parameters.AddWithValue("@Username", username);
                        result2 = (int)command.ExecuteScalar();
                        if (result2 > 0)
                        {
                            MessageBox.Show("Successfully Logged in.", "OK");
                            textBox3.Text = "Successfully Logged in.";
                            this.Hide();
                            Tenant f4 = new Tenant(username);
                            f4.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid user choice or username or password.", "WARNING !!");
                            textBox3.Text = "Invalid user choice or username or password.";
                        }
                    }
                    else if (user == "Employee")
                    {
                        command = new SqlCommand("SELECT COUNT(*) FROM Employee1 WHERE userName = @Username", connection);
                        command.Parameters.AddWithValue("@Username", username);
                        result2 = (int)command.ExecuteScalar();
                        if (result2 > 0)
                        {
                            MessageBox.Show("Successfully Logged in.", "OK");
                            textBox3.Text = "Successfully Logged in.";
                            this.Hide();
                            Employee f5 = new Employee(username);
                            f5.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("Invalid user choice or username or password.", "WARNING !!");
                            textBox3.Text = "Invalid user choice or username or password.";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "OK");
                    textBox3.Text = "Invalid username or password.";
                }

            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
