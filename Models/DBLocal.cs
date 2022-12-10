using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;
using Stock_Market.Models;

namespace Stock_Market.DB
{

    public class DBLocal
    {
       
        List < Transaction > localTransactionsDB = new List<Transaction>();
        Dictionary <int, int> currectUserStocks = new Dictionary<int, int>(); //Save stock id and number of stocks
        Dictionary<int, Transaction> pendingOrders = new Dictionary<int, Transaction>();
        

        readonly SqlConnections data = new SqlConnections();
        public static string currentTrade;
        public static double pricelimit {get; set;} 




        public DBLocal()
        {
            
            RetriveCurrectUserStocks();  
            //FindLimits();   
        }


        public void RetriveCurrectUserStocks()
        {
            string sql = " select UserID, StockID, SUM(StockAmount) as StocksTotal From Transactions Where UserID = " +
                SqlConnections.currentUser.Id + "AND Trade != 'Pending' GROUP BY  UserID, StockID;";
                DataSet ds =   data.ExecuteSelect(sql);

                if (ds != null){

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++){
                    int StockId = (int)ds.Tables[0].Rows[i][1];
                    int NumberStocks = (int)ds.Tables[0].Rows[i][2];
                    currectUserStocks.Add(StockId, NumberStocks);
                     }
                }
        }

        public int FindStock(int StockId)
        {
            if (currectUserStocks.ContainsKey(StockId))
            {
                return currectUserStocks[StockId];
            }
            else
            {
                return 0;
            }
        } 
        
        public void FindLimits()
        {
            string sql = " select  StockID,Sum(StockAmount) as Total,Price From Transactions Where UserID = " +
            SqlConnections.currentUser.Id + "AND Trade = 'Pending' GROUP BY  UserID;";
            DataSet ds = data.ExecuteSelect(sql);

            // amount 
            //price limit
            //stock id = must be compared to currenct stock number

            if (ds != null)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int StockId = (int)ds.Tables[0].Rows[i][0];
                    int NumberStocks = (int)ds.Tables[0].Rows[i][1];
                    double price = (double)ds.Tables[0].Rows[i][2];// Limit price
                    if (StockId == SqlConnections.currentStock.Id)
                    {
                        Transaction tr = new Transaction(SqlConnections.currentStock.Id, NumberStocks, price, "pending");
                        pendingOrders.Add(StockId, tr);

                    }

                }
            }

        }
        public Transaction FindPendingOrder(int StockId)
        {
            if (pendingOrders.ContainsKey(StockId))
            {
                return pendingOrders[StockId];
            }
            else
            {
                return null;
            }
        }
    }
}