using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeNoir
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void none_dashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();
            this.Hide();
            c.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Admin_Home ah = new Admin_Home();
            this.Hide();
            ah.Show();

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            this.Hide();
            p.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            this.Hide();
            u.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }
    }
}
