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

        /// <summary>
        /// The query result must contain CRN, CourseNumber, SectionNumber, Days, StartTime, and EndTime.
        /// This method does not check this and will fail with an exception if any are missing
        /// </summary>
        /// <returns></returns>
        public List<Course> ExecuteCourseListQuery()
        {
            DataTable qryResult = ExecuteDataAdapterQuery();
            List<Course> result = new List<Course>();

            foreach(DataRow dr in qryResult.Rows)
            {
                int CRN = Int32.Parse(dr["CRN"].ToString());
                string courseNumber = dr["CourseNumber"].ToString();
                string sectionNumber = dr["SectionNumber"].ToString();
                string days = dr["Days"].ToString();
                string startTime = dr["StartTime"].ToString();
                string endTime = dr["EndTime"].ToString();

                result.Add(new Course(CRN, courseNumber, sectionNumber, days, startTime, endTime));
            }
            return result;
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