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
    public partial class create_employee : Form
    {
        public create_employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newemployeeuser = textBox1.Text;
            string newemployeepassword = textBox2.Text;

            // insert into Signin value(newuser,newpass)
            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True"); 
            conn.Open();
            String query = "INSERT INTO Signin VALUES (@username,@password)";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", newemployeeuser);
            command.Parameters.AddWithValue("@password", newemployeepassword);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Owner has been created successfully");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error occurred\ntry again");
            }

            create_employee_detailed f1 = new create_employee_detailed(newemployeeuser);
            f1.Show();
        }
    }
}
