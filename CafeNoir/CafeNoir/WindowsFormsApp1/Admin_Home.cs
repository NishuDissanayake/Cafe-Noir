using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;
using System.Drawing.Printing;

namespace CafeNoir
{
    public partial class Admin_Home : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
        SqlCommand cmd;

        databaseconnection dd = new databaseconnection();
        public Admin_Home()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = Login.recby;
            Categories.Items.Clear();
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
                    Categories.Items.Add(dr["Name"].ToString());
                }

            }
            catch(SqlException s)
            {
                MessageBox.Show(s.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Categories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ItemList.Items.Clear();
            string category = Categories.Text;
            string qury = "SELECT ItemName FROM ProductTable WHERE Category = '" + category + "'";
            DataSet ds = dd.getData(qury);

            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ItemList.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void ItemBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ItemBox.ResetText();
            PriceBox.ResetText();
            QuantityBox.ResetText();
            TotalBox.ResetText();
        }

        protected int n = 0;
        protected decimal total = 0;
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string order = "INSERT INTO OrderTable(Date_Time, Products, Quantity, Total) VALUES ('" + now + "', '" + ItemBox.Text + "', " + QuantityBox.Text + ", " + TotalBox.Text + ");";

            dd.dataconnection(order);

            if (TotalBox.Text != "0.00" && TotalBox.Text != "")
            {
                n = dgvAdmin_Bill.Rows.Add();
                dgvAdmin_Bill.Rows[n].Cells[0].Value = ItemBox.Text;
                dgvAdmin_Bill.Rows[n].Cells[1].Value = PriceBox.Text;
                dgvAdmin_Bill.Rows[n].Cells[2].Value = QuantityBox.Text;
                dgvAdmin_Bill.Rows[n].Cells[3].Value = TotalBox.Text;

                total = total + decimal.Parse(TotalBox.Text);
                label8.Text = "Rs. " + total;

                ItemBox.ResetText();
                PriceBox.ResetText();
                QuantityBox.ResetText();
                TotalBox.ResetText();
            }
            else
            {
                MessageBox.Show("Minimum Quantity Must Be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuantityBox.ResetText();
            TotalBox.ResetText();
            

            string text = ItemList.GetItemText(ItemList.SelectedItem);
            ItemBox.Text = text;
            string qury = "SELECT UnitPrice FROM ProductTable WHERE ItemName = '" + text + "'";
            DataSet ds = dd.getData(qury);

            try
            {
                PriceBox.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (SqlException es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void QuantityBox_ValueChanged(object sender, EventArgs e)
        {
            int qu = int.Parse(QuantityBox.Value.ToString());
            decimal pr = decimal.Parse(PriceBox.Text);
            TotalBox.Text = (qu * pr).ToString();
        }

        decimal amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = decimal.Parse(dgvAdmin_Bill.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch
            {

            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAdmin_Bill.Rows.RemoveAt(this.dgvAdmin_Bill.SelectedRows[0].Index);
            }
            catch
            {

            }
            total -= amount;
            label8.Text = "Rs. " + total;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;

            DialogResult result = printDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Categories ob1 = new Categories();
            ob1.Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Products ob2 = new Products();
            ob2.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Users ob3 = new Users();
            ob3.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login fm = new Login();
            this.Hide();
            fm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Cafe Noir Management System ", new Font("Ubuntu", 23, FontStyle.Bold), Brushes.Red, new Point(160, 10));

            e.Graphics.DrawString("invoice ", new Font("Ubuntu", 21, FontStyle.Bold), Brushes.Black, new Point(300, 60));

            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Ubuntu", 16, FontStyle.Regular), Brushes.Black, new Point(300, 100));

            e.Graphics.DrawString("_____________________________________", new Font("Ubuntu", 20, FontStyle.Regular), Brushes.Black, new Point(0, 120));

            Bitmap objbmp = new Bitmap(this.dgvAdmin_Bill.Width, this.dgvAdmin_Bill.Height);
            dgvAdmin_Bill.DrawToBitmap(objbmp, new Rectangle(0, 0, this.dgvAdmin_Bill.Width, this.dgvAdmin_Bill.Height));
            e.Graphics.DrawImage(objbmp, 100, 300);

            e.Graphics.DrawString("Total: " + label8.Text, new Font("Ubuntu", 16, FontStyle.Regular), Brushes.Black, new Point(500, 200));
        }
    }
}
