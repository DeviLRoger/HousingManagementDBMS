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
    public partial class create_complaint : Form
    {
        public create_complaint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string build_name = textBox1.Text.ToString();
            string complain = textBox2.Text.ToString();

            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();
            String query = "INSERT INTO complaint(Complaint,building_name) VALUES (@complain,@build_name)";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@build_name", build_name);
            command.Parameters.AddWithValue("@complain", complain);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Complain Logged ! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !!\nBuilding name does not exist");
            }
        }
    }
}
