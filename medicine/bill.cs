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
    public partial class bill : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showstock()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stock";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Mstock.DataSource = ds.Tables[0].DefaultView;


        }
        public bill()
        {
            InitializeComponent();
            user.Text = login.Seller;
        }
        
        private void resetB_Click(object sender, EventArgs e)
        {
            Bmed.Text = "";
            Bqty.Text = "";
            Bprice.Text = "";

        }

        private void bill_Load(object sender, EventArgs e)
        {
            showstock();
        }
        
        private void Mstock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Mstock.CurrentRow.Selected = true;
            Bmed.Text = Mstock.Rows[e.RowIndex].Cells["ชื่อยา"].FormattedValue.ToString();
            
            Bprice.Text = Mstock.Rows[e.RowIndex].Cells["ราคา"].FormattedValue.ToString();
            

        }
        //private void update()
        //{
        //    try
        //    {

                
        //        int editId = Convert.ToInt32(Mstock.Rows[selectedRow].Cells["medID"].Value);
        //        string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
        //        MySqlConnection conn = new MySqlConnection(connectionString);
        //        int Newqty = Stock= Convert.ToInt32(Bqty.Text);
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("UPDATE stock SET medQty = '" + Bqty.Text + "' WHERE medID = '" + editId + "'";



        //    }
        //}
        private void showEquipment()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  * FROM bill";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;


        }
        

        private void addB_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `stock` WHERE ชื่อยา= '" + Bmed.Text + "'  ";
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && Convert.ToInt32(reader.GetString(4)) >= Convert.ToInt32(Bqty.Text)
                && Convert.ToInt32(reader.GetString(4)) > 0)
            {

                int ss_ss = Convert.ToInt32(reader.GetString(4)) - Convert.ToInt32(Bqty.Text);
                string sql2 = $"UPDATE `stock` SET `ปริมาณ` = {ss_ss} WHERE `stock`.`ชื่อยา` = '{Bmed.Text}' ";
                MySqlConnection con2 = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();
                //MessageBox.Show("คำสั่งซื้อได้รับมายืนยัน");
            }
            ////////////////////////////////////////////////////////////

            MySqlConnection conn_ = databaseConnection();
            String sql_ = "INSERT INTO bill (Sname,Cusnum,Cusn,medn,quantity,Bdate,Bamount) VALUES" +
                " ('" + login.Seller + "','" + Cid.Text + "','" + Bname.Text + "','" + Bmed.Text + "','" + Bqty.Text + "','" + DateTime.Now.ToShortDateString() + "','" + Convert.ToInt32(Bprice.Text) * Convert.ToInt32(Bqty.Text) + "')";
            MySqlCommand cmd_ = new MySqlCommand(sql_, conn_);
            conn_.Open();
            int rows = cmd_.ExecuteNonQuery();
            conn_.Close();
            if (rows > 0)
            {
                MessageBox.Show("Add to bill sucessfully");
                showEquipment();


            }
            showstock();
        }
        int Key = 0, Stock = 0;
        private void Bprice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Bprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            //{
            //    e.Handled = true;
            //}
        }
        
        //private void showbill()

        //{
        //    MySqlConnection conn = databaseConnection();
           
            

            
        //    string Query = "SELECT * FROM bill WHERE Sname = '" + user.Text + "'";
        //    MySqlDataAdapter sda = new MySqlDataAdapter(Query, conn);   
        //    MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
            
        //    conn.Open();
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    showbilldgv.DataSource = ds.Tables[0];
        //    conn.Close();



        //}\
        
        
        private void Bqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void Bname_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sql = "SELECT * FROM customer WHERE ชื่อลูกค้า LIKE '" + "%" + Bname.Text + "%" + "'";
            //MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //conn.Open();
            //MySqlDataReader reader = cmd.ExecuteReader();
            //int x = 0;
            //while (reader.Read())
            //{
            //    Cid.Text = reader.GetString(0);
            //    Bname.Text = reader.GetString(1);
            //}

            //x = 0;
            //conn.Close();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new history().Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            new login().Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM customer WHERE ชื่อลูกค้า LIKE '" + "%" + Bname.Text + "%" + "'";
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x_ = 0;
            while (reader.Read())
            {

                Cid.Text = reader.GetString(0);
                Bname.Text = reader.GetString(1);
                Ccon.Text = reader.GetString(6);
                Call.Text = reader.GetString(7);
            }

            x_ = 0;
            conn.Close();
        }

        

        private void generate_Click(object sender, EventArgs e)
        {
        
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stock WHERE ชื่อยา LIKE '" + Nmed.Text + "%" + "' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Mstock.DataSource = ds.Tables[0].DefaultView;
            

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stock WHERE สรรพคุณ LIKE '" + "%" + cmmed.Text + "%" + "' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Mstock.DataSource = ds.Tables[0].DefaultView;

        }

        private void printB_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog ();
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------- ", new Font("Nirmala UI", 14, FontStyle.Regular), Brushes.Black, new Point(10, 70));
            e.Graphics.DrawString("DRUG STORE", new Font("Nirmala UI", 28, FontStyle.Regular), Brushes.Black, new Point(300, 120));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------- ", new Font("Nirmala UI", 14, FontStyle.Regular), Brushes.Black, new Point(10, 200));
            e.Graphics.DrawString("CUSTOMER NAME   : ", new Font("Nirmala UI", 17, FontStyle.Regular), Brushes.Black, new Point(100, 280));
            e.Graphics.DrawString("CUSTOMER PHONE   :", new Font("Nirmala UI", 17, FontStyle.Regular), Brushes.Black, new Point(100, 340));
            e.Graphics.DrawString("DATE TIME   : ", new Font("Nirmala UI", 18, FontStyle.Regular), Brushes.Black, new Point(430, 420));

            e.Graphics.DrawString("ID ", new Font("Nirmala UI", 18, FontStyle.Regular), Brushes.Black, new Point(90, 470));
            e.Graphics.DrawString("MEDICINE ", new Font("Nirmala UI", 18, FontStyle.Regular), Brushes.Black, new Point(240, 470));
            e.Graphics.DrawString("QUANTITY ", new Font("Nirmala UI", 18, FontStyle.Regular), Brushes.Black, new Point(480, 470));
            e.Graphics.DrawString("PRICE ", new Font("Nirmala UI", 18, FontStyle.Regular), Brushes.Black, new Point(680, 470));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------- ", new Font("Nirmala UI", 14, FontStyle.Regular), Brushes.Black, new Point(10, 850));
            e.Graphics.DrawString("TOTAl   : ", new Font("Nirmala UI", 26, FontStyle.Regular), Brushes.Black, new Point(200, 900));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------- ", new Font("Nirmala UI", 14, FontStyle.Regular), Brushes.Black, new Point(10, 970));


            string sql_ = "SELECT * FROM `bill` WHERE Cusn = '"+ Bname.Text + "'";
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql_, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            int y = 0;
            int type_=0;
            while (reader.Read())
            {
                e.Graphics.DrawString(reader.GetString(0), new Font("Nirmala UI", 16, FontStyle.Regular), Brushes.Black, new Point(90, 520+50*y));
                e.Graphics.DrawString(reader.GetString(4), new Font("Nirmala UI", 16, FontStyle.Regular), Brushes.Black, new Point(240, 520+50*y));
                e.Graphics.DrawString(reader.GetString(5), new Font("Nirmala UI", 16, FontStyle.Regular), Brushes.Black, new Point(500, 520+50*y));
                e.Graphics.DrawString(Convert.ToString(reader.GetInt32(7)/reader.GetInt32(5)), new Font("Nirmala UI", 16, FontStyle.Regular), Brushes.Black, new Point(680,520+50*y));
                type_+=reader.GetInt32(7);
                x++;
                y++;
            }
            e.Graphics.DrawString(Convert.ToString(type_), new Font("Nirmala UI", 26, FontStyle.Regular), Brushes.Black, new Point(390, 900 ));
            
            string sql__ = "SELECT * FROM `customer` WHERE ชื่อลูกค้า = '" + Bname.Text + "'";
            MySqlConnection conn_ = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;");
            MySqlCommand cmd_ = new MySqlCommand(sql__, conn_);
            conn_.Open();
            MySqlDataReader reader_ = cmd_.ExecuteReader();
            int x_ = 0;
            int y_ = 0;
            
            while (reader_.Read())
            {
                e.Graphics.DrawString(reader_.GetString(1), new Font("Nirmala UI", 18, FontStyle.Regular), Brushes.Black, new Point(350, 280 ));
                e.Graphics.DrawString(reader_.GetString(3), new Font("Nirmala UI", 18, FontStyle.Regular), Brushes.Black, new Point(350, 340 ));
                
                x_++;
                y_++;
            }
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), new Font("Nirmala UI", 16, FontStyle.Regular), Brushes.Black, new Point(600, 420));


        }
    }
}
