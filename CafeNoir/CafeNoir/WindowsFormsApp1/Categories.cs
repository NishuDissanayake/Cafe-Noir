﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeNoir
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string qury = "SELECT * FROM CategoryTable";
            SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = qury;
            SqlDataAdapter dd = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dd.Fill(ds, "CategoryTable");
            dataGridView1.DataSource = ds.Tables["CategoryTable"];


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            category.ResetText();
            newname.ResetText();
        }

        private void category_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            string name = category.Text;
            
            

            string add = "INSERT INTO CategoryTable(Name) VALUES ('" + name + "');";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(add);
            MessageBox.Show(feedback);
        }

        private void guna2Button11_Click_1(object sender, EventArgs e)
        {
            string name = category.Text;
            string nname = newname.Text;



            string up = "UPDATE CategoryTable SET Name = '" + nname + "' WHERE Name = '" + name + "' ;";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(up);
            MessageBox.Show(feedback);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            string name = category.Text;



            string del = "DELETE FROM CategoryTable WHERE  Name = '" + name + "' ;";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(del);
            MessageBox.Show(feedback);
        }
    }
}
