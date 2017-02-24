using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace CS597_Midterm_Project_Exam
{
    public class OleDbHandler
    {
        private OleDbConnection conn;
        private OleDbCommand cmd;

        public OleDbHandler(string connectionStringId)
        {
            conn = new OleDbConnection(ConfigurationManager.ConnectionStrings[connectionStringId].ConnectionString);
        }

        public void CreateCommand(string query)
        {
            cmd = new OleDbCommand(query, conn);
        }

        public void AddParameter(string placeHolder, object value)
        {
            cmd.Parameters.AddWithValue(placeHolder, value);
        }

        public DataTable ExecuteDataAdapterQuery()
        {
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
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

        public OleDbDataReader GetDataReader()
        {
            if(conn.State == ConnectionState.Open)
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