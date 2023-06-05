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
    public partial class create_tenant : Form
    {
        public create_tenant()
        {
            InitializeComponent();
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
            try
            {
                command.ExecuteNonQuery();
                employee_create_tenant f1 = new employee_create_tenant(newtenantuser);
                f1.Show();

            }
            catch (Exception e1)
            {
                MessageBox.Show("Error Occured !!\nTry again");
            }

        }
    }
}
