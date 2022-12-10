using Microsoft.AspNet.Identity;
using Stock_Market.DB;
using Stock_Market.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace Stock_Market
{
    public partial class About : Page
    {
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
          // PendingOrders();

        }
        public void SelectStock()
        {
            string sql = "SELECT [Id], [Symbol], [StockName], [CurrentPrice] FROM [Stocks] WHERE [Stocks].Symbol = '" + SqlConnections.CurrentStockSymbol + "';";
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

            if (SqlConnections.currentUser.Funds < totalCost)
            {
                msg.Text = "<font style='background : lightblue; padding:30px ; border-radius:20px;font-weight: bold;'>You don't have enough funds ! </font>";

            }
            else
            {
                string td = dateTime.ToString("dd/MM/yyyy");
                Transaction buyingStock = new Transaction

                (SqlConnections.currentUser.Id, SqlConnections.currentStock.Id,
                NumberShares, SqlConnections.currentStock.CurrentPrice, td,"Bough");
                data.InsertTransaction(buyingStock);
                updateUserFund(userNewFunds);
                msg.Text = "<font style='background : lightgreen; padding:30px ; border-radius:20px; font-weight: bold;'>"+ "Congratulation, you bought " + NumberShares+" share of "+ SqlConnections.CurrentStockSymbol + " spending "+ totalCost+" $ </font>";

                //  Response.Redirect("/Pages/Contact");

            }
            
        }
        public void updateUserFund(double userNewFunds)// BUYING
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
            if (localDB.FindStock(SqlConnections.currentStock.Id)< NumberShares)
            {
                msg.Text = "<font style='background : lightblue; padding:30px ; border-radius:20px;font-weight: bold;'>You don't have enought shares to sell! </font>";
            }
            else
            {
                Transaction sellingStock = new Transaction

               (SqlConnections.currentUser.Id, SqlConnections.currentStock.Id,
               -NumberShares, SqlConnections.currentStock.CurrentPrice, td,"Sold");
                
                data.InsertTransaction(sellingStock);
                updateUserFund(userNewFunds);

                msg.Text = "<font style='background : lightgreen; padding:30px ; border-radius:20px; font-weight: bold;;'>"+ "Congratulation, you sold " + NumberShares + " shares of " + SqlConnections.CurrentStockSymbol + " getting " + totalCost+ " $ </font>";
            }
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)

        {
            totalCost = Convert.ToDouble(amount.Text)* SqlConnections.currentStock.CurrentPrice;// calculate total price
            total.Text = Convert.ToString(totalCost);//display it

            

            if(ActionList.SelectedValue == "Buy")
            {
                DBLocal.currentTrade = "Buy";
            }else if (ActionList.SelectedValue == "Sell")
            {
                DBLocal.currentTrade = "Sell";
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            NumberShares = int.Parse(amount.Text);// assign number shares
            if (DBLocal.currentTrade == "Buy") {
                Buy();

            } else if(DBLocal.currentTrade == "Sell") { 
                Sell(); 

            }else
            {
                msg.Text = "Didn't select action";
            }
        }

        public void PendingOrders()
        {
            // Transaction tr = localDB.FindPendingOrder(SqlConnections.currentStock.Id);
            // if (tr !=null)
            //{
            //    orderStatus.Text = "Limit Sell";
            //    quantity.Text = Convert.ToString(tr.StockAmount);
            //    price.Text = Convert.ToString(tr.TransactionPrice);

            //}
            //else
            //{
                orderStatus.Text = "Limit Sell";
                quantity.Text = Convert.ToString(NumberShares);
                price.Text = Convert.ToString(SqlConnections.pricelimit);

           // }


               
           //}

        }
    }
}

