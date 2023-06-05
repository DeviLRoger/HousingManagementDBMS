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
    public partial class Tenant_details : Form
    {
        public Tenant_details()
        {
            InitializeComponent();
            Tenant_detail();
        }

        private void Tenant_detail()
        {
            // updated apartmentDB to apartment1DB and its working
            //Data Source = DEVILROGER; Initial Catalog = apartment1DB; Integrated Security = True
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True"); conn.Open();

            // Create a SqlCommand object and set its CommandText property to the SQL query
            SqlCommand cmd = new SqlCommand("select tenant.*, rental.apartment_no, apartment.building_name" +
                " from tenant join rental on rental.tenant_id=tenant.userName join apartment on apartment.Apartment_no = rental.apartment_no", conn);

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

        private void Tenant_details_Load(object sender, EventArgs e)
        {

        }
    }
}
