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

namespace CafeNoir
{
    public partial class Admin_Home : Form
    {
        databaseconnection dd = new databaseconnection();
        public Admin_Home()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ItemList.Items.Clear();
            string category = comboBox1.Text;
            string qury = "SELECT ItemName FROM ProductTable WHERE Category = '" + category + "'";
            DataSet ds = dd.getData(qury);

            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ItemList.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        protected int n = 0;
        protected decimal total = 0;
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (TotalBox.Text != "0" && TotalBox.Text != "")
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = ItemBox.Text;
                dataGridView1.Rows[n].Cells[1].Value = PriceBox.Text;
                dataGridView1.Rows[n].Cells[2].Value = QuantityBox.Text;
                dataGridView1.Rows[n].Cells[3].Value = TotalBox.Text;

                total = total + decimal.Parse(TotalBox.Text);
                TotalLabel.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity Must Be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch
            {

            }
            total -= amount;
            TotalLabel.Text = "Rs. " + total;
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

        private void Admin_Home_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ItemBox.ResetText();
            PriceBox.ResetText();
            QuantityBox.ResetText();
            TotalBox.ResetText();

        }

        private void ItemList_Click(object sender, EventArgs e)
        {

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
                amount = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch
            {

            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Invoice";
            printer.SubTitle = string.Format("Date: " + DateTime.Now);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.ProportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Amount: " + TotalLabel.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

            total = 0;
            dataGridView1.Rows.Clear();
            TotalLabel.Text = "Rs. " + total;
        
    }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
