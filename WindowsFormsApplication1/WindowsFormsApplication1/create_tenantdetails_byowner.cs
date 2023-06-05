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
    public partial class create_tenantdetails_byowner : Form
    {
        string oid = "";
        string tid = "";
        public create_tenantdetails_byowner(string ten_id, string own_id)
        {
            InitializeComponent();
            tid = ten_id;
            oid = own_id;
        }

        /*public void insertagreemtrental()
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=apartmentDB;Integrated Security=True");
            conn.Open();

            // Create a SqlCommand object and set its CommandText property to the SQL query
            SqlCommand cmd = new SqlCommand("GetApartmentDetailsofOwner", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pUserName", oid);




            // Create a SqlDataAdapter object and pass the SqlCommand object to its constructor
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create a DataTable object and call the SqlDataAdapter's Fill method
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Set the DataTable as the DataSource of the DataGrid
            dataGridView1.DataSource = dt;
        }*/

        private void create_tenantdetails_byowner_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t_name = textBox1.Text;
            string t_aadhar_id = textBox2.Text;
            string t_phoneno = textBox3.Text;
            string t_aptno = textBox4.Text;
            string t_monthlyrent = textBox5.Text;
            string t_dateofrent = textBox6.Text;
            string building_name = textBox7.Text;

            int aptno = int.Parse(t_aptno);
            int monthlyrent = int.Parse(t_monthlyrent);

            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();

            // Create a SqlCommand object and set its CommandText property to the SQL query
            SqlCommand cmd = new SqlCommand("InsertNewTenant", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", tid);
            cmd.Parameters.AddWithValue("@Tenant_Name", t_name);
            cmd.Parameters.AddWithValue("@aadhar_ID", t_aadhar_id);
            cmd.Parameters.AddWithValue("@Apartment_no", aptno);
            cmd.Parameters.AddWithValue("@Owner_id", oid);
            cmd.Parameters.AddWithValue("@Monthly_rent", monthlyrent);
            cmd.Parameters.AddWithValue("@Phone_no", t_phoneno);
            cmd.Parameters.AddWithValue("@building_name", building_name);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tenant and agreement has been created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !!\nTry Again");
            }
        }
    }
}
