using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace CafeNoir
{
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");

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

        public Dashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string qury = "SELECT * FROM OrderTable";
            SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = qury;
            SqlDataAdapter dd = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dd.Fill(ds, "OrderTable");
            sales_data.DataSource = ds.Tables["OrderTable"];
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            string sql = "SELECT MAX(Order_ID) FROM OrderTable";
            SqlCommand sqlCmd;
            int storeMaxId = 0;
            try
            {
                
                con.Open();
                
                sqlCmd = new SqlCommand(sql, con);
                
                storeMaxId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                orderBox.Text = storeMaxId.ToString();
                sqlCmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT SUM(Total) FROM OrderTable;";
            SqlCommand sqlCmd;
            int totVal = 0;
            try
            {
                con.Open();

                sqlCmd = new SqlCommand(sql, con);

                totVal = Convert.ToInt32(sqlCmd.ExecuteScalar());
                TotBox.Text = totVal.ToString();
                sqlCmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
