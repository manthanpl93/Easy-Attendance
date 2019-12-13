using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Student_Profile : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    SqlConnection cn = new SqlConnection(con);
    public string COLLEGE_ID=null;
    public static string Notification_count = "";
    public void Refresh_Student_Info()
    {
        SqlCommand cmd = new SqlCommand("SELECT College_id FROM tbl_student_info WHERE Email='" + Session["Student_Username"] + "'", cn);
        cn.Open();
        COLLEGE_ID = cmd.ExecuteScalar().ToString();
               
        cmd = new SqlCommand("SELECT A.Student_Id,A.Student_Name,A.Enrollment_Number,A.Email,B.Department_Name,B.Branch,B.Semester,B.Batch FROM tbl_student_info A,tbl_college_classes B WHERE (A.College_id=B.College_Classes_Id AND B.College_Classes_Id=" + COLLEGE_ID + " AND A.Email='" + Session["Student_Username"] + "')", cn);
       SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);


        lblstudentname.Text = dt.Rows[0][1].ToString();
        txtstudentname.Text = dt.Rows[0][1].ToString();
        lblenrollnumber.Text = dt.Rows[0][2].ToString();
        txtenrollnumber.Text = dt.Rows[0][2].ToString();
        lblemailaddress.Text = dt.Rows[0][3].ToString();
        txtemailaddress.Text = dt.Rows[0][3].ToString();
        lbldepartment.Text = dt.Rows[0][4].ToString();
        department.Text = dt.Rows[0][4].ToString();
        lblbranch.Text = dt.Rows[0][5].ToString();
        branch.Text = dt.Rows[0][5].ToString();
        lblsemster.Text = dt.Rows[0][6].ToString();
        semester.Text = dt.Rows[0][6].ToString();
        lblbatch.Text = dt.Rows[0][7].ToString();
        batch.Text = dt.Rows[0][7].ToString();

        cn.Close();

                
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["Student_Username"]!=null)
            {

                
              SqlCommand  cmd = new SqlCommand("SELECT Branch FROM DEPARTMENT_INFO", cn);
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

                Refresh_Student_Info();

                cmd = new SqlCommand("SQL_APP_NOTIFICATION", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@STUDENT_EMAIL", SqlDbType.VarChar).Value= Session["Student_Username"];
                cn.Open();
                 Notification_count =cmd.ExecuteScalar().ToString();

                cn.Close();

                if (Notification_count == "0")
                {
                    Notification_count = "";
                }


                
            }
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SQL_CHANGE_STUDENT_INFO", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@STUDENT_NAME",SqlDbType.VarChar).Value=txtstudentname.Text;
        cmd.Parameters.Add("@ENROLL_NUMBER",SqlDbType.VarChar).Value=txtenrollnumber.Text;
        cmd.Parameters.Add("@EMAIL",SqlDbType.VarChar).Value=txtemailaddress.Text;
        cmd.Parameters.Add("@DEPARTMENT",SqlDbType.VarChar).Value= department.Text;
        cmd.Parameters.Add("@BRANCH",SqlDbType.VarChar).Value= branch.Text;
        cmd.Parameters.Add("@SEMESTER",SqlDbType.VarChar).Value=semester.Text;
        cmd.Parameters.Add("@BATCH", SqlDbType.VarChar).Value = batch.Text;
        cn.Open();
        string s = cmd.ExecuteScalar().ToString();
        cn.Close();

        if(s=="0")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Somethings Wrong Happened, Please Try Again Later')</script>");
        }
        else if(s=="1")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Record Sucessfully Updated')</script>");
            Refresh_Student_Info();
        }
    }
}