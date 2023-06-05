using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Tenant : Form
    {
        string tid = "";
        string choice = "";
        public Tenant(string username)
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();

            tid = username;

            string name = "";
            // Define the SQL query
            string sql = "SELECT Tenant_Name FROM Tenant WHERE userName = @username";

            // Create a new SqlCommand object with the query and connection
            SqlCommand command = new SqlCommand(sql, conn);

            // Add any parameters needed for the query
            command.Parameters.AddWithValue("@username", tid);

            // Execute the query and retrieve the result
            object result = command.ExecuteScalar();

            // Check if the result is not null and cast it to the appropriate data type
            if (result != null)
            {
                name = (string)result; // replace 'string' with appropriate data type do something with the column value
            }



            label11.Text = "";
            label11.Text = name;
            /*SqlCommand command = new SqlCommand("select Tenant_Name from Tenant where userName = @username", conn);
            command.
            command.CommandType = CommandType.Text;

            IDataReader dr = command.ExecuteReader();
            dr.Read();
            label11.Text = label11.Text + dr.GetValue(0).ToString();

            /* SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=apartmentDB;Integrated Security=True");
            conn.Open();

            SqlCommand command = new SqlCommand("select Tenant_Name from Tenant where userName= username", conn);

            using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Get the schema table to retrieve column information
                        DataTable schemaTable = reader.GetSchemaTable();

                        // Read the data and display it in the label
                        label2.Text = "";

                        while (reader.Read())
                        {
                            // Loop through each column in the schema table
                            foreach (DataRow row in schemaTable.Rows)
                            {
                                string columnName = row["ColumnName"].ToString();
                                object columnValue = reader[columnName];

                                // Append the column name and value to the label
                                label2.Text += columnName + ": " + columnValue.ToString() + "\n";
                            }
                            label2.Text = label2.Text.TrimEnd(',', ' ') + "\n";
                        }
                    }
            */


            //label11.Text = "Welcome to Aashray 🏠 "+username;
            //tid = username;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Tenant's own detail
            choice = button1.Text;
            Tenantmy_details f1 = new Tenantmy_details(choice, tid);
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Tenant's alloted apartment's details
            choice = button2.Text;
            Tenantmy_details f2 = new Tenantmy_details(choice, tid);
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Tenant's alloted apartment's Owner details
            choice = button3.Text;
            Tenantmy_details f3 = new Tenantmy_details(choice,tid);
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //create complain
            create_complaint f4 = new create_complaint();
            f4.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f5 = new Login();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Show all the complaints
            complain_details f9 = new complain_details();
            f9.Show();
        }
    }
}
