using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Script.Services;
public partial class Admin_facultyadd : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
  public static  SqlConnection cn = new SqlConnection(con);
    public static DataTable Emp_Dt;

    public void Emp_Dt_Load()
    {
        Emp_Dt.Columns.Add("");



    }





    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["Username"] != null)
            {
                SqlCommand cmd = new SqlCommand("SELECT Department_Name FROM DEPARTMENT_INFO", cn);
                cn.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader DR;
                DR = cmd.ExecuteReader();
                department.DataSource = DR;
                department.DataValueField = "Department_Name";
                department.DataTextField = "Department_Name";
                department.DataBind();

                cn.Close();
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
            
        }
        
    }
    protected void btnregister_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("SQL_ADD_FACULTY", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EMPLOYEE_NAME",SqlDbType.VarChar).Value=txtfacultyname.Text;
        cmd.Parameters.Add("@DEPARTMENT_NAME",SqlDbType.VarChar).Value=department.Text;
        cmd.Parameters.Add("@EMAIL",SqlDbType.VarChar).Value=txtemail.Text;
        cmd.Parameters.Add("@Category", SqlDbType.SmallInt).Value = Category.SelectedIndex + 1;
        cn.Open();
        int i = cmd.ExecuteNonQuery();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
    public static List<Emp_Details> Search_faculty(string searchterms)
    {
        List<Emp_Details> emp = new List<Emp_Details>();

        SqlDataAdapter da = new SqlDataAdapter("SELECT Employee_Name,Department_Name FROM tbl_employee_info WHERE Employee_Name LIKE '%" + searchterms + "%'", cn);
        DataTable dt = new DataTable();
        cn.Open();
        da.Fill(dt);

        int t = dt.Rows.Count;

        foreach(DataRow dtrow in dt.Rows)
        {
            Emp_Details obj = new Emp_Details();
            obj.Department_Name = dtrow["Department_Name"].ToString();
            obj.Employee_Name = dtrow["Employee_Name"].ToString();
            emp.Add(obj);
        }

        cn.Close();
        return emp;
    }


    public class Emp_Details
    {
        public string Employee_Name;
        public string Department_Name;
    }
    

}