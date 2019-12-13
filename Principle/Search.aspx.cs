using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Principle_Search : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    SqlConnection cn = new SqlConnection(con);
    SqlCommand SQL_cmd = new SqlCommand();
   string Department_Attendance(string Department_Name)
    {
        string Attendance;
        string Total_Students;
        string Present_Students;
        string Absent_Students;
        string HTML_TEXT = null;
        SQL_cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_attendance WHERE Student_Id IN (SELECT Student_Id FROM tbl_student_info WHERE College_id IN (SELECT College_Classes_Id FROM tbl_college_classes WHERE Department_Name='Computer-IT Department') GROUP BY Student_Id) AND Date_Id=(SELECT Date_Id FROM tbl_date_info WHERE Date='2015-07-12')",cn);
        cn.Open();
        Total_Students = SQL_cmd.ExecuteScalar().ToString();

        SQL_cmd.CommandText ="SELECT COUNT(*) FROM tbl_attendance WHERE Student_Id IN (SELECT Student_Id FROM tbl_student_info WHERE College_id IN (SELECT College_Classes_Id FROM tbl_college_classes WHERE Department_Name='Computer-IT Department') GROUP BY Student_Id) AND Date_Id=(SELECT Date_Id FROM tbl_date_info WHERE Date='2015-07-12') AND Status=0";
        Absent_Students = SQL_cmd.ExecuteScalar().ToString();

        SQL_cmd.CommandText = "SELECT COUNT(*) FROM tbl_attendance WHERE Student_Id IN (SELECT Student_Id FROM tbl_student_info WHERE College_id IN (SELECT College_Classes_Id FROM tbl_college_classes WHERE Department_Name='Computer-IT Department') GROUP BY Student_Id) AND Date_Id=(SELECT Date_Id FROM tbl_date_info WHERE Date='2015-07-12') AND Status=1";
        Present_Students = SQL_cmd.ExecuteScalar().ToString();

        SQL_cmd.CommandText = "SELECT (100*(SELECT COUNT(*) FROM tbl_attendance WHERE Student_Id IN (SELECT Student_Id FROM tbl_student_info WHERE College_id IN (SELECT College_Classes_Id FROM tbl_college_classes WHERE Department_Name='Computer-IT Department') GROUP BY Student_Id) AND Date_Id=(SELECT Date_Id FROM tbl_date_info WHERE Date='2015-07-12') AND Status=1))/(SELECT COUNT(*) FROM tbl_attendance WHERE Student_Id IN (SELECT Student_Id FROM tbl_student_info WHERE College_id IN (SELECT College_Classes_Id FROM tbl_college_classes WHERE Department_Name='Computer-IT Department') GROUP BY Student_Id) AND Date_Id=(SELECT Date_Id FROM tbl_date_info WHERE Date='2015-07-12'))";
        Attendance = SQL_cmd.ExecuteScalar().ToString();

        return HTML_TEXT;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SQL_cmd = new SqlCommand("SQL_PRINCIPLE_SERVICES", cn);
        SQL_cmd.CommandType = CommandType.StoredProcedure;
        SQL_cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value= Session["User_Principle"];
        SQL_cmd.Parameters.Add("@Category", SqlDbType.Int).Value = 9;
        SQL_cmd.Parameters.Add("@Date", SqlDbType.Date).Value =DateTime.Today.ToShortDateString();
        cn.Open();
        SqlDataReader dr = SQL_cmd.ExecuteReader();
        GridView1.DataSource = dr;
        GridView1.DataBind();
        cn.Close();
    }
}