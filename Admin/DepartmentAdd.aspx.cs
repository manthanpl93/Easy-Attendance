using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class Admin_DepartmentAdd : System.Web.UI.Page
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
    protected void btnregister_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SQL_ADD_DEPARTMENT", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cmd.Parameters.Add("@DEPARTMENT_NAME", SqlDbType.VarChar).Value = txtdepartmentname.Text;
        cmd.Parameters.Add("@BRANCH",SqlDbType.VarChar).Value=txtbranch.Text;
        cmd.Parameters.Add("@SEMESTER",SqlDbType.VarChar).Value=txtsemster.Text;
        cmd.Parameters.Add("@BATCH",SqlDbType.VarChar).Value=txtbatch.Text;
        int i = cmd.ExecuteNonQuery();
        if(i>0)
        {
           
        }
        cn.Close();
    }
}