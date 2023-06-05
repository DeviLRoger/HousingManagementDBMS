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
    public partial class create_tenant_byonwer : Form
    {
        string oid = "";
        public create_tenant_byonwer(string ownerid)
        {
            InitializeComponent();
            oid = ownerid;
        }

        private void create_tenant_byonwer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newtenantuser = textBox1.Text;
            string newtenantpassword = textBox2.Text;

            // insert into Signin value(newuser,newpass)
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();
            String query = "INSERT INTO Signin VALUES (@username,@password)";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", newtenantuser);
            command.Parameters.AddWithValue("@password", newtenantpassword);

            command.ExecuteNonQuery();

            create_tenantdetails_byowner f1 = new create_tenantdetails_byowner(newtenantuser,oid);
            f1.Show();
        }
    }
}
