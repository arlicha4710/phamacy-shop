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
    public partial class sellers : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showSlist()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM seller_inf";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Slist.DataSource = ds.Tables[0].DefaultView;


        }
        public sellers()
        {
            InitializeComponent();
        }

        private void saveS_Click(object sender, EventArgs e)
        {
            if (Sphone.Text.Length != 10)
            {
                MessageBox.Show("please enter 10 character");
            }
            else
            {
                MySqlConnection conn = databaseConnection();
                String sql = "INSERT INTO seller_inf (ชื่อพนักงาน,หมายเลขโทรศัพท์,ที่อยู่,เพศ,ชื่อผู้ใช้,รหัสผ่าน) VALUES ('" + Sname.Text + "','" + Sphone.Text + "','" + Sadd.Text + "','" + Sgen.Text + "','"+Usell.Text+"','" + Spass.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("Add successfully");
                    showSlist();
                }
            }
        }

        private void Slist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Slist.CurrentRow.Selected = true;
            Sname.Text = Slist.Rows[e.RowIndex].Cells["ชื่อพนักงาน"].FormattedValue.ToString();
            Sphone.Text = Slist.Rows[e.RowIndex].Cells["หมายเลขโทรศัพท์"].FormattedValue.ToString();
            Sadd.Text = Slist.Rows[e.RowIndex].Cells["ที่อยู่"].FormattedValue.ToString();
            Sgen.Text = Slist.Rows[e.RowIndex].Cells["เพศ"].FormattedValue.ToString();
            

            Spass.Text = Slist.Rows[e.RowIndex].Cells["รหัสผ่าน"].FormattedValue.ToString();
            Usell.Text = Slist.Rows[e.RowIndex].Cells["ชื่อผู้ใช้"].FormattedValue.ToString();
        }
        
        private void deleteS_Click(object sender, EventArgs e)
        {
            DialogResult confirmdelete = MessageBox.Show("you sure to delete information", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmdelete == DialogResult.Yes)
            {
                int selectedRow = Slist.CurrentCell.RowIndex;
            int daleteId = Convert.ToInt32(Slist.Rows[selectedRow].Cells["Sid"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "DELETE FROM seller_inf WHERE Sid = '" + daleteId + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            }
            else if (confirmdelete == DialogResult.No)
            {


            }
            //if (rows > 0)
            //{
            //    MessageBox.Show("ลบเรียบร้อย");
            //    showSlist();
            //}
        }

        private void editS_Click(object sender, EventArgs e)
        {
            int selectedRow = Slist.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Slist.Rows[selectedRow].Cells["Sid"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE seller_inf SET ชื่อพนักงาน = '" + Sname.Text + "',หมายเลขโทรศัพท์ = '" + Sphone.Text + "',ที่อยู่ = '" + Sadd.Text + "',เพศ = '" + Sgen.Text + "',ชื่อผู้ใช้= '"+Usell+"',รหัสผ่าน = '"+Spass.Text+"' WHERE Sid = '" + editId + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("edit Successfully");
                showSlist();
            }
        }

        private void sellers_Load_1(object sender, EventArgs e)
        {
            showSlist();
        }

        private void Sphone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new phamacy().Show();
            this.Hide();
        }

        private void Sphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            new history().Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void Sname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57))
            {
                e.Handled = true;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM seller_inf WHERE ชื่อพนักงาน LIKE '" + sellname.Text + "%" + "' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Slist.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
