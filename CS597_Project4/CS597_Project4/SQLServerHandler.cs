using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CS597_Project4
{
    public class SQLServerHandler
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public SQLServerHandler(string connectionStringId)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringId].ConnectionString);
        }

        public void CreateCommand(string query)
        {
            cmd = new SqlCommand(query, conn);
        }

        public void AddParameter(string placeHolder, object value)
        {
            cmd.Parameters.AddWithValue(placeHolder, value);
        }

        public DataTable ExecuteDataAdapterQuery()
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public SqlDataReader GetDataReader()
        {
            if (conn.State == ConnectionState.Open)
            {
                return cmd.ExecuteReader();
            }
            else
            {
                return null;
            }
        }

        public int ExecuteNonQuery()
        {
            return cmd.ExecuteNonQuery();
        }
    }
}