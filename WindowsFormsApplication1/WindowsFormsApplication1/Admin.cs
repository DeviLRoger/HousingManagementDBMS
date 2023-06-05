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
    // All buttons are working fine need to test just create ones
    public partial class Admin : Form
    {
        public Admin(string username)
        {
            InitializeComponent();
            //label11.Text = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show all the Owner details
            owner_details f6 = new owner_details();
            f6.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Show all the Tenant Details
            Tenant_details f7 = new Tenant_details();
            f7.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Show all the Employee Details
            employee_details f8 = new employee_details();
            f8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Creating an owner with apartment no
            create_owner f13 = new create_owner();
            f13.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Creating an employee with building name
            create_employee f12 = new create_employee();
            f12.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Show all the complaints
            complain_details f9 = new complain_details();
            f9.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f1 = new Login();
            f1.Show();
        }
    }
}
