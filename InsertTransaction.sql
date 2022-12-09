select UserID,StockID,SUM(StockAmount) as StocksTotal From Transactions
 WHere UserID = 1
 GROUP BY  UserID, StockID;
