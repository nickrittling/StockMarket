using Stock_Market.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock_Market.DB;
using System.Data;
using System.Web.Services.Description;

namespace Stock_Market
{
    public partial class SetUpLimit : Page
    {
        SqlConnections sqlCon = new SqlConnections();
       
            SqlConnections data;
            double totalCost;
            int NumberShares;
            DBLocal localDB;
            DateTime dateTime = DateTime.Now;


            protected void Page_Load(object sender, EventArgs e)
            {
                data = new SqlConnections();
                localDB = new DBLocal();
                SelectStock();

            }
            public void SelectStock()
            {
                string sql = "SELECT [Id], [Symbol], [StockName], [CurrentPrice] FROM [Stocks] WHERE [Stocks].Symbol ='" + SqlConnections.CurrentStockSymbol + "';";
                DataSet ds = data.ExecuteSelect(sql);
                SqlConnections.currentStock.CurrentPrice = Convert.ToDouble(ds.Tables[0].Rows[0][3]);// price from the table
                SqlConnections.currentStock.Id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                GridView.DataSource = ds;
                GridView.DataBind();
        }

            public void Buy()
            {
                totalCost = Convert.ToDouble(Convert.ToInt32(amount.Text) * SqlConnections.currentStock.CurrentPrice);
                double userNewFunds = SqlConnections.currentUser.Funds - totalCost;
                double pricelimit = Convert.ToDouble(limitPrice.Text);


            if (SqlConnections.currentUser.Funds < totalCost)
                {
                    msg.Text = "<font style='background : lightblue; padding:30px ; border-radius:20px;font-weight: bold;'> You don't have enough funds ! </font>";

            }
                else
                {
                string td = dateTime.ToString("dd/MM/yyyy");
                Transaction buyingStock = new Transaction
                (SqlConnections.currentUser.Id, SqlConnections.currentStock.Id,
                NumberShares, pricelimit, td, "Pending");

                data.InsertTransaction(buyingStock);

                updateUserFund(userNewFunds);
                //Display transaction info
                msg.Text = "<font style='background : lightgreen; padding:30px ; border-radius:20px; font-weight: bold;'>" + "You set a limit order to buy  " +
                +NumberShares + " shares of " + SqlConnections.CurrentStockSymbol + "for " + pricelimit + "$ each </font>";
            }

            }
            public void updateUserFund(double userNewFunds)
            {
                string sql = "SET IDENTITY_INSERT Transactions ON Update Users Set Funds =" + userNewFunds + " WHERE Id = " + SqlConnections.currentUser.Id + ";";
                data.ExecuteAction(sql);
            }


            public void Sell()
            {
                totalCost = Convert.ToDouble(Convert.ToInt32(amount.Text) * SqlConnections.currentStock.CurrentPrice);
                double userNewFunds = SqlConnections.currentUser.Funds + totalCost;
                double pricelimit = Convert.ToDouble(limitPrice.Text);

                string td = dateTime.ToString("dd/MM/yyyy");
                NumberShares = int.Parse(amount.Text);

              
                if (localDB.FindStock(SqlConnections.currentStock.Id) < NumberShares)
                {
                  msg.Text = "<font style='background : lightblue; padding:30px ; border-radius:20px;font-weight: bold;'>You don't have enought shares to sell! </font>";
                }
                else
                {
                Transaction sellingStock = new Transaction

               (SqlConnections.currentUser.Id, SqlConnections.currentStock.Id,
               -NumberShares, pricelimit, td, "Pending");

                data.InsertTransaction(sellingStock);

                updateUserFund(userNewFunds);

                msg.Text = "<font style='background : lightgreen; padding:30px ; border-radius:20px; font-weight: bold;'>" + "You set a limit order to sell  "+                  
                    + NumberShares + " shares of " + SqlConnections.CurrentStockSymbol +"for "+ pricelimit + "$ each </font>";
            }
            }

            protected void SelectedIndexChanged(object sender, EventArgs e)

            {
            try {
                totalCost = Convert.ToDouble(amount.Text) * SqlConnections.currentStock.CurrentPrice;// calculate total price
                total.Text = Convert.ToString(totalCost);//display it
            }
            catch  {
                msg.Text = "Enter a price limit";
            }

                if (ActionList.SelectedValue == "Buy")
                {
                    DBLocal.currentTrade = "Buy";
                }
                else if (ActionList.SelectedValue == "Sell")
                {
                    DBLocal.currentTrade = "Sell";
                }

            }

            protected void Submit_Click(object sender, EventArgs e)
            {
            try
            {
                NumberShares = int.Parse(amount.Text);
            }
            catch
            {
                msg.Text = "Enter the limit";
            }
            // assign number shares
                if (DBLocal.currentTrade == "Buy")
                {
                    Buy();
                }
                else if (DBLocal.currentTrade == "Sell")
                {
                    Sell();
                }
                else
                {
                msg.Text = "<font style='background : lightred; padding:30px ; border-radius:20px;'>Didn't select type of trade </font>";
            }
            }
        }
    }