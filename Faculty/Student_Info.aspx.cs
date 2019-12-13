using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using  System.Data;
public partial class Faculty_Student_Info : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
  public static SqlConnection cn = new SqlConnection(con);
  public static  SqlCommand SQL_cmd = new SqlCommand();
    public static string Enroll = null;
 public static DataTable dt;
 public static int attendance_id=0;

    
public static string Attendance_Html_creater(string rowindex)
{
string html = @"<div class=""editattendance"" style=""float:left;width:100%;"">
<select style=""width:50%;margin-left:25%;margin-bottom: 5px;"">
<option>Present</option>
<option>Absent</option>
</select>
<button type=""button"" style=""width: 50%;margin-left: 25%;color: white;background-color: #2a8a85;font-weight: bold;"">Edit</button>
</div>";
attendance_id = 0;
return html;
}


public static Boolean Attedance_Edit(int status)
{
    Boolean a = false;
    Boolean st=false;
  if(status==1)
    {
      //present
        st = true;
    }
    else if(status==0)
    {
        //absent
        st = false;
    }


    if(status==1 || status==0)
    {
        SQL_cmd = new SqlCommand("update tbl_attendance set Attendance_Id="+ attendance_id +" and Status=" + st + "", cn);
        int i=SQL_cmd.ExecuteNonQuery();
        if(i==1)
        {
            a = true;
        }
    }
    return a;
}


    void REFRESH_DATA()
    {
        SqlDataReader dr ;
        SQL_cmd = new SqlCommand("Student_Attandance_Status", cn);
        SQL_cmd.CommandType = System.Data.CommandType.StoredProcedure;
        SQL_cmd.Parameters.Add("@ENROLLMENT", System.Data.SqlDbType.VarChar).Value =Enroll;
        SQL_cmd.Parameters.Add("@Employee_Email", System.Data.SqlDbType.VarChar).Value = Session["Faculty_Username"];
        SQL_cmd.Parameters.Add("@SUBJECT", System.Data.SqlDbType.VarChar).Value = Subject.Text;
        cn.Open();
        lbltotalattendance.Text = SQL_cmd.ExecuteScalar().ToString() + " %";
        cn.Close();
        lblsubject.Text = Subject.Text;

        if (Status.SelectedIndex==0)
        {
            SQL_cmd = new SqlCommand("SELECT TOP 20 A.Date,C.Subject,D.Name FROM tbl_date_info A,tbl_attendance B,tbl_time_table C,tbl_attandance_status D WHERE A.Date_Id=B.Date_Id AND b.Time_Table_Id=c.Time_Table_Id AND B.Status=D.Status AND B.Student_Id=(SELECT Student_Id FROM tbl_student_info WHERE Enrollment_Number='"+ Enroll +"') AND C.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') AND C.Subject='" + Subject.Text + "' ORDER BY A.Date DESC", cn);
            cn.Open();
            dr = SQL_cmd.ExecuteReader();
            studentinfoview.DataSource = dr;
            studentinfoview.DataBind();
            cn.Close();
            
            //AND A.Date BETWEEN '"+Convert.ToDateTime(txtdate_from.Text).ToShortDateString() +"' AND '"+Convert.ToDateTime(txtdate_To.Text).ToShortDateString() +"' 
        }
        else if(Status.SelectedIndex==1)
        {
            SQL_cmd = new SqlCommand("SELECT TOP 20 A.Date,C.Subject,D.Name FROM tbl_date_info A,tbl_attendance B,tbl_time_table C,tbl_attandance_status D WHERE A.Date_Id=B.Date_Id AND b.Time_Table_Id=c.Time_Table_Id AND B.Status=D.Status AND B.Student_Id=(SELECT Student_Id FROM tbl_student_info WHERE Enrollment_Number='"+ Enroll +"') AND C.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') AND C.Subject='" + Subject.Text + "' AND B.Status=1 ORDER BY A.Date DESC", cn);
            cn.Open();
            dr = SQL_cmd.ExecuteReader();
            studentinfoview.DataSource = dr;
            studentinfoview.DataBind();
            cn.Close();
        }
        else if(Status.SelectedIndex==2)
        {
            SQL_cmd = new SqlCommand("SELECT TOP 20 A.Date,C.Subject,D.Name FROM tbl_date_info A,tbl_attendance B,tbl_time_table C,tbl_attandance_status D WHERE A.Date_Id=B.Date_Id AND b.Time_Table_Id=c.Time_Table_Id AND B.Status=D.Status AND B.Student_Id=(SELECT Student_Id FROM tbl_student_info WHERE Enrollment_Number='"+ Enroll +"') AND C.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') AND C.Subject='" + Subject.Text + "' AND B.Status=0 ORDER BY A.Date DESC", cn);
            cn.Open();
            dr = SQL_cmd.ExecuteReader();
            studentinfoview.DataSource = dr;
            studentinfoview.DataBind();
            cn.Close();
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            cn.Close();
            Enroll = Request.QueryString["Enroll"].ToString();

            SQL_cmd = new SqlCommand("SELECT A.Student_Name,B.Department_Name,B.Branch,B.Semester,B.Batch FROM tbl_student_info A,tbl_college_classes B WHERE A.Enrollment_Number='"+ Enroll +"' AND A.College_id=B.College_Classes_Id", cn);
            cn.Open();
            SqlDataReader dr = SQL_cmd.ExecuteReader();
            dt = new System.Data.DataTable();
            dt.Load(dr);
            cn.Close();
            lblname.Text = dt.Rows[0][0].ToString();
            lbldepartment.Text = dt.Rows[0][1].ToString();
            lblbranch.Text = dt.Rows[0][2].ToString();
            lblsemester.Text = dt.Rows[0][3].ToString();
            lblbatch.Text = dt.Rows[0][4].ToString();


            SQL_cmd = new SqlCommand("SELECT a.Subject FROM tbl_time_table a,tbl_attendance b WHERE a.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "' AND College_Classes_Id=(SELECT College_id FROM tbl_student_info WHERE Enrollment_Number='" + Enroll + "')) AND b.Time_Table_Id=A.Time_Table_Id GROUP BY Subject", cn);
            cn.Open();
            dr = SQL_cmd.ExecuteReader();
            Subject.DataSource = dr;
            Subject.DataValueField = "Subject";
            Subject.DataTextField = "Subject";
            Subject.DataBind();
            cn.Close();


            SQL_cmd.CommandText = "SELECT MIN(A.Date) FROM tbl_date_info A,tbl_attendance B,tbl_time_table C,tbl_attandance_status D WHERE A.Date_Id=B.Date_Id AND b.Time_Table_Id=c.Time_Table_Id AND B.Status=D.Status AND B.Student_Id=(SELECT Student_Id FROM tbl_student_info WHERE Enrollment_Number='"+ Enroll +"') AND C.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "')";
            cn.Open();
            txtdate_from.Text =Convert.ToDateTime(SQL_cmd.ExecuteScalar().ToString()).ToShortDateString();
            SQL_cmd.CommandText = "SELECT MAX(A.Date) FROM tbl_date_info A,tbl_attendance B,tbl_time_table C,tbl_attandance_status D WHERE A.Date_Id=B.Date_Id AND b.Time_Table_Id=c.Time_Table_Id AND B.Status=D.Status AND B.Student_Id=(SELECT Student_Id FROM tbl_student_info WHERE Enrollment_Number='"+ Enroll +"') AND C.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "')";
            txtdate_To.Text =Convert.ToDateTime(SQL_cmd.ExecuteScalar().ToString()).ToShortDateString();
            cn.Close();


  REFRESH_DATA();

        }
        
        
    }
    protected void Subject_SelectedIndexChanged(object sender, EventArgs e)
    {
        REFRESH_DATA();
    }
    protected void Status_SelectedIndexChanged(object sender, EventArgs e)
    {
     REFRESH_DATA();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string t = studentinfoview.Rows[1].ClientID;       
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myfunction", "alert('hi');", true);
    }




    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("class",e.Row.RowIndex.ToString());
        
    }
}