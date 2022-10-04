using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medicine
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            countmed();
        }
        private void sellerby()
        {
            string sql = "SELECT * FROM seller_inf ";
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                Cgen.Items.Add(reader.GetString(1));
                
            }
            
        }
        private void sellerbysell()
        {
            string sql = "SELECT * FROM bill ";
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
            }
            cusbill.Text = x.ToString();
            x = 0;
            conn.Close();

        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void dashboard_Load(object sender, EventArgs e)
        {

        }
        private void countmed()
        {
            string sql = "SELECT * FROM stock ";
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
            }
            mednum.Text = x.ToString();
            x = 0;
            conn.Close();
            sql = "SELECT * FROM customer ";
            conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            x = 0;
            while (reader.Read())
            {
                x++;
            }
            cusnum.Text = x.ToString();
            x = 0;
            conn.Close();
            sql = "SELECT * FROM seller_inf ";
            conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            x = 0;
            while (reader.Read())
            {
                x++;
            }
            sell1.Text = x.ToString();
            x = 0;
            conn.Close();

            string sql_ = "SELECT * FROM bill   ";
            conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            cmd = new MySqlCommand(sql_, conn);
            conn.Open();
            MySqlDataReader reader_ = cmd.ExecuteReader();
            int x_ = 0;
            while (reader_.Read())
            {
                x_ += reader_.GetInt32(7);
            }
            label15.Text = x_.ToString();
            x_ = 0;
            conn.Close();
            
            

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            countmed();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            new bill().Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Customer().Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new phamacy().Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new sellers().Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            new history().Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            new login().Show();
            this.Hide();
        }
        string seller_;
        private void Cgen_SelectedIndexChanged(object sender, EventArgs e)
        {
            label17.Text = Cgen.Text;
            string sql__ = "SELECT * FROM `seller_inf` WHERE ชื่อพนักงาน='" + label17.Text + "'";
            MySqlConnection conn_ = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd_ = new MySqlCommand(sql__, conn_);
            conn_.Open();
            MySqlDataReader reader_ = cmd_.ExecuteReader();
            
            while (reader_.Read())
            {
                seller_ = reader_.GetString(5);
            }
            label17.Text = Cgen.Text;
            string sql_ = $"SELECT * FROM `bill` WHERE Sname='{seller_}'";
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql_, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x += reader.GetInt32(7);
            }
            cusbill.Text = x.ToString();
            
        }

        private void dashboard_Shown(object sender, EventArgs e)
        {
            sellerby();
            
        }
    }
}
