using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace CafeNoir
{
    public partial class Login : Form
    {
        private SqlConnection con;

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
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            uname.ResetText();
            pass.ResetText();
            
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public static string username;

        public static string recby
        {
            get { return username; }
            set { username = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recby = uname.Text;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["CC"].ConnectionString);

            try
            {
                SqlCommand com = new SqlCommand("roleLogin", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                com.Parameters.AddWithValue("@UName", uname.Text);
                com.Parameters.AddWithValue("@PCode",pwd);
                SqlDataReader rd = com.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    if (rd[1].ToString()=="Admin")
                    {
                        Admin_Home ah = new Admin_Home();
                        ah.Show();
                        this.Hide();
                    }
                    else if (rd[1].ToString()=="Staff")
                    {
                        Staff_Home sf = new Staff_Home();
                        sf.Show();
                        this.Hide();
                    }   
                    else
                    {
                        MessageBox.Show("An error occured");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        public string Hash(Byte[] val)
        {
            using (SHA1Managed shal = new SHA1Managed())
            {
                var hash = shal.ComputeHash(val);
                return Convert.ToBase64String(hash);
            }
        }

        string pwd;
        private void pass_TextChanged(object sender, EventArgs e)
        {
            Byte[] passHash = System.Text.Encoding.UTF8.GetBytes(pass.Text.ToString());

            pwd = Hash(passHash);

        }

        private void button2_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}



