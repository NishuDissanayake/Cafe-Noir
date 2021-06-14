using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeNoir
{
    class databaseconnection
    {
        public string dataconnection(string qury)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=CafeNoir;Integrated Security=True");
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
    }
}
