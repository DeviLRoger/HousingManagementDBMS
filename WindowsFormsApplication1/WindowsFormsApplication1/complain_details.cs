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
    public partial class complain_details : Form
    {
        public complain_details()
        {
            InitializeComponent();
            complain_detail();
        }

        private void complain_detail()
        {
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True"); conn.Open();

            // Create a SqlCommand object and set its CommandText property to the SQL query
            SqlCommand cmd = new SqlCommand("select * from complaint", conn);

            // Create a SqlDataAdapter object and pass the SqlCommand object to its constructor
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create a DataTable object and call the SqlDataAdapter's Fill method
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Set the DataTable as the DataSource of the DataGrid
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
