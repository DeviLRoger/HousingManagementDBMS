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
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApplication1
{
    public partial class resolve_complain : Form
    {
        public resolve_complain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string complaint_no = textBox1.Text;
            string status = textBox2.Text;

            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True"); conn.Open();

            // Create a SqlCommand object and set its CommandText property to the SQL query
            SqlCommand cmd = new SqlCommand("UpdateComplaintStatus", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pcomplaint_no ", complaint_no);
            cmd.Parameters.AddWithValue("@pstatus", status);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Complain No " + complaint_no + " updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured !!\nTry again","Warning\n"+ex.ToString());
            }

        }
    }
}
