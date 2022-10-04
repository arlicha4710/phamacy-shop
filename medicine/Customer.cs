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
    public partial class Customer : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showCustomer()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM customer WHERE ชื่อพนักงาน = '{login.Seller}' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Clist.DataSource = ds.Tables[0].DefaultView;


        }
        public Customer()
        {
            InitializeComponent();
        }

        private void saveC_Click(object sender, EventArgs e)
        {
            if (Cphone.Text.Length!=10)
            {
                MessageBox.Show("please enter 10 character");
            }
            else
            {


                MySqlConnection conn = databaseConnection();
             
                String sql = "INSERT INTO customer (ชื่อพนักงาน,ชื่อลูกค้า,หมายเลขโทรศัพท์,ที่อยู่,เพศ,อาการ,ประวัติการแพ้ยา) VALUES ('" + login.Seller+"','" + Cname.Text + "','" + Cphone.Text + "','" + Cadd.Text + "','" + Cgen.Text + "','"+ Ccon.Text +"','"+ Call.Text +"')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("Add successfully");
                    showCustomer();
                }
            }

        }

        private void editC_Click(object sender, EventArgs e)
        {
            int selectedRow = Clist.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Clist.Rows[selectedRow].Cells["CusId"].Value);
            MySqlConnection conn = databaseConnection();
       
            String sql = "UPDATE customer SET ชื่อลูกค้า = '" + Cname.Text + "',หมายเลขโทรศัพท์ = '" + Cphone.Text + "',ที่อยู่ = '" + Cadd.Text + "',เพศ = '" + Cgen.Text + "',อาการ = '" + Ccon.Text + "',ประวัติการแพ้ยา = '" + Call.Text + "' WHERE CusId = '" + editId + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("edit Successfully");
                showCustomer();
            }
        }

        private void deleteC_Click(object sender, EventArgs e)
        {
            DialogResult confirmdelete = MessageBox.Show("you sure to delete information", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmdelete == DialogResult.Yes)
            {
                int selectedRow = Clist.CurrentCell.RowIndex;
                int daleteId = Convert.ToInt32(Clist.Rows[selectedRow].Cells["CusId"].Value);
                MySqlConnection conn = databaseConnection();
                String sql = "DELETE FROM customer WHERE CusId = '" + daleteId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("delete Successfully");
                    showCustomer();
                }
            }
        }

        private void Clist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clist.CurrentRow.Selected = true;
            Cname.Text =Clist.Rows[e.RowIndex].Cells["ชื่อลูกค้า"].FormattedValue.ToString();
            Cphone.Text = Clist.Rows[e.RowIndex].Cells["หมายเลขโทรศัพท์"].FormattedValue.ToString();
            Cadd.Text = Clist.Rows[e.RowIndex].Cells["ที่อยู่"].FormattedValue.ToString(); 
            Cgen.Text = Clist.Rows[e.RowIndex].Cells["เพศ"].FormattedValue.ToString();
            Ccon.Text = Clist.Rows[e.RowIndex].Cells["อาการ"].FormattedValue.ToString();
            Call.Text = Clist.Rows[e.RowIndex].Cells["ประวัติการแพ้ยา"].FormattedValue.ToString();

        }

        private void Customer_Load(object sender, EventArgs e)
        {
                showCustomer();
            
        }

        private void Cphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            new bill().Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new sellers().Show();
            this.Hide();
        }

        private void Cphone_TextChanged(object sender, EventArgs e)
        {

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Customer().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }

        private void Cname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cadd_TextChanged(object sender, EventArgs e)
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
            cmd.CommandText = "SELECT * FROM customer WHERE ชื่อลูกค้า LIKE '" + cusname.Text + "%" + "' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Clist.DataSource = ds.Tables[0].DefaultView;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new phamacy().Show();
            this.Hide();
        }
    }
}
