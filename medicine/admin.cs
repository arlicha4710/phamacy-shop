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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void loginadmin_Click(object sender, EventArgs e)
        {
            if (admintext.Text == "")
            {

            }
            else if (admintext.Text == "ADMIN")
            {
                phamacy obj = new phamacy();
                obj.Show();
                this.Hide();
            }else

            {
                MessageBox.Show("Missing Password");
                admintext.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}
