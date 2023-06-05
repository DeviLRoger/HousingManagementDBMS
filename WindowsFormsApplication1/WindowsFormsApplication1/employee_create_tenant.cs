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
    public partial class employee_create_tenant : Form
    {
        string tid = "";
        public employee_create_tenant(string tid1)
        {
            InitializeComponent();
            tid= tid1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenantname = textBox1.Text.ToString();
            string tenantaadhar = textBox2.Text.ToString();
            string ownerphoneno = textBox3.Text.ToString();

            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();
            String query = "INSERT INTO Tenant(userName,Tenant_Name,aadhar_id,phone_no) VALUES (@userName,@ownerName,@aadhar,@phone_no)";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@userName", tid);
            command.Parameters.AddWithValue("@ownerName", tenantname);
            command.Parameters.AddWithValue("@aadhar", tenantaadhar);
            command.Parameters.AddWithValue("@phone_no", ownerphoneno);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Created Tenant");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !!");
            }
        }
    }
}
