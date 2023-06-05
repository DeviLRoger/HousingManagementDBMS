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
    public partial class create_owner_details : Form
    {
        string owuserid = "";
        public create_owner_details(string sentowuserid)
        {
            InitializeComponent();
            owuserid = sentowuserid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ownername = textBox1.Text.ToString();
            string owneraptno = textBox2.Text.ToString();
            string owneraadhar = textBox3.Text.ToString();
            string ownerbuildingname = textBox4.Text.ToString();
            string ownerphoneno = textBox5.Text.ToString();

            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();
            String query = "INSERT INTO Owner_Table(userName,Owner_Name,apartment_no,aadhar_id,building_name,phone_no) VALUES (@userName,@ownerName,@apt_no,@aadhar,@Building_name,@phone_no)";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@userName", owuserid);
            command.Parameters.AddWithValue("@ownerName", ownername);
            command.Parameters.AddWithValue("@apt_no", owneraptno);
            command.Parameters.AddWithValue("@aadhar", owneraadhar);
            command.Parameters.AddWithValue("@Building_name", ownerbuildingname);
            command.Parameters.AddWithValue("@phone_no", ownerphoneno);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Created Owner");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !!\nApartment_no. or Building_name. does not exist");
            }

        }
    }
}
