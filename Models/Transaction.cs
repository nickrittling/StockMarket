using Stock_Market.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock_Market.Models
{
    public class Transaction
    {
        public int Id { get; }
        public int UserID { get; set; }
        public int StockID { get; set; }
        public int StockAmount { get;set; }
        public double TransactionPrice { get; set; }
        public string dateTime { get; set; }
        public string Trade { get; set; }
        public Transaction( int userID, int stockID, int stockAmount, double transactionPrice, string dateTime, string trade)
        {
            Id = getID();
            UserID = userID;
            StockID = stockID;
            StockAmount = stockAmount;
            TransactionPrice = transactionPrice;
            this.dateTime = dateTime;
            this.Trade = trade;  
        }

        public int getID()
        {
            SqlConnections sc = new SqlConnections();
            string sql = "Select COUNT(*) from Transactions;";
            DataSet ds = sc.ExecuteSelect(sql);
            int Id = (int)ds.Tables[0].Rows[0][0] + 1;
            return Id;
        }

        

    }
}