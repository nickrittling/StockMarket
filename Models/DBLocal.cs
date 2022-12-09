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
        readonly SqlConnections data = new SqlConnections();
        public static string currentTrade;

   

        public DBLocal()
        {
            
            RetriveCurrectUserStocks();  
        }


        public void RetriveCurrectUserStocks()
        {
            string sql = " select UserID, StockID, SUM(StockAmount) as StocksTotal From Transactions Where UserID = " +
                SqlConnections.currentUser.Id + "GROUP BY  UserID, StockID;";
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
    }
}