using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommonDB
    {
        private string connectionString;

        protected string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public CommonDB(string constring)
        {
            ConnectionString = constring;
        }
        /// <summary>
        /// Inserts data into the database using the SQL query
        /// </summary>
        /// <param name="queryString">Query string</param>
        /// <returns>Returns the amount of rows affected in the process</returns>
        protected int InsertDataToDB(string queryString)
        {
            int rowsAffected = 0;

            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                using (SqlCommand com = new SqlCommand(queryString, c))
                {
                    rowsAffected = com.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        /// <summary>
        /// Gets data from the database using the SQL query
        /// </summary>
        /// <param name="queryString">Query string</param>
        /// <returns>Returns a dataset of the data selected from the database</returns>
        protected DataSet SelectDataFromDB(string queryString)
        {
            DataSet ds = new DataSet();
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, c))
                {
                    adapter.Fill(ds);
                }
            }
            return ds;
        }
    }
}
