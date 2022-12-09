using Stock_Market.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market
{
    public partial class _Default : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            date.Text = dateTime.ToString("dd/MM/yyyy");
        }
        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);


            GridViewRow selectedRow = GridView1.Rows[index];
            TableCell stockName = selectedRow.Cells[0];
            string currectStock = stockName.Text;

            SqlConnections.CurrentStockSymbol = currectStock;
            if (e.CommandName == "Trade")
            { 
                Response.Redirect("/Pages/SelectedStock");
            }
            else
            {
                Response.Redirect("/Pages/SetUpLimit");
            }

        }
    }
}