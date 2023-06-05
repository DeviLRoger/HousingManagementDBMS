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
    public partial class Tenantmy_details : Form
    {
        string choice = "";
        string ten_id = "";
        public Tenantmy_details(string ch,string tid)
        {
            InitializeComponent();
            choice = ch;
            ten_id = tid;
            label1.Text = choice;
            initialised();
        }

        public void initialised()
        {
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();

            if (choice=="My Details")
            {
                label1.Text = label1.Text+" 👤";
                using (SqlCommand command = new SqlCommand("GetTenantDetails", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Set the parameter value
                    command.Parameters.AddWithValue("@Tenant_id", ten_id); // Replace 123 with the actual person ID

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
                }
            }
            else if (choice== "My Apartment details")
            {
                label1.Text = label1.Text + " 🏠";
                using (SqlCommand command = new SqlCommand("GetApartmentDetailsOfTenant", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Set the parameter value
                    command.Parameters.AddWithValue("@username", ten_id); // Replace 123 with the actual person ID

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
                }
            }
            else if(choice== "My Owner Details")
            {
                label1.Text = label1.Text + " 🤵‍♂️";
                using (SqlCommand command = new SqlCommand("GetOwnerDetailsOfTenant", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Set the parameter value
                    command.Parameters.AddWithValue("@username", ten_id); // Replace 123 with the actual person ID

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
                }
            }
            else
            {
                //label2.Text = "Error Occurred !!";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
