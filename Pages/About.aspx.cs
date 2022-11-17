using Stock_Market.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market
{
    public partial class About : Page
    {
        SqlConnections data;
        protected void Page_Load(object sender, EventArgs e)
        {
          data = new SqlConnections();
          SelectStock();
        }
        public void SelectStock()
        {
            string sql = "SELECT [Symbol], [StockName], [CurrentPrice] FROM [Stocks] WHERE [Stocks].Symbol ='"+ SqlConnections.CurrentStockSymbol+"';";
            msg.Text=sql;   
            DataSet ds = data.ExecuteSelect(sql);
            GridView.DataSource = ds;
            GridView.DataBind();



        }


        public void Buy()
        {
            msg.Text = "You dont have enought funds!!!";
        }
        public void Sell()
        {
            msg.Text = "You sold X stocks !!!";
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColorList.SelectedValue == "Buy")
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
    }
}