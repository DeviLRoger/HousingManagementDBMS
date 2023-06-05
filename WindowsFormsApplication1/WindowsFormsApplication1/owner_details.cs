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
    public partial class owner_details : Form
    {
        public owner_details()
        {
            InitializeComponent();
            owner_detail();
        }

        private void owner_detail( )
        {
            // updated apartmentDB to apartment1DB and its working
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True"); conn.Open();

            // Create a SqlCommand object and set its CommandText property to the SQL query
            SqlCommand cmd = new SqlCommand("SELECT o.Owner_Name, o.aadhar_ID, COUNT(*) as no_of_apartments FROM Owner_Table o JOIN apartment a ON o.apartment_no = a.Apartment_no AND o.building_name = a.Building_name GROUP BY o.Owner_Name, o.aadhar_ID", conn);

            // Create a SqlDataAdapter object and pass the SqlCommand object to its constructor
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create a DataTable object and call the SqlDataAdapter's Fill method
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Set the DataTable as the DataSource of the DataGrid
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
