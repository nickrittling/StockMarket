using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Stock_Market.Account
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Register_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Users values (@FirstName, @LastName, @Funds, @EMAIL, @PASSWORD)", con);
            cmd.Parameters.AddWithValue("FirstName", FnameTxt.Text);
            cmd.Parameters.AddWithValue("LastName", LnameTxt.Text);
            cmd.Parameters.AddWithValue("Email", Email.Text);
            cmd.Parameters.AddWithValue("Password", Password.Text);
            var fund = Convert.ToDecimal(FundsText.Text);
            cmd.Parameters.AddWithValue("Funds", fund); 
            cmd.ExecuteNonQuery();
            Label7.Visible = true;
            Label7.Text = "User registered successfully";
            FnameTxt.Text = "";
            LnameTxt.Text = "";
            Email.Text = "";
            Password.Text = "";
            FnameTxt.Focus();
            Response.Redirect("~/Default.aspx");
        }
    }
}