﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeNoir
{
    public partial class Users : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        public Users()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            string nic = nicnumber.Text;
            
            string del = "DELETE FROM UserTable WHERE  NIC = '" + nic + "' ;";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(del);
            MessageBox.Show(feedback);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            string nic = nicnumber.Text;
            string phonenum = pnumber.Text;
            string pwd = pass.Text;

            string up = "UPDATE UserTable SET PhoneNumber = '" + phonenum + "', PassCode = '" + pwd + "' WHERE NIC = '" + nic + "';";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(up);
            MessageBox.Show(feedback);

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            string usertype = utype.Text;
            string uname = name.Text;
            string nic = nicnumber.Text;
            string phonenum = pnumber.Text;
            string username = usern.Text;
            string pwd = pass.Text;

            string add = "INSERT INTO UserTable(UserType, Name, NIC, PhoneNumber, UserName, PassCode) VALUES ('" + usertype + "' , '" + uname + "' , '" + nic + "' , '" + phonenum + "' , '" + username + "' , '" + pwd + "');";

            databaseconnection db = new databaseconnection();
            string feedback = db.dataconnection(add);
            MessageBox.Show(feedback);

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            utype.ResetText();
            name.ResetText();
            nicnumber.ResetText();
            pnumber.ResetText();
            usern.ResetText();
            pass.ResetText();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string qury = "SELECT * FROM UserTable";
            SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = qury;
            SqlDataAdapter dd = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dd.Fill(ds, "UserTable");
            dataGridView1.DataSource = ds.Tables["UserTable"];

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
