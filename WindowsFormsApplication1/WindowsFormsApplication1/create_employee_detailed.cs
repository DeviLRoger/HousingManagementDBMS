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
    public partial class create_employee_detailed : Form
    {
        string emuserid = "";
        public create_employee_detailed(string sentemuserid)
        {
            InitializeComponent();
            emuserid = sentemuserid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeename = textBox1.Text.ToString();
            string employeesalary = textBox2.Text.ToString();
            string employeebuildingname = textBox3.Text.ToString();
            string employeephoneno = textBox4.Text.ToString();

            SqlConnection conn = new SqlConnection("Data Source=DEVILROGER;Initial Catalog=apartment1DB;Integrated Security=True");
            conn.Open();
            String query = "INSERT INTO Employee1(userName,Emp_name,Salary,Building_name,phone_no) VALUES (@userName,@Emp_name,@Salary,@Building_name,@phone_no)";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@userName", emuserid);
            command.Parameters.AddWithValue("@Emp_name", employeename);
            command.Parameters.AddWithValue("@Salary", employeesalary);
            command.Parameters.AddWithValue("@Building_name", employeebuildingname);
            command.Parameters.AddWithValue("@phone_no", employeephoneno);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Created employee");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !!\nBuilding name does not exist");
            }

            
        }
    }
}
