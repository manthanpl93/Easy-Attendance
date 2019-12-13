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

public partial class Faculty_TakeAttandance : System.Web.UI.Page
{
    public static string con = WebConfigurationManager.ConnectionStrings["constring"].ConnectionString.ToString();
    public static SqlConnection cn = new SqlConnection(con);
    public static DataTable dt = new DataTable();
    public DateTime User_Selected_Date;
    public static DataTable ReactID_Table = new DataTable();
    public static int Total_students=0;
    public static int Attendance_Counter = 0;
    public static int Time_table_id = 0;
    public static DateTime userdate;
   
    public static string User_day = null;
    public static string User_Department_Name = null;
    public static string User_Branch = null;
    public static string User_Semester = null;
    public static string User_batch = null;
    public static int User_period_id;
    public static string User_Email = null;


    public static bool Present_Send = false;
    public static bool Absent_send = false;


    public string attandancefields(string STUDENT_NAME,string ENROLLMENT_NUMBER,int Attendance_Id)
    {
        string present = Attendance_Id.ToString();
        string absent = Attendance_Id.ToString();
        string HTML_VALUE = @"<div class=""student_atten"" >
                 <div class=""studentinfo"">
                      <div class=""st_pic"">
                     <img src=""../Images/student.png""/>
                 </div> 
                   <div class=""number"">
                   <p class=""main"" style=""cursor: pointer;"">$M(ENROLLMENTNUMBER)</p>
                   </div>
                      <div class=""stu_name"">
                   <p class=""main"" style=""cursor: pointer;"">$M(STUDENT_NAME)</p>
                   </div>
                 </div>
                
 <div class=""pr_ap"" style=""float:right;margin-bottom:5px;"">
                                  <a class=""btnpresent"" data-reactid=""$M(Present)"" data-status=""p"">Present</a>
                              <a class=""absent"" data-reactid=""$M(Absent)"" data-status=""a"">Absent</a>
                              </div>
           </div>";

       HTML_VALUE= HTML_VALUE.Replace("$M(ENROLLMENTNUMBER)",ENROLLMENT_NUMBER);
       HTML_VALUE=HTML_VALUE.Replace("$M(STUDENT_NAME)", STUDENT_NAME);
       HTML_VALUE=HTML_VALUE.Replace("$M(Present)", present);
       HTML_VALUE=HTML_VALUE.Replace("$M(Absent)", absent);
       return HTML_VALUE;
    }


    public static string attandancefields_2(string STUDENT_NAME, string ENROLLMENT_NUMBER, int Attendance_Id)
    {
        cn.Close();
        string present = Attendance_Id.ToString();
        string absent = Attendance_Id.ToString();
        string HTML_VALUE = @"<div class=""student_atten"" >
                 <div class=""studentinfo"">
                      <div class=""st_pic"">
                     <img src=""../Images/student.png""/>
                 </div> 
                   <div class=""number"">
                   <p class=""main"" style=""cursor: pointer;"">$M(ENROLLMENTNUMBER)</p>
                   </div>
                      <div class=""stu_name"">
                   <p class=""main"" style=""cursor: pointer;"">$M(STUDENT_NAME)</p>
                   </div>
                 </div>
                
 <div class=""pr_ap_0"" style=""float:right;margin-bottom:5px;"">
                                  <a class=""btnpresent"" data-reactid=""$M(Present)"" data-status=""p"">Present</a>
                              <a class=""absent"" data-reactid=""$M(Absent)"" data-status=""a"">Absent</a>
                              </div>
           </div>";

        HTML_VALUE = HTML_VALUE.Replace("$M(ENROLLMENTNUMBER)", ENROLLMENT_NUMBER);
        HTML_VALUE = HTML_VALUE.Replace("$M(STUDENT_NAME)", STUDENT_NAME);
        HTML_VALUE = HTML_VALUE.Replace("$M(Present)", present);
        HTML_VALUE = HTML_VALUE.Replace("$M(Absent)", absent);
        return HTML_VALUE;
    }






