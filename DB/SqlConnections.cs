using Stock_Market.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Stock_Market.DB
{
    public class SqlConnections
    {
        public static string CurrentStockSymbol = null;
        private SqlConnection conn;

        public SqlConnections()
        {
            conn = new SqlConnection();

            conn.ConnectionString = "Server=ss.cs.luc.edu;uid=nrittling;pwd=p02372;" +
                  "Initial Catalog=Market";
            conn.Open();

        }
        public DataSet ExecuteSelect(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int ExecuteAction(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            int result = command.ExecuteNonQuery();

            return result;
        }
    }
}