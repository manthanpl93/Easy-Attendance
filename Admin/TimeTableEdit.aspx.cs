using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_TimeTableEdit : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    SqlConnection cn = new SqlConnection(con);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] != null)
            {
              
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }

        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SQL_PERIOD_ADD", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PERIOD_NAME",SqlDbType.VarChar).Value=txtperiodnumber.Text;
        cmd.Parameters.Add("@TIME_FROM",SqlDbType.Time).Value=txttimefrom.Text;
        cmd.Parameters.Add("@TIME_TO",SqlDbType.Time).Value=txttimeto.Text;
        cn.Open();
        string i=cmd.ExecuteScalar().ToString();
        if(i=="0")
        {

        }
        else if(i=="1")
        {

        }
        else
        {

        }
    }
}