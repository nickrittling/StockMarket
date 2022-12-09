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
                //total.Text = "0.00";
                //amount.Text = "0.00";

        }


        public void Limits()
        {
           // string sql 
           // find user transactions with status "pending for the selected stock
           // allow delete the limit and return withdrawn money

        }


            public void Buy()
            {
                totalCost = Convert.ToDouble(Convert.ToInt32(amount.Text) * SqlConnections.currentStock.CurrentPrice);
                double userNewFunds = SqlConnections.currentUser.Funds - totalCost;
                

                if (SqlConnections.currentUser.Funds < totalCost)
                {
                    msg.Text = "You don't have enough funds !";
                
            }
                else
                {
                    //string td = dateTime.ToString("dd/MM/yyyy");
                    //Transaction buyingStock = new Transaction

                    //(SqlConnections.currentUser.Id, SqlConnections.currentStock.Id,
                    //NumberShares, SqlConnections.currentStock.CurrentPrice, td, "Pending");
                    //data.InsertTransaction(buyingStock);
                    //updateUserFund(userNewFunds);
                    msg.Text = "Congratulation, you set the limit to buy " + NumberShares + "shares of " + SqlConnections.CurrentStockSymbol + " spending " + totalCost + " $";

                    //  Response.Redirect("/Pages/Contact");

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

                string td = dateTime.ToString("dd/MM/yyyy");
                NumberShares = int.Parse(amount.Text);
                // find in transaction table current user and current stock
                if (localDB.FindStock(SqlConnections.currentStock.Id) < NumberShares)
                {
                  //  msg.Text = "You don't have enough shares to sell";
                     msg.Text = "<font style='background : lightblue; padding:30px ; border-radius:20px;'>You don't have enought shares for sell! </font>";
            }
                else
                {
                   // Transaction sellingStock = new Transaction

                   //(SqlConnections.currentUser.Id, SqlConnections.currentStock.Id,
                   //-NumberShares, SqlConnections.currentStock.CurrentPrice, td, "Pending");

                   // data.InsertTransaction(sellingStock);
                   // updateUserFund(userNewFunds);

                    msg.Text = "Congratulation, you set the limit to sell " + NumberShares + "shares of " + SqlConnections.CurrentStockSymbol + " getting " + totalCost + " $";
                }
            }

            protected void SelectedIndexChanged(object sender, EventArgs e)

            {
            try
            {
                totalCost = Convert.ToDouble(amount.Text) * SqlConnections.currentStock.CurrentPrice;// calculate total price
                total.Text = Convert.ToString(totalCost);//display it
            }
            catch
            {
                msg.Text = "Enter the limit";
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
                    msg.Text = "Didn't select action";
                }
            }
        }
    }