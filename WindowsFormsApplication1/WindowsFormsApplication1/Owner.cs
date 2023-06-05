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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApplication1
{
    public partial class Owner : Form
    {
        string ownerid = "";
        public Owner(string username)
        {
            
            InitializeComponent();

            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();

            ownerid = username;

            string name = "";
            // Define the SQL query
            string sql = "SELECT Owner_Name FROM Owner_Table WHERE userName = @username";

            // Create a new SqlCommand object with the query and connection
            SqlCommand command = new SqlCommand(sql, conn);

            // Add any parameters needed for the query
            command.Parameters.AddWithValue("@username", ownerid);

            // Execute the query and retrieve the result
            object result=null;
            try
            {
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

            // Check if the result is not null and cast it to the appropriate data type
            if (result != null)
            {
                name = (string)result; // replace 'string' with appropriate data type do something with the column value
            }



            label1.Text = "";
            label1.Text = name;

            //label1.Text = username;
            //ownerid = username;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Show all the complaints 
            complain_details f9 = new complain_details();
            f9.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Owner's apartment details (my apartment details) 
            owner_roomDetails f10 = new owner_roomDetails(ownerid);
            f10.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Owner's tenant details (my tenant details) 
            // ERROR in getTenantByOwner
            owners_tenantDetails f11 = new owners_tenantDetails(ownerid);
            f11.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Creating tenant (very imp and lengthy)
            create_tenant_byonwer f99 = new create_tenant_byonwer(ownerid);
            f99.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f13 = new Login();
            f13.Show();
        }
    }
}