    [WebMethod]
    public static Boolean Fill_Attandance(int A_Id,string STATUS)
    {
        int mainid=0;
        Boolean flag = false;
        bool A_Status = false;
        Boolean C_status = false;
        
        if(STATUS=="p")
        {
            A_Status = true;
        }
        else if(STATUS=="a")
        {
            A_Status = false;
        }

        for(int i=0;i<ReactID_Table.Rows.Count;i++)
        {
            if(ReactID_Table.Rows[i][0].ToString()==A_Id.ToString())
            {
                flag = true;
                mainid =int.Parse(ReactID_Table.Rows[i][1].ToString());
            }
        }

        if(flag==true)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand("SQL_STUDENT_ATTANDANCE_UPDATE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AttendanceId", SqlDbType.Int).Value =mainid;
            cmd.Parameters.Add("@STATUS", SqlDbType.Bit).Value = A_Status;
            cn.Open();
            string status = cmd.ExecuteScalar().ToString();
            cn.Close();

            if (status == "1")
            {
                //ATTANDANCE SUCESSFULLY UPDATED

            }
            else if (status == "2")
            {
                //WRONG OPERATION 
            }
            Attendance_Counter = Attendance_Counter + 1;

            if (Attendance_Counter == Total_students)
            {
                C_status = true;
                ReactID_Table.Rows.Clear();
                Final_Attendance();
            }

        }

        
        return C_status;
    }


    [WebMethod]
    public static string present_absent_student_list(int category)
    {
        string html = null;

        if (Time_table_id > 0 && userdate != null)
        {

          if((category==2 && Present_Send!=true) || (category==3 && Absent_send!=true))
            {
                DataTable OPdt = new DataTable();
                SqlCommand opcmd = new SqlCommand("SQL_Get_Student_Info", cn);
                opcmd.CommandType = CommandType.StoredProcedure;
                opcmd.Parameters.Add("@Day", SqlDbType.VarChar).Value = User_day;
                opcmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = User_Department_Name;
                opcmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = User_Branch;
                opcmd.Parameters.Add("@Semester", SqlDbType.VarChar).Value = User_Semester;
                opcmd.Parameters.Add("@Batch", SqlDbType.VarChar).Value = User_batch;
                opcmd.Parameters.Add("@Period_Id", SqlDbType.Int).Value = User_period_id;
                opcmd.Parameters.Add("@Date", SqlDbType.Date).Value = userdate;
                opcmd.Parameters.Add("@Employeee_Email", SqlDbType.VarChar).Value = User_Email;
                opcmd.Parameters.Add("@Category", SqlDbType.SmallInt).Value = category;
                cn.Open();
                SqlDataReader OPdr = opcmd.ExecuteReader();
                OPdt.Load(OPdr);

                if (category == 2)
                {
                    Present_Send = true;
                }
                else if (category == 3)
                {
                    Absent_send = true;
                }




                for (int i = 0; i < OPdt.Rows.Count; i++)
                {
                    int index = (ReactID_Table.Rows.Count) + 1;
                    ReactID_Table.Rows.Add(index, Convert.ToInt32(OPdt.Rows[i][2].ToString()));



                    html = html + attandancefields_2(OPdt.Rows[i][0].ToString(), OPdt.Rows[i][1].ToString(),index);

                    //html = attandancefields(OPdt.Rows[i][0].ToString(), OPdt.Rows[i][1].ToString(), i + 1);
                    //attendananceview.InnerHtml = attendananceview.InnerHtml + html;
                }
            }

        }





        return html;
    }





    [WebMethod]
    public static void pre_abs()
    {
        int a = 0;
        a = a + 1;

    }

    [WebMethod]
    public static string Final_Attendance()
    {
        string cdate = userdate.ToShortDateString();
        int TOTAL_PRESENT_STUDENT;
        int TOTAL_ABSENT_STUDENT;
        
        string HTML_Text = @"<div class=""pre-absentstudents"" id=""t_p_c_0"" data-seen=""0"" data-hide=""0"">
            <div class=""prapsinfo"" style=""float:left"">
            Present Students-(M@#PRESENTSTUDENTS) ((M@#DATE))
            </div>
            <div class=""ic"" style=""float:right"">
            <img src=""../Images/plus.png"" style=""width:30px""/>
            </div>
            </div>
            <div id=""l_p_s_0""></div>

      
            <div class=""pre-absentstudents"" id=""abs"" id=""t_a_c_0"" data-seen=""0"" data-hide=""0"" style=""background:#2a8a85;"">
            <div class=""prapsinfo"" style=""float:left"">
            Absent Student-(M@#ABSENTSTUDENTS) ((M@#DATE))
            </div>
            <div class=""ic"" style=""float:right"">
            <img src=""../Images/plus.png"" style=""width:30px""/>
            </div>
            </div>
            <div id=""l_a_s_0""></div>            

    
            <div class=""pre-absentstudents"" id=""t_d_c_0"">
            <div class=""prapsinfo"" style=""float:left"">
            Done
            </div>
            <div class=""ic"" style=""float:right"">
            <img src=""../Images/DONE.png"" style=""width:30px""/>
             </div>
            </div>
            ";
        cn.Close();
      SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_attendance WHERE Status=0 AND Date_Id=(SELECT Date_Id FROM tbl_date_info WHERE Date=@p1);",cn);
      cmd.Parameters.Add("@p1", SqlDbType.Date).Value = userdate;
        cn.Open();
        TOTAL_ABSENT_STUDENT = Convert.ToInt32(cmd.ExecuteScalar().ToString());

      cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_attendance WHERE Status=1 AND Date_Id=(SELECT Date_Id FROM tbl_date_info WHERE Date=@p1);", cn);
      cmd.Parameters.Add("@p1", SqlDbType.Date).Value = userdate;
        TOTAL_PRESENT_STUDENT= Convert.ToInt32(cmd.ExecuteScalar().ToString()); 
      cn.Close();

      
        HTML_Text=HTML_Text.Replace("(M@#DATE)", cdate);
        HTML_Text = HTML_Text.Replace("(M@#PRESENTSTUDENTS)",TOTAL_PRESENT_STUDENT.ToString());
        HTML_Text = HTML_Text.Replace("(M@#ABSENTSTUDENTS)",TOTAL_ABSENT_STUDENT.ToString());

      return HTML_Text;
    }





     protected void Present_Absent(object sender, EventArgs e)
     {
         var button = sender as Button;

         var AID = button.Attributes["data-reactid"];


         var Cid = button.ClientID;

     }
  



    public void refreshcombo()
    {
        cn.Close();
        SqlCommand cmd = new SqlCommand("SELECT A.Branch FROM tbl_college_classes A,tbl_time_table B where A.College_Classes_Id=B.College_Classes_Id AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Branch ORDER BY A.Branch", cn);
        cmd.CommandType = CommandType.Text;
        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        branch.DataSource = dr;
        branch.DataValueField = "Branch";
        branch.DataTextField = "Branch";
        branch.DataBind();
        cn.Close();
        cn.Open();
        cmd.CommandText = "SELECT A.Semester FROM tbl_college_classes A,tbl_time_table B where A.College_Classes_Id=B.College_Classes_Id AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Semester ORDER BY A.Semester";
        dr = cmd.ExecuteReader();
        Semester.DataSource = dr;
        Semester.DataValueField = "Semester";
        Semester.DataTextField = "Semester";
        Semester.DataBind();
        cn.Close();
        cn.Open();
        cmd.CommandText = "SELECT A.Batch FROM tbl_college_classes A,tbl_time_table B where A.College_Classes_Id=B.College_Classes_Id AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Batch ORDER BY A.Batch";
        dr = cmd.ExecuteReader();
        batch.DataSource = dr;
        batch.DataValueField = "Batch";
        batch.DataTextField = "Batch";
        batch.DataBind();
        cn.Close();
        cn.Open();
        cmd.CommandText = "SELECT A.Department_Name FROM tbl_college_classes A,tbl_time_table B where A.College_Classes_Id=B.College_Classes_Id AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Department_Name ORDER BY A.Department_Name";
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

        cmd.CommandText = "SELECT A.Period_Id,A.Period_Name,A.Period_Time_From,A.Period_Time_To FROM tbl_period_info A,tbl_time_table B WHERE A.Period_Id=B.Period_Id AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Period_Id,A.Period_Name,A.Period_Time_From,A.Period_Time_To";
        cn.Close();
        cn.Open();
        dr = cmd.ExecuteReader();

        if (dt.Rows.Count == 0)
        {
            dt.Load(dr);
        }
        else
        {

            dt.Rows.Clear();
            dt.Load(dr);
        }



        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Period.Items.Add(dt.Rows[i][1].ToString() + "(" + dt.Rows[i][2].ToString() + "-" + dt.Rows[i][3].ToString() + ")");
        }

        cn.Close();



    }

    protected void Page_Load(object sender, EventArgs e)
    {
        btn_next.Attributes.Add("onclick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(btn_next, null) + ";");
        
        if (!IsPostBack)
        {
            if (Session["Faculty_Username"] != null)
            {
                refreshcombo();

                Present_Send = false;
                Absent_send = false;

               






            }
            else
            {
                Response.Redirect("/Login.aspx");
            }

        }


        Attendance_Counter = 0;
        Total_students = 0;
        Time_table_id = 0;
        
    }

    protected void Day_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SELECT A.Branch FROM tbl_college_classes A,tbl_time_table B,tbl_days C WHERE C.Id=(SELECT Id FROM tbl_days WHERE Name='" + Day.Text + "' ) AND A.College_Classes_Id=B.College_Classes_Id AND  C.Id=B.Day AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Branch ORDER BY A.Branch", cn);
        cmd.CommandType = CommandType.Text;
        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        branch.DataSource = dr;
        branch.DataValueField = "Branch";
        branch.DataTextField = "Branch";      
        branch.DataBind();
        cn.Close();
        cn.Open();
        cmd.CommandText = "SELECT A.Semester FROM tbl_college_classes A,tbl_time_table B,tbl_days C WHERE C.Id=(SELECT Id FROM tbl_days WHERE Name='" + Day.Text + "' ) AND A.College_Classes_Id=B.College_Classes_Id AND  C.Id=B.Day AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Semester ORDER BY A.Semester";
        dr = cmd.ExecuteReader();
        Semester.DataSource = dr;
        Semester.DataValueField = "Semester";
        Semester.DataTextField = "Semester";
        Semester.DataBind();
        cn.Close();
        cn.Open();
        cmd.CommandText = "SELECT A.Batch FROM tbl_college_classes A,tbl_time_table B,tbl_days C WHERE C.Id=(SELECT Id FROM tbl_days WHERE Name='" + Day.Text + "' ) AND A.College_Classes_Id=B.College_Classes_Id AND  C.Id=B.Day AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Batch ORDER BY A.Batch";
        dr = cmd.ExecuteReader();
        batch.DataSource = dr;
        batch.DataValueField = "Batch";
        batch.DataTextField = "Batch";
        batch.DataBind();
        cn.Close();
        cn.Open();
        cmd.CommandText = "SELECT A.Department_Name FROM tbl_college_classes A,tbl_time_table B,tbl_days C WHERE C.Id=(SELECT Id FROM tbl_days WHERE Name='" + Day.Text + "' ) AND A.College_Classes_Id=B.College_Classes_Id AND  C.Id=B.Day AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Department_Name ORDER BY A.Department_Name";
        dr = cmd.ExecuteReader();
        department.DataSource = dr;
        department.DataValueField = "Department_Name";
        department.DataTextField = "Department_Name";
        department.DataBind();
        cmd.Dispose();
        dr.Dispose();
        cn.Close();

        cmd.CommandText = "SELECT A.Period_Id,A.Period_Name,A.Period_Time_From,A.Period_Time_To FROM tbl_period_info A,tbl_time_table B,tbl_days C WHERE C.Id=(SELECT Id FROM tbl_days WHERE Name='" + Day.Text + "' ) AND A.Period_Id=B.Period_Id AND  C.Id=B.Day AND B.Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"] + "') GROUP BY A.Period_Id,A.Period_Name,A.Period_Time_From,A.Period_Time_To";

        cn.Open();
        dr = cmd.ExecuteReader();

        if (dt.Rows.Count == 0)
        {
            dt.Load(dr);
        }
        else
        {

            dt.Rows.Clear();
            dt.Load(dr);
        }

        Period.Items.Clear();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Period.Items.Add(dt.Rows[i][1].ToString() + "(" + dt.Rows[i][2].ToString() + "-" + dt.Rows[i][3].ToString() + ")");
        }

        cn.Close();


    }
    protected void btn_next_Click(object sender, EventArgs e)
    {
        cn.Close();
         SqlCommand cmd = new SqlCommand("SQL_Attandance_Create", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Day",SqlDbType.VarChar).Value=Day.SelectedValue.ToString();
        cmd.Parameters.Add("@Department",SqlDbType.VarChar).Value=department.SelectedValue;
        cmd.Parameters.Add("@Branch",SqlDbType.VarChar).Value=branch.SelectedValue;
        cmd.Parameters.Add("@Semester",SqlDbType.VarChar).Value=Semester.SelectedValue;
        cmd.Parameters.Add("@Batch", SqlDbType.VarChar).Value = batch.SelectedValue;
        cmd.Parameters.Add("@Period_Id",SqlDbType.Int).Value=Convert.ToInt32(dt.Rows[Period.SelectedIndex][0]);
        cmd.Parameters.Add("@Date", SqlDbType.Date).Value =Convert.ToDateTime(txtdate.Text).ToShortDateString();
        cmd.Parameters.Add("@Employeee_Email",SqlDbType.VarChar).Value=Session["Faculty_Username"].ToString();
        cn.Open();
        
        string status = cmd.ExecuteScalar().ToString();
        cn.Close();

        if(status=="1")
        {
            //WRONG OPERATION OCCURED -- INVALID VALUES SUBMITTTED
        }
        else if(status=="2" || status=="3")
        {
            //OPERATION SUCESSFULL

          
            DataTable OPdt = new DataTable();
            SqlCommand opcmd = new SqlCommand("SQL_Get_Student_Info", cn);
            opcmd.CommandType = CommandType.StoredProcedure;
            opcmd.Parameters.Add("@Day", SqlDbType.VarChar).Value = Day.SelectedValue.ToString();
            User_day = Day.SelectedValue.ToString();
            opcmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = department.SelectedValue;
            User_Department_Name = department.SelectedValue;
            opcmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = branch.SelectedValue;
            User_Branch = branch.SelectedValue;
            opcmd.Parameters.Add("@Semester", SqlDbType.VarChar).Value = Semester.SelectedValue;
            User_Semester = Semester.SelectedValue;
            opcmd.Parameters.Add("@Batch", SqlDbType.VarChar).Value = batch.SelectedValue;
            User_batch = batch.SelectedValue;
            opcmd.Parameters.Add("@Period_Id", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[Period.SelectedIndex][0]);
            User_period_id = Convert.ToInt32(dt.Rows[Period.SelectedIndex][0]);

            opcmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtdate.Text;
            opcmd.Parameters.Add("@Employeee_Email", SqlDbType.VarChar).Value = Session["Faculty_Username"].ToString();
            User_Email = Session["Faculty_Username"].ToString();
            opcmd.Parameters.Add("@Category", SqlDbType.SmallInt).Value = 1;
            cn.Open();
            SqlDataReader OPdr = opcmd.ExecuteReader();
            OPdt.Load(OPdr);

            attendananceview.InnerHtml = "";

            ReactID_Table.Rows.Clear();
            ReactID_Table = new DataTable();

            ReactID_Table.Columns.Add("Id", typeof(int));
            ReactID_Table.Columns.Add("Original_Id", typeof(int));

            attendananceview.InnerHtml = @"<div id=""menuoption"" style=""width:100%;float:left"">
                 <div id=""category"">
                     <div id=""icon"" style=""float:right"">
                         <img src=""../Images/category.png"" style=""width:50px"" data-s=""1""/>
                     </div>

                 </div>
             </div>
                <div id=""mainblock"" style=""margin-left: 35%;float:left"">
                    <div id=""categorylist"">
                         <ul style=""float:right;margin:0;list-style:none;padding:0"">
                             <li data-s=""1"">Display By Student Name</li>
                             <li data-s=""2"" class=""select"">Display By Student Number</li>
                         </ul>
                     </div>
                </div>";

            Total_students = OPdt.Rows.Count;
            userdate =Convert.ToDateTime(txtdate.Text);
            
            for (int i = 0; i < OPdt.Rows.Count; i++)
            {
                ReactID_Table.Rows.Add(i+1,Convert.ToInt32(OPdt.Rows[i][2].ToString()));
                string html = null;
                
                html =attandancefields(OPdt.Rows[i][0].ToString(), OPdt.Rows[i][1].ToString(),i+1);
                attendananceview.InnerHtml = attendananceview.InnerHtml + html;
            }

            cmd.CommandText = "SELECT Time_Table_Id FROM tbl_time_table WHERE Day=(SELECT Id FROM tbl_days WHERE Name='" + Day.Text + "') AND Period_Id=" + Convert.ToInt32(dt.Rows[Period.SelectedIndex][0]) + " AND Employee_Id=(SELECT Employee_Id FROM tbl_employee_info WHERE Email='" + Session["Faculty_Username"].ToString() + "') AND College_Classes_Id=(SELECT College_Classes_Id FROM tbl_college_classes WHERE Department_Name='" + department.Text + "' AND Branch='" + branch.Text + "' AND Semester='" + Semester.Text + "' AND Batch='" + batch.Text + "')";
            cmd.CommandType = CommandType.Text;
            Time_table_id =Convert.ToInt32(cmd.ExecuteScalar());


            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myfunction", "$(document).ready(function(){$('#takeattandance').slideUp('slow');;})", true);
           
        }
        //else if(status=="3")
        //{
        //    //ATTANDANCE ALLREADY FILLED
        //}

      
    }
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {

    }
}