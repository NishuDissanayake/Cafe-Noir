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
using DGVPrinterHelper;
using System.Drawing.Printing;

namespace CafeNoir
{
    public partial class Products : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
        SqlCommand cmd;

        databaseconnection dd = new databaseconnection();
        public Products()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Admin_Home ob1 = new Admin_Home();
            ob1.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Categories ob2 = new Categories();
            ob2.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Users ob3 = new Users();
            ob3.Show();
            this.Hide();
        }

        private void ComboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboCategory_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void Products_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void Products_Load(object sender, EventArgs e)
        {
            ComboCategory.Items.Clear();
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Name from CategoryTable";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    ComboCategory.Items.Add(dr["Name"].ToString());
                }

            }
            catch (SqlException s)
            {
                MessageBox.Show(s.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
