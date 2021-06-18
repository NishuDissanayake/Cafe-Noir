using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CafeNoir
{
    class databaseconnection
    {
        public string dataconnection(string qury)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
            SqlCommand com = new SqlCommand(qury, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                return "Operation Successfull!";
            }
            catch(SqlException sc)
            {
                return sc.ToString();
            }
            finally
            {
                con.Close();
            }

       
        }


        public DataSet getData(string qury)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = qury;
            SqlDataAdapter dd = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dd.Fill(ds);
            return ds;

        }

        public void SetData(String qury)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost; Initial Catalog = CafeNoir; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = qury;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Processed Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException sc)
            {
                MessageBox.Show(sc.ToString());
            }
            finally
            {
                con.Close();

            }
        }
    }
}
