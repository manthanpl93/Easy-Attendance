<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Info.aspx.cs" Inherits="Faculty_Student_Info" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../style.css" rel="stylesheet" />
     <script src="../Script/jquery.min.js"></script>
    <script src="../Script/Design.js"></script>
      <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
    <link href="../screens.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#studentinfoview tr').click(function () {
                $(".editattendance").hide(200);
                var style = $(this).attr("style");
                $(this).append("<div class=\"editattendance\" style=\""+style+"\"><select id=\"present_catrgory\"><option>Present</option><option>Absent</option></select><button type=\"button\" style=\"width: 50%;margin-left: 25%;color: white;background-color: #2a8a85;font-weight: bold;\">Edit</button></div>");
            
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div id="mainmenu">
        <div id="openmenu">
          <img src="../Images/hamenu.png" />
        <div id="menu">
               <ul>
                   <li><a class="back">Back</a></li>
                   <li><a href="TakeAttandance.aspx">Take Attenadnace</a></li>
                   <li><a href="Search.aspx">Search</a></li>
                   <li><a href="TimeTable.aspx">Time Table</a></li>
                   <li><a href="#">Change Password</a></li>
                   <li><a href="#">Logout</a></li>
               </ul>
           </div>
            </div>
             <div id="username">
          <p><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Faculty_Username"] %></p>
      </div>
         <div id="userarea">
            
        <div id="student_info">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" updatemode="Conditional">
                <ContentTemplate>
                <p class="main">Name</p>
                <asp:Label ID="lblname" runat="server" Text="Label" CssClass="lables"></asp:Label>
            <i style="cursor:pointer;color: red;"> (More Info)</i>
            <div id="info" style="float:left;width: 100%;display:none">
                <p class="main">Department</p>
                <asp:Label ID="lbldepartment" runat="server" Text="Label" CssClass="lables"></asp:Label>

                <p class="main">Branch</p>
                <asp:Label ID="lblbranch" runat="server" Text="Label" CssClass="lables"></asp:Label>

                   <p class="main">Semester</p>
                <asp:Label ID="lblsemester" runat="server" Text="Label" CssClass="lables"></asp:Label>
                   <p class="main">Batch</p>
               
             <asp:Label ID="lblbatch" runat="server" Text="Label" CssClass="lables"></asp:Label>
            <i class="lessinfo" style="cursor:pointer;color: red;"> (Less info)</i>
            </div>
                     <p class="main">Subject</p>
                <asp:Label ID="lblsubject" runat="server" Text="Label" CssClass="lables"></asp:Label>
                <p class="main">Total Attendance</p>
                <asp:Label ID="lbltotalattendance" runat="server" Text="Label" CssClass="lables"></asp:Label>
                    <div id="arrow">
                         <img src="../Images/down-arrow-circle-hi.png" style="width:8%;margin-right:3%;float:right"/>
                    </div>          
            <div id="searchmodule" style="display:none">
                    <p class="main">Choose Subject</p>
                    <asp:DropDownList ID="Subject" runat="server" CssClass="textbox" OnSelectedIndexChanged="Subject_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>    
                    <p class="main">Choose Status</p>
                    <asp:DropDownList ID="Status" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="Status_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Pre-Sent</asp:ListItem>
                        <asp:ListItem>Ab-sent</asp:ListItem>
                    </asp:DropDownList>
                    <div id="calender" style="float:left;width:100%;margin-bottom:5%"> 
                              <p class="main" style="margin-bottom:0">Date From</p>
                              <asp:TextBox ID="txtdate_from" runat="server" CssClass="textbox" Width="60%"></asp:TextBox>
                             <img id="cal" src="../Images/EventsCalendar_Icon.png" style="width:10%" runat="server" />

                        <p class="main" style="margin-bottom:0">Date To</p>
                              <asp:TextBox ID="txtdate_To" runat="server" CssClass="textbox" Width="60%"></asp:TextBox>
                             <img id="cal2" src="../Images/EventsCalendar_Icon.png" style="width:10%" runat="server" />
                         </div>
                       
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate_from" PopupButtonID="cal" DaysModeTitleFormat="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" Format="dd-MM-yyyy" />
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdate_To" PopupButtonID="cal2" DaysModeTitleFormat="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" Format="dd-MM-yyyy" />

                <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="aspbutton"/>
                </div>
            <div id="Student_Data" style="float:left;margin:2%;width:100%">
                <asp:GridView ID="studentinfoview" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <AlternatingRowStyle BackColor="White"/>
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:dd/MM/yy}"/>
                        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                        <asp:BoundField DataField="Name" HeaderText="Status" SortExpression="Name" >
                        </asp:BoundField>
                       
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
<AlternatingRowStyle HorizontalAlign="Center" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP (20) A.Date, C.Subject, D.Name FROM tbl_date_info AS A INNER JOIN tbl_attendance AS B ON A.Date_Id = B.Date_Id INNER JOIN tbl_time_table AS C ON B.Time_Table_Id = C.Time_Table_Id INNER JOIN tbl_attandance_status AS D ON B.Status = D.Status"></asp:SqlDataSource>
             </div>
                     </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            

             

        </div>
             <div id="footer">
             <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
        </div>
         
    </form>
</body>
</html>
