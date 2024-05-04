using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class DAO
    {
        SqlConnection con = new SqlConnection("Data Source=./;Initial Catalog=Arquitectura4Capas;Integrated Security=True");
        public DataSet ReadData(string sql)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, con);
                DataSet set = new DataSet();
                dataAdapter.Fill(set);
                return set;
            }
            catch (Exception ex) { throw ex; }
            finally { if (con.State != ConnectionState.Closed) con.Close(); }
        }
        public int WriteData(string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                con.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { if (con.State != ConnectionState.Closed) con.Close(); }
        }

    }
}
