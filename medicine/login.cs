using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace medicine
{
    public partial class login : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        public static string Seller;
        
        private void button1_Click(object sender, EventArgs e)
        {


            if (userlogin.Text != "" && passlogin.Text != "")

            {
                string sql = "SELECT * FROM seller_inf WHERE ชื่อผู้ใช้ = '" + userlogin.Text + "' and รหัสผ่าน	='" + passlogin.Text + "' ";
                MySqlConnection con = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Seller=userlogin.Text;
                    new Customer().Show();
                    this.Hide();



                }
            

          
                else
                {
                    MessageBox.Show("Wrong!! username or password");
                }
            }
            else
            {
                MessageBox.Show("Please enter your username and your password");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new admin().Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
