using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
public partial class WebServices_Present_Status : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    SqlConnection cn = new SqlConnection(con);
   public static string a;
   string s;


   public static string Message()
   {
       return "Hello from the server-side World!";
   }


    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlCommand cmd = new SqlCommand("SQL_STUDENT_ATTANDANCE_UPDATE", cn);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@AttendanceId",SqlDbType.Int).Value=Request.QueryString["Id"];
        //cmd.Parameters.Add("@STATUS", SqlDbType.Bit).Value = Request.QueryString["Sid"];
        //cn.Open();
        //string status = cmd.ExecuteNonQuery().ToString();
        //cn.Close();
    
    
    }
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
       
    }

    public static string manthan_1()
    {

        return "manthan";   
    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        s = a;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('"+ s +"')</script>");
    }
}