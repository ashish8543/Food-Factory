using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Food_Project
    
{
    public partial class SignIn : Form
    {

        public SignIn()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp su = new SignUp();
            su.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ABHISHEK;Initial Catalog=FoodDB;Integrated Security=True");
            SqlDataAdapter sdt = new SqlDataAdapter("Select Count (*) from registration where Email='" + textBox1.Text + "' and Password='" + textBox2.Text + "'",con);

            DataTable dt = new DataTable();
            sdt.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Food fd = new Food();
                fd.Show();
            }
            else
            {
                MessageBox.Show("Please Enter valid Credential");
            }

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}
