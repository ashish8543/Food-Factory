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
    public partial class SignUp : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ABHISHEK;Initial Catalog=FoodDB;Integrated Security=True");
        SqlDataAdapter sdt = new SqlDataAdapter();

        public SignUp()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn su = new SignIn();
            su.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            sdt.InsertCommand = new SqlCommand("INSERT INTO registration VALUES(@Name,@Email,@Password,@ContactNo)", con);
            sdt.InsertCommand.Parameters.Add("@Name", SqlDbType.Char).Value = textBox1.Text;
            sdt.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBox2.Text;
            sdt.InsertCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = textBox3.Text;
            sdt.InsertCommand.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = textBox4.Text;
            sdt.InsertCommand.ExecuteNonQuery();
            MessageBox.Show("Your data saved Sucessfully");
            
            con.Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
