using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Faculty_Search : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    SqlConnection cn = new SqlConnection(con);
    SqlCommand SQL_cmd = new SqlCommand();
    
    void sql_searchbynameandenroll(string searchterms)
    {
        SqlCommand cmd = new SqlCommand("select Student_Id,Enrollment_Number,Student_Name FROM tbl_student_info WHERE B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE College_id IN (SELECT Time_Table_Id FROM tbl_time_table WHERE Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Username"] + "') AND (Student_Name LIKE '%" + searchterms + "%' OR Enrollment_Number LIKE '%" + searchterms +"%'))", cn);
     
    }

    void sql_persentage(int persentage)
    {

    }

    void college_search(string department,string branch,string semester,string batch)
    {
        SqlCommand cmd = new SqlCommand("select Student_Id,Enrollment_Number,Student_Name FROM tbl_student_info A,tbl_time_table B WHERE B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE College_id IN (SELECT Time_Table_Id FROM tbl_time_table WHERE Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Username"] + "' ");
    }



    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Faculty_Username"] != null)
            {

                SQL_cmd = new SqlCommand("SQL_STUDENT_INFO_FOR_EMPLOYEE_SEARCH", cn);
                SQL_cmd.CommandType = CommandType.StoredProcedure;
                SQL_cmd.Parameters.Add("@Employee_Email", SqlDbType.VarChar).Value = Session["Faculty_Username"];
                SQL_cmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = txtsearchterms.Text;
                SQL_cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = 1;
                cn.Open();
                SqlDataReader dr = SQL_cmd.ExecuteReader();

                StudentInfoGridView.DataSource = dr;
                StudentInfoGridView.DataBind();
                cn.Close();
                SQL_cmd.Dispose();
                dr.Dispose();


            }
            else
            {
                Response.Redirect("/Login.aspx");
            }

        }



    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SQL_STUDENT_INFO_FOR_EMPLOYEE_SEARCH", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cmd.Parameters.Add("@Employee_Email", SqlDbType.VarChar).Value = Session["Faculty_Username"];
        cmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = txtsearchterms.Text;
        SqlDataReader dr=null;
        if(category.SelectedIndex==0)
        {
            cmd.Parameters.Add("@Category", SqlDbType.Int).Value = 3;
            dr = cmd.ExecuteReader();
            
        }
        else if (category.SelectedIndex == 1)
        {
            cmd.Parameters.Add("@Category", SqlDbType.Int).Value = 2;
            dr = cmd.ExecuteReader();
        }
        StudentInfoGridView.DataSource = dr;
        StudentInfoGridView.DataBind();
        cn.Close();
    }
    protected void StudentInfoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string Choosen_Enroll = StudentInfoGridView.Rows[int.Parse((e.CommandArgument).ToString())].Cells[1].Text;
        Response.Redirect("Student_Info.aspx?Enroll="+ Choosen_Enroll);
    }
}