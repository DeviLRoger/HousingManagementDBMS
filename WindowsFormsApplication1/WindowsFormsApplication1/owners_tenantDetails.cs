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
    public partial class owners_tenantDetails : Form
    {
        string oid = "";
        public owners_tenantDetails(string ownerid)
        {
            InitializeComponent();
            oid= ownerid;
            filltable();
        }

        public void filltable()
        {
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();

            // Create a SqlCommand object and set its CommandText property to the SQL query
            SqlCommand cmd = new SqlCommand("getTenantByOwner", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ownerUsername", oid);
            // Create a SqlDataAdapter object and pass the SqlCommand object to its constructor
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create a DataTable object and call the SqlDataAdapter's Fill method
            DataTable dt = new DataTable();

            // could not find getTenantByOwner
            da.Fill(dt);

            // Set the DataTable as the DataSource of the DataGrid
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
