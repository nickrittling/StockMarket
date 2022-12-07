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
            SqlConnections data = new SqlConnections();

        }
        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            // If multiple ButtonField column fields are used, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Trade")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell stockName = selectedRow.Cells[0];
                string currectStock= stockName.Text;

                SqlConnections.CurrentStockSymbol = currectStock;

                Response.Redirect("/Pages/SelectedStock");



            }

        }
    }
}