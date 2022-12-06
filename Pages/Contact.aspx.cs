using Stock_Market.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock_Market.DB;

namespace Stock_Market
{
    public partial class Contact : Page
    {
        SqlConnections sqlCon = new SqlConnections();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userInfo = SqlConnections.currentUser.FirstName + " " + SqlConnections.currentUser.LastName + " " + SqlConnections.currentUser.Funds;
            curUser.Text = userInfo;
            //User cUser = new User();
            //cUser.FirstName = sqlCon.ReturnUser();
            //curUser.Text= cUser.FirstName;
        }
    }
}