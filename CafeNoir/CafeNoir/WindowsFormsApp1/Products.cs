using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafeNoir
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login fm = new Login();
            this.Hide();
            fm.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ComboCategory.ResetText();
            TxtBoxItemName.ResetText();
            txtBoxPrice.ResetText();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            string category = ComboCategory.Text;
            string itemname = TxtBoxItemName.Text;
            decimal unitprice = decimal.Parse(txtBoxPrice.Text);


            string up = "UPDATE ProductTable SET UnitPrice = " + unitprice + " WHERE ItemName = '" + itemname + "' ;";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(up);
            MessageBox.Show(feedback);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            string category = ComboCategory.Text;
            string itemname = TxtBoxItemName.Text;
            decimal unitprice = decimal.Parse(txtBoxPrice.Text);


            string add = "INSERT INTO ProductTable(ItemName, Category, UnitPrice) VALUES ('" + itemname + "', '" + category + "', " + unitprice + ");";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(add);
            MessageBox.Show(feedback);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            string itemname = TxtBoxItemName.Text;


            string del = "DELETE FROM ProductTable WHERE  ItemName = '" + itemname + "' ;";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(del);
            MessageBox.Show(feedback);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string qury = "SELECT * FROM ProductTable";
            SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = qury;
            SqlDataAdapter dd = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dd.Fill(ds, "ProductTable");
            dataGridView1.DataSource = ds.Tables["ProductTable"];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
