using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class Employee : Form
    {
        string eid = "";
        public Employee(string username)
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();

            eid = username;

            string name = "";
            // Define the SQL query
            string sql = "SELECT Emp_Name FROM Employee1 WHERE userName = @username";

            // Create a new SqlCommand object with the query and connection
            SqlCommand command = new SqlCommand(sql, conn);

            // Add any parameters needed for the query
            command.Parameters.AddWithValue("@username", eid);

            // Execute the query and retrieve the result
            object result = command.ExecuteScalar();

            // Check if the result is not null and cast it to the appropriate data type
            if (result != null)
            {
                name = (string)result; // replace 'string' with appropriate data type do something with the column value
            }



            label11.Text = "";
            label11.Text = name;

            //label11.Text = "Welcome to Aashray 🏠 "+username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // complaints details ✅
            complain_details f9 = new complain_details();
            f9.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // All tenant details ✅
            Tenant_details f7 = new Tenant_details();
            f7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Creating a tenant id without allocated apartment ✅
            create_tenant f12 = new create_tenant();
            f12.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // All Apartment details ✅
            all_apartment_details f1 = new all_apartment_details();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Update complain status ✅
            resolve_complain f2 = new resolve_complain();
            f2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f19 = new Login();
            f19.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
