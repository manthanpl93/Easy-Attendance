using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;

public partial class Faculty_TimeTable : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
   public static SqlConnection cn = new SqlConnection(con);
    public static DataTable dt=new DataTable();
    public static DataTable React_table = new DataTable();


    public string Time_Table_Schedule(string period,string time_From,string Time_To,string Department,string Branch,string Semester,string Batch,string subject,string reactid)
    {
        string HTML= @"<div class=""periods"">
 <div class=""p_time""><b>M$Period</b><b>M$Time_From-M$Time_To</b></div>
 <div class=""department""><b>M$Department</b></div>
<div class=""branchinfo""><b style=""width:100%"">Branch: M$Branch Sem: M$Semester Batch:M$Batch</b></div>
<div class=""subject_info""><b style=""width:100%"">Subject: M$Subject</b></div>
<div class=""timetabledlt"" style=""float:right;cursor:pointer;margin: 5px;""><img src=""../Images/delete.png"" style=""width:25px;"" data-reactid=M$reactid /></div></div>";

        HTML=HTML.Replace("M$Period",period);
        HTML=HTML.Replace("M$Time_From",time_From);
        HTML = HTML.Replace("M$Time_To", Time_To);
        HTML=HTML.Replace("M$Department",Department);
        HTML = HTML.Replace("M$Branch",Branch);
        HTML = HTML.Replace("M$Semester", Semester);
        HTML=HTML.Replace("M$Batch",Batch);
        HTML = HTML.Replace("M$Subject", subject);
        HTML = HTML.Replace("M$reactid", reactid);
        return HTML.ToString();


    }

    public void Fetch_Timetable(string day)
    {
        cn.Close();
        string email = Session["Faculty_Username"].ToString();
        DataTable dt2 = new DataTable();
        SqlCommand cmd = new SqlCommand("select Employee_Id from tbl_employee_info where Email='" + email + "'", cn);
        cn.Open();
        string eid = cmd.ExecuteScalar().ToString();

        cmd.CommandText = "select Id from tbl_days where Name='" + day + "'";
        string did = cmd.ExecuteScalar().ToString();
        cn.Close();

        day_info.InnerHtml = "";
        day_info.InnerHtml = day;


        cmd.CommandText = "SELECT D.Name, B.Period_Name, B.Period_Time_From, B.Period_Time_To, C.Department_Name, C.Branch, C.Semester, C.Batch, A.Subject,A.Time_Table_Id FROM tbl_time_table A,tbl_period_info B,tbl_college_classes C,tbl_days D  WHERE A.Employee_Id=" + eid + " AND A.Day=" + did + " AND  A.Period_Id = B.Period_Id AND A.College_Classes_Id = C.College_Classes_Id AND A.Day = D.Id";
        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        dt2.Load(dr);

        React_table = new DataTable();
        React_table.Columns.Add("reactid", typeof(int));
        React_table.Columns.Add("originalid", typeof(int));

        timetable.InnerHtml = "";
        for (int j = 0; j <= dt2.Rows.Count - 1; j++)
        {
            React_table.Rows.Add(j + 1, int.Parse(dt2.Rows[j][9].ToString()));
            timetable.InnerHtml = timetable.InnerHtml + Time_Table_Schedule(dt2.Rows[j][1].ToString(), dt2.Rows[j][2].ToString(), dt2.Rows[j][3].ToString().Substring(0, 5), dt2.Rows[j][4].ToString(), dt2.Rows[j][5].ToString(), dt2.Rows[j][6].ToString(), dt2.Rows[j][7].ToString(), dt2.Rows[j][8].ToString(),(j+1).ToString());
        }

       
        cn.Close();
    }


    [WebMethod]
    public static bool DeleteTimeTableRecord(int TimeTableId)
    {
        int t_id = 0;
        bool status = false;
        for(int i=0;i<React_table.Rows.Count;i++)
        {
           if(React_table.Rows[i][0].ToString()==TimeTableId.ToString())
           {
               t_id = Convert.ToInt32(React_table.Rows[i][1].ToString());
               status = true;
           }
        }
        if (status == true)
        {
            SqlCommand cmd = new SqlCommand("delete from tbl_time_table where Time_Table_Id=" + t_id + "", cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 0) { status = false; }
        }
        return status;
    }

    public void Refresh_combo()
    {
        cn.Close();
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


        cmd.CommandText = "SELECT Name FROM tbl_days ORDER BY ID";
        cn.Open();
        dr = cmd.ExecuteReader();
        Day.DataSource = dr;
        Day.DataValueField = "Name";
        Day.DataTextField = "Name";
        Day.DataBind();

        dr.Dispose();
        cn.Close();

        cmd.CommandText = "SELECT Period_Name,Period_Time_From,Period_Time_To FROM tbl_period_info";
        cn.Open();
        dr = cmd.ExecuteReader();

        if(dt.Rows.Count==0)
        {
            dt.Load(dr);
        }
        else
        {
         
            dt.Rows.Clear();
            dt.Load(dr);
        }
        dr.Dispose();
        cmd.Dispose();

    

    for (int i = 0; i < dt.Rows.Count; i++)
    {
        Period.Items.Add(dt.Rows[i][0].ToString() + "(" + dt.Rows[i][1].ToString() + "-" + dt.Rows[i][2].ToString() + ")");
    
    }

    cn.Close();

    Fetch_Timetable("Monday");




    }






    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["Student_Username"] != null)
            //{
                Refresh_combo();
           // }
            //else
            //{
            //    Response.Redirect("#");
            //}
        }

    }
    protected void btn_add_time_table_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SQL_ADD_TIME_TABLE",cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DAY",SqlDbType.VarChar).Value=Day.SelectedValue;
        cmd.Parameters.Add("@PERIOD_NAME",SqlDbType.VarChar).Value=dt.Rows[Period.SelectedIndex][0].ToString();
        cmd.Parameters.Add("@PERIOD_TIME_FROM", SqlDbType.VarChar).Value = dt.Rows[Period.SelectedIndex][1].ToString();
        cmd.Parameters.Add("@PERIOD_TIME_TO", SqlDbType.VarChar).Value = dt.Rows[Period.SelectedIndex][2].ToString();
        cmd.Parameters.Add("@EMPLOYEE_EMAIL",SqlDbType.VarChar).Value=Session["Faculty_Username"];
        cmd.Parameters.Add("@DEPARTMENT",SqlDbType.VarChar).Value=department.SelectedValue;
        cmd.Parameters.Add("@BRANCH",SqlDbType.VarChar).Value=branch.SelectedValue;
        cmd.Parameters.Add("@SEMESTER",SqlDbType.VarChar).Value=semester.SelectedValue;
        cmd.Parameters.Add("@BATCH",SqlDbType.VarChar).Value=batch.SelectedValue;
        cmd.Parameters.Add("@SUBJECT",SqlDbType.VarChar).Value=Subject.Text;
        cn.Open();

        string s = cmd.ExecuteScalar().ToString();
        cn.Close();

        if(s=="1")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Operation Failed ... Wrong Department Information')</script>");
        }
        else if(s == "2")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Someone Takes The Lecture Of This Class')</script>");
        }
        else if(s == "3")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Your Lecture Is Now Reserved . Operation Done ...')</script>");
        }

        else if (s == "1")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Operation Failed ... Wrong Department Information')</script>");
        }
    }
    protected void Btn_MON_Click(object sender, EventArgs e)
    {

        Fetch_Timetable("Monday");

    }
    protected void Btn_TUE_Click(object sender, EventArgs e)
    {
        Fetch_Timetable("Tuesday");
    }
    protected void Btn_WED_Click(object sender, EventArgs e)
    {
        Fetch_Timetable("Wednesday");
    }
    protected void Btn_THU_Click(object sender, EventArgs e)
    {
        Fetch_Timetable("Thursday");
        
    }
    protected void Btn_FRI_Click(object sender, EventArgs e)
    {
        Fetch_Timetable("Friday");
      
    }
    protected void Btn_SAT_Click(object sender, EventArgs e)
    {
        Fetch_Timetable("Saturday");
    }
}