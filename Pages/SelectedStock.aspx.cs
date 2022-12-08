﻿using Microsoft.AspNet.Identity;
using Stock_Market.DB;
using Stock_Market.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace Stock_Market
{
    public partial class About : Page
    {
        SqlConnections data;
        Stock currentStock = new Stock();
        double totalCost = 0;
        int NumberShares;
        bool trading = true;
        DBLocal localDB;
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
          data = new SqlConnections();
          localDB = new DBLocal();
          SelectStock();

        }
        public void SelectStock()
        {
            string sql = "SELECT [Id], [Symbol], [StockName], [CurrentPrice] FROM [Stocks] WHERE [Stocks].Symbol ='"+ SqlConnections.CurrentStockSymbol+"';"; 
            DataSet ds = data.ExecuteSelect(sql);
            currentStock.CurrentPrice = Convert.ToDouble(ds.Tables[0].Rows[0][3]);// price from the table
            currentStock.Id = Convert.ToInt32(ds.Tables[0].Rows[0][0]); 
            GridView.DataSource = ds;
            GridView.DataBind();

        }


        public void Buy()
        {
            if(SqlConnections.currentUser.Funds < totalCost)
            {
                msg.Text = "You don't have enough funds !";
            }
            else
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                string td = dateTime.ToString("dd/MM/yyyy");
                Transaction buyingStock = new Transaction

                (2, SqlConnections.CurrentUserId, currentStock.Id,
                NumberShares, currentStock.CurrentPrice, td);
                data.InsertTransaction(buyingStock);
                updateUserFund();
                msg.Text = "Congratulation, you bought " + NumberShares+" of "+currentStock.Symbol+" spending "+ totalCost;

                Response.Redirect("/Pages/Contact");

            }
            
        }
        public void updateUserFund()// BUYING
        {
            totalCost = Convert.ToDouble(Convert.ToInt32(amount.Text) * currentStock.CurrentPrice);
            double userNewFunds = SqlConnections.currentUser.Funds - totalCost;
            string sql = "SET IDENTITY_INSERT Transactions ON Update Users Set Funds =" + userNewFunds + " WHERE Id = " + SqlConnections.CurrentUserId + ";";

            data.ExecuteAction(sql);
        }

       
        public void Sell()
        {
            NumberShares = int.Parse(amount.Text);
            // find in transaction table current user and current stock
            if (localDB.FindStock(currentStock.Id)< NumberShares)
            {
                msg.Text = "You don't have enought shares to sell";
            }
            else
            {
                // make transaction WITH NEGATIVE NUMBER!!
                // update funds
            }
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)

        {
            totalCost = Convert.ToDouble(amount.Text)*currentStock.CurrentPrice;// calculate total price
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

        public void checkFunds()
        {
            
        }
    }
}

