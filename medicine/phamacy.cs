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
    public partial class phamacy : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  * FROM stock";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Mstock.DataSource = ds.Tables[0].DefaultView;


        }
        public phamacy()
        {
            InitializeComponent();
        }

        private void saveM_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            String sql = "INSERT INTO stock (ชื่อยา,ประเภท,สรรพคุณ,ปริมาณ,ราคา,บริษัท) VALUES ('" + Mname.Text + "','" + Mtype.Text + "', '" + medp.Text + "','" + Mqty.Text + "','" + Mprice.Text + "','" + Mmanu.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if(rows > 0)
            {
                MessageBox.Show("Add successfully");
                showEquipment();
            }
        }

        private void phamacy_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void Medlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Mstock.CurrentRow.Selected = true;
            Mname.Text = Mstock.Rows[e.RowIndex].Cells["ชื่อยา"].FormattedValue.ToString();
            Mtype.Text = Mstock.Rows[e.RowIndex].Cells["ประเภท"].FormattedValue.ToString();
            Mqty.Text = Mstock.Rows[e.RowIndex].Cells["ปริมาณ"].FormattedValue.ToString();
            Mprice.Text = Mstock.Rows[e.RowIndex].Cells["ราคา"].FormattedValue.ToString();
            Mmanu.Text = Mstock.Rows[e.RowIndex].Cells["บริษัท"].FormattedValue.ToString();
            medp.Text = Mstock.Rows[e.RowIndex].Cells["สรรพคุณ"].FormattedValue.ToString();
        }

        private void deleteM_Click(object sender, EventArgs e)
        {
            DialogResult confirmdelete = MessageBox.Show("you sure to delete information", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (confirmdelete == DialogResult.Yes)
            {

                int selectedRow = Mstock.CurrentCell.RowIndex;
                int daleteId = Convert.ToInt32(Mstock.Rows[selectedRow].Cells["medID"].Value);
                MySqlConnection conn = databaseConnection();
                String sql = "DELETE FROM stock WHERE medID = '" + daleteId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
            }
            else if (confirmdelete==DialogResult.No)
            {
               
                
            }
           showEquipment();
        }

        private void editM_Click(object sender, EventArgs e)
        {
            int selectedRow =Mstock.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Mstock.Rows[selectedRow].Cells["medID"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE stock SET ชื่อยา = '" + Mname.Text+ "',ประเภท = '" + Mtype.Text+ "',สรรพคุณ= '" + medp.Text + "',ปริมาณ = '" + Mqty.Text+ "',ราคา = '" + Mprice.Text+ "',บริษัท = '" + Mmanu.Text+"' WHERE medID = '"+editId+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("edit Successfully");
                showEquipment();
            }

        }

        private void Mprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void Mqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new history().Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new admin().Show();
            this.Hide();
        }

        private void Mname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Mmanu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new phamacy().Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=medicine1;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stock WHERE ชื่อยา LIKE '" + medn.Text + "%" + "' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Mstock.DataSource = ds.Tables[0].DefaultView;

        }
    }
}
