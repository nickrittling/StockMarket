using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;


namespace Stock_Market.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where EMAIL =@EMAIL and PASSWORD=@PASSWORD", con);
            cmd.Parameters.AddWithValue("@EMAIL", TextBox1.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", TextBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["UserID"] = "Annathurai";
                userInfo["UserColor"] = "Black";
                userInfo.Expires.Add(new TimeSpan(0, 1, 0));
                Response.Cookies.Add(userInfo);
                Response.Redirect("~/Default.aspx");

            }

            else
            {

                Label3.Visible = true;
                Label3.Text = "Wrong Details";
            }
        }
    }
}