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
    public partial class history : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showhistory()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM bill";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            historyB.DataSource = ds.Tables[0].DefaultView;

            string sql = "SELECT * FROM bill ";
            conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x+=reader.GetInt32(7);
            }
            label6.Text = x.ToString();
            x = 0;
            conn.Close();


        }
        public history()
        {
            InitializeComponent();
        }

        private void history_Load(object sender, EventArgs e)
        {
            showhistory();
        }

        private void historyB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            new bill().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            new admin().Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            search_1();
            

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            //MySqlConnection conn = new MySqlConnection(connectionString);
            //DataSet ds = new DataSet();
            //conn.Open();

            //MySqlCommand cmd;
            //cmd = conn.CreateCommand();
            //cmd.CommandText = "SELECT * FROM bill WHERE Bdate LIKE '" + dtime.Text + "%" + "' ";

            //MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            //adapter.Fill(ds);

            //conn.Close();
            //historyB.DataSource = ds.Tables[0].DefaultView;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";

            s_monts();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            int x = 0;
            if (comboBox2.Text == "1" || comboBox2.Text == "3" || comboBox2.Text == "5" ||
                comboBox2.Text == "7" || comboBox2.Text == "8" || comboBox2.Text == "10" ||
                comboBox2.Text == "12")
            {
                x = 31;
            }
            else if (comboBox2.Text == "4" || comboBox2.Text == "6" || comboBox2.Text == "9" ||
                comboBox2.Text == "11")
            {
                x = 30;
            }
            else if (comboBox2.Text == "2")
            {
                x = 28;
            }
            comboBox3.Items.Add("");
            for (int i = 1; i <= x; i++)
            {
                comboBox3.Items.Add(i.ToString());
            }

            s_monts();
        }
        string monts;
        private void s_monts()
        {
            if (comboBox1.Text != "")
            {
                monts = comboBox1.Text;
            }
            if (comboBox2.Text != "")
            {
                monts = comboBox2.Text + "/" + comboBox1.Text;
            }
            if (comboBox3.Text != "")
            {
                monts = comboBox3.Text + "/" + comboBox2.Text + "/" + comboBox1.Text;
            }
            search_1();




        }
        private void search_1()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM bill WHERE Bdate LIKE '" + "%" + comboBox1.Text + "' and Bdate LIKE '" + comboBox2.Text + "%" + "' and Bdate LIKE '" + "%" + comboBox3.Text + "%" + "' and Cusn LIKE '" + seach.Text + "%" + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            historyB.DataSource = ds.Tables[0].DefaultView;

            string sql = "SELECT* FROM bill WHERE Bdate LIKE '" + "%" + comboBox1.Text + "' and Bdate LIKE '" + comboBox2.Text + "%" + "' and Bdate LIKE '" + "%" + comboBox3.Text + "%" + "' and Cusn LIKE '" + seach.Text + "%" + "' ";
            conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x += reader.GetInt32(7);
            }
            label6.Text = x.ToString();
            x = 0;
            conn.Close();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_monts();
        }
    }
}
