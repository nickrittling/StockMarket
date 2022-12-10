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

<<<<<<< Updated upstream
            conn.ConnectionString = "Server=ss.cs.luc.edu;uid=nrittling;pwd=;" +
=======
            conn.ConnectionString = "Server=ss.cs.luc.edu;uid=nrittling;pwd=p02372;" +
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

        public void ReturnUser()
        {
            string sql = "SELECT * from Users Where Id = " + currentUser.Id + "; ";
            DataSet user = ExecuteSelect(sql);
            currentUser.FirstName = Convert.ToString(user.Tables[0].Rows[0][1]);
            currentUser.LastName = Convert.ToString(user.Tables[0].Rows[0][2]);
            currentUser.Funds = Convert.ToDecimal(user.Tables[0].Rows[0][3]);

        }

        public void InsertTransaction(Transaction tr)
        {       
            string sql = " SET IDENTITY_INSERT Transactions ON INSERT INTO Transactions(TransactionId, UserID, StockID, StockAmount, Price, Trade)" +
                " Values("+ tr.TransactionId+" ," + tr.UserID + "," + tr.StockID + "," + tr.StockAmount + "," + tr.Price + ",'"+tr.Trade+"');";
            int result = ExecuteAction(sql);

        }

        

         
>>>>>>> Stashed changes
    }
}