using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class Login : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    SqlConnection cn = new SqlConnection(con);
    protected void Page_Load(object sender, EventArgs e)
    {
        var LogoutStatus = Request.QueryString["logout"];

        if(LogoutStatus=="1")
        {
            Session.Clear();
        }


    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SQL_LOGIN", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@USERNAME",SqlDbType.VarChar).Value=txtusername.Text;
        cmd.Parameters.Add("@PASSWORD",SqlDbType.VarChar).Value=txtpassword.Text;
        cn.Open();
        string User = cmd.ExecuteScalar().ToString();
       
        cn.Close();
        if(User=="1")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Username And Password Incoorect')</script>");
        }
        else
        {
           
            if(User=="ADMIN")
            {
                Session["Username"] = txtusername.Text;
                Response.Redirect("/Admin/facultyadd.aspx");
            }
            else if(User=="FACULTY")
            {
                Session["Faculty_Username"] = txtusername.Text;
                Response.Redirect("/Faculty/TakeAttandance.aspx");
            }
            else if(User=="STUDENT")
            {
                Session["Student_Username"] = txtusername.Text;
                Response.Redirect("/Student/Profile.aspx");
            }

            else if (User == "PRINCIPLE")
            {
                Session["User_Principle"]=txtusername.Text;
                Response.Redirect("/Principle/Search.aspx");
            }
        }
    }
}