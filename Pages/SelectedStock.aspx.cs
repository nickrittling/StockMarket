using Microsoft.AspNet.Identity;
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
        int NumberShares = 0;
        

       

        protected void Page_Load(object sender, EventArgs e)
        {
          data = new SqlConnections();
          SelectStock();
        }
        public void SelectStock()
        {
            string sql = "SELECT [Symbol], [StockName], [CurrentPrice] FROM [Stocks] WHERE [Stocks].Symbol ='"+ SqlConnections.CurrentStockSymbol+"';"; 
            DataSet ds = data.ExecuteSelect(sql);
            currentStock.CurrentPrice = Convert.ToDouble(ds.Tables[0].Rows[0][3]);
            currentStock.Symbol= Convert.ToString(ds.Tables[0].Rows[0][1]);
            GridView.DataSource = ds;
            GridView.DataBind();
            
         }

        public void Trade()
        {
            while
        }

        public void Buy()
        {
            if(SqlConnections.currentUser.Funds < totalCost)
            {
                msg.Text = "You don't have enough funds !";
            }
            else
            {
                DateTime today = new DateTime();
                Transaction buyingStock = new Transaction
                (1, SqlConnections.CurrentUserId,currentStock.Id,
                NumberShares, currentStock.CurrentPrice,today);
                data.InsertTransaction(buyingStock);    

            }

            
        }
        public void Sell()
        {
           
            msg.Text = "You sold X stocks !!!";
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)

        {
            totalCost = Int32.Parse(total.Text);
            if (ActionList.SelectedValue == "Buy")

            {
                Buy();
            }
            else
            {
                Sell();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {


        }

        public void checkFunds()
        {
            
        }
    }
}

