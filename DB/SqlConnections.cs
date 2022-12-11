using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Stock_Market.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace Stock_Market.DB
{
    public class SqlConnections
    {
        public static Stock currentStock = new Stock();
        public static User currentUser = new User();
        public static string CurrentStockSymbol = null;
        private SqlConnection conn;

        public static double pricelimit { get; internal set; }

        public SqlConnections()
        {
            conn = new SqlConnection();

            conn.ConnectionString = "Server=ss.cs.luc.edu;uid=nrittling;pwd=p02372;" +
                  "Initial Catalog=Market";
            conn.Open();
            currentUser.Id = 3; // THIS MUST COME FROM SIGN UP FORM
            ReturnUser();

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

        public void ReturnUser()
        {
            string sql = "SELECT * from Users Where Id = " + currentUser.Id + "; ";
            DataSet user = ExecuteSelect(sql);
            currentUser.FirstName = Convert.ToString(user.Tables[0].Rows[0][1]);
            currentUser.LastName = Convert.ToString(user.Tables[0].Rows[0][2]);
            currentUser.Funds = Convert.ToDouble(user.Tables[0].Rows[0][3]);

        }

        public void InsertTransaction(Transaction tr)
        {       
            string sql = " SET IDENTITY_INSERT Transactions ON INSERT INTO Transactions(TransactionId, UserID, StockID, StockAmount, Price, Trade)" +
                " Values("+ tr.Id+" ," + tr.UserID + "," + tr.StockID + "," + tr.StockAmount + "," + tr.TransactionPrice + ",'"+tr.Trade+"');";
            int result = ExecuteAction(sql);

        }

        

         
    }
}


