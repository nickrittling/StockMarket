using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Market.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int StockID { get; set; }
        public int StockAmount { get;set; }
        public double TransactionPrice { get; set; }
        public string dateTime { get; set; }
        public Transaction(int id, int userID, int stockID, int stockAmount, double transactionPrice, string dateTime)
        {
            Id = id;
            UserID = userID;
            StockID = stockID;
            StockAmount = stockAmount;
            TransactionPrice = transactionPrice;
            this.dateTime = dateTime;
        }

    }
}