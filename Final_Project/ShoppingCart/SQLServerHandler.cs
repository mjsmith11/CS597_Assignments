using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ShoppingCart
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

        /// <summary>
        /// The query result must contain all columns of the Book Table
        /// This method does not check this and will fail with an exception if any are missing
        /// </summary>
        /// <returns></returns>
        public List<Book> ExecuteBookListQuery()
        {
            DataTable qryResult = ExecuteDataAdapterQuery();
            List<Book> result = new List<Book>();

            foreach (DataRow dr in qryResult.Rows)
            {
                Book b = new Book();
                b.BookId = Int32.Parse(dr["BookId"].ToString());
                b.BookName = dr["BookName"].ToString();
                b.Author = dr["Author"].ToString();
                b.price = Double.Parse(dr["Price"].ToString());
                b.numInStock = Int32.Parse(dr["NumInStock"].ToString());
                result.Add(b);

            }
            return result;
        }

        /// <summary>
        /// The query result must all columns of the user table
        /// This method does not check this and will fail with an exception if any are missing
        /// </summary>
        /// <returns></returns>
        public List<User> ExecuteUserListQuery()
        {
            DataTable qryResult = ExecuteDataAdapterQuery();
            List<User> result = new List<User>();

            foreach (DataRow dr in qryResult.Rows)
            {
                User u = new User();
                u.userId = Int32.Parse(dr["UserId"].ToString());
                u.login = dr["Login"].ToString();
                u.password = dr["Password"].ToString();
                u.name = dr["Name"].ToString();

                result.Add(u);
            }
            return result;
        }

        /// <summary>
        /// The query result must all columns of the CartItem table
        /// This method does not check this and will fail with an exception if any are missing
        /// </summary>
        /// <returns></returns>
        public List<CartItem> ExecuteCartItemListQuery()
        {
            DataTable qryResult = ExecuteDataAdapterQuery();
            List<CartItem> result = new List<CartItem>();

            foreach (DataRow dr in qryResult.Rows)
            {
                CartItem ci = new CartItem();
                ci.Id = Int32.Parse(dr["Id"].ToString());
                ci.Book_Id = Int32.Parse(dr["Book_Id"].ToString());
                ci.User_Id = Int32.Parse(dr["User_Id"].ToString());
                ci.Quantity = Int32.Parse(dr["Quantity"].ToString());

                result.Add(ci);
            }
            return result;
        }
    }
}