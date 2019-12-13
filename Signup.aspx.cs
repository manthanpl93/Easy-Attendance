using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
public partial class Signup : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    SqlConnection cn= new SqlConnection(con);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("SELECT Branch FROM DEPARTMENT_INFO", cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            branch.DataSource = dr;
            branch.DataValueField = "Branch";
            branch.DataTextField = "Branch";
            branch.DataBind();
            cn.Close();
            cn.Open();
            cmd.CommandText = "SELECT Semester FROM DEPARTMENT_INFO GROUP BY Semester";
            dr = cmd.ExecuteReader();
            semester.DataSource = dr;
            semester.DataValueField = "Semester";
            semester.DataTextField = "Semester";
            semester.DataBind();
            cn.Close();
            cn.Open();
            cmd.CommandText = "SELECT Batch FROM DEPARTMENT_INFO GROUP BY Batch";
            dr = cmd.ExecuteReader();
            batch.DataSource = dr;
            batch.DataValueField = "Batch";
            batch.DataTextField = "Batch";
            batch.DataBind();
            cn.Close();
            cn.Open();
            cmd.CommandText = "SELECT Department_Name FROM DEPARTMENT_INFO";
            dr = cmd.ExecuteReader();
            department.DataSource = dr;
            department.DataValueField = "Department_Name";
            department.DataTextField = "Department_Name";
            department.DataBind();
            cmd.Dispose();
            dr.Dispose();
            cn.Close();
        }

        
    }
    protected void btnsignup_Click(object sender, EventArgs e)
    {
         SqlCommand cmd = new SqlCommand("SQL_ADD_STUDENT_INFO", cn);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.Add("@Student_Name",SqlDbType.VarChar).Value=txtstudentname.Text;
         cmd.Parameters.Add("@Enroll_Number",SqlDbType.VarChar).Value=txtenrollmentnumber.Text;
         cmd.Parameters.Add("@Department_Name", SqlDbType.VarChar).Value = department.SelectedValue.ToString();
         cmd.Parameters.Add("@Branch",SqlDbType.VarChar).Value=branch.Text;
         cmd.Parameters.Add("@Semester", SqlDbType.VarChar).Value = semester.SelectedValue.ToString();
         cmd.Parameters.Add("@Batch", SqlDbType.VarChar).Value = batch.SelectedValue.ToString();
         cmd.Parameters.Add("@PASSWORD",SqlDbType.VarChar).Value="12345";
         cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtemailaddress.Text;
         cn.Open();
         string i=cmd.ExecuteScalar().ToString();

        if(i=="0")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Invalid College Information')</script>");
        }
        else if(i=="1")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Registration Sucessfully')</script>");
        }
        else if (i == "2")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Enrollment Number Allready Exists , Contect Sysytem Administator')</script>");
        }
        else if(i=="4")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong Operation , User Not Valid .')</script>");
        }
         cn.Close();
    }
}