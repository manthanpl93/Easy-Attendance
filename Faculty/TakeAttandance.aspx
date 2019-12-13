<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TakeAttandance.aspx.cs" Inherits="Faculty_TakeAttandance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../style.css" rel="stylesheet" />
     <script src="../Script/jquery.min.js"></script>
    <script src="../Script/Design.js"></script>
    <script src="../Script/code_02.js"></script>
    <script src="../Script/Design_01.js"></script>
      <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
    <link href="../screens.css" rel="stylesheet" />




</head>
<body>
    <form id="form1" runat="server">
       <div id="mainmenu">
           <div id="openmenu">
          <img src="../Images/hamenu.png" />
           <div id="menu">
               <ul>
                   <li><a data-role="button" data-icon="arrow-r" class="back">Back</a></li>
                   <li><a href="TakeAttandance.aspx">Take Attenadnace</a></li>
                   <li><a href="Search.aspx">Search</a></li>
                   <li><a href="TimeTable.aspx">Time Table</a></li>
                   <li><a href="#">Change Password</a></li>
                 <li><a href="../Login.aspx?logout=1">Logout</a></li>
               </ul>
           </div>
               </div>
            <div id="username">
          <p><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Faculty_Username"] %></p>
      </div>
            <div id="userarea">

              <%--  <div class="loading">
                    <img src="../Images/ajax-loader.gif" />
                </div>--%>

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"/>
<asp:UpdatePanel runat="server" id="UpdatePanel1" updatemode="Conditional">    
 <ContentTemplate>
 <div id="takeattandance">
                         <p class="main">Select Day</p>
                         <asp:DropDownList ID="Day" runat="server"  OnSelectedIndexChanged="Day_SelectedIndexChanged" AutoPostBack="True" CssClass="textbox" > </asp:DropDownList>

                           <p class="main">Select Department</p>
        <asp:DropDownList ID="department" runat="server" CssClass="textbox"></asp:DropDownList>
                                                                                                                                                                                                 
      
        <p class="main">Branch</p>
        <asp:DropDownList ID="branch" runat="server" CssClass="textbox"></asp:DropDownList>
              <p class="main">Semester</p>
        <asp:DropDownList ID="Semester" runat="server" CssClass="textbox"></asp:DropDownList>
                <p class="main">Select Batch</p>
        <asp:DropDownList ID="batch" runat="server" CssClass="textbox"></asp:DropDownList>
        <p class="main">Select Period</p>
        <asp:DropDownList ID="Period" runat="server" CssClass="textbox"></asp:DropDownList>
                       
                         <div id="calender" style="float:left;width:100%;margin-bottom:5%"> 
                              <p class="main" style="margin-bottom:0">Date</p>
                              <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" Width="60%"></asp:TextBox>
                             <img id="cal" src="../Images/EventsCalendar_Icon.png" style="width:10%" runat="server" />
                         </div>
                       
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate" PopupButtonID="cal" DaysModeTitleFormat="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" Format="dd-MM-yyyy" />

                          <div id="btn" style="margin-top: 5%;margin-bottom:5%;">
                   <asp:Button ID="btn_next" runat="server" Text="Next" CssClass="aspbutton" OnClick="btn_next_Click"/>
                            
                             <%-- <div class="pr_ap" style="float:right">
                                  <a class="btnpresent">Present</a>
                              <a class="absent">Absent</a>
                              </div>--%>
                          
               </div>

           </div>
          
           <div id="attendananceview" runat="server">
     
              <%-- <div class="student_atten" style="float:left;margin-left:10%;width:80%;margin-bottom:2%;">
                 <div id="studentinfo" style="width:100%;background-color: gainsboro;float:left;border-top-right-radius: 4vh;border-top-left-radius: 7vh;border-bottom-right-radius: 2vh;border-bottom-left-radius: 7vh;">
                      <div class="st_pic" >
                     <img src="../Images/student.png" style="width:20%;float:left"/>
                 </div> 
                   <div class="number" style="float:left;width:80%;">
                   <p>1401331160100</p>
                   </div>
                      <div class="stu_name" style="float:left;width:80%;display:none">
                   <p>Manthan Dineshbhai Patel</p>
                   </div>
                 </div>
                   <div class="pre_apse">
                           <img src="../Images/present.png" style="float:left;width:35%"/>
                       <img src="../Images/absent.png" style="float:left;width:35%" />
                   </div>
           </div>--%>

            
                 </div>
           </ContentTemplate>
           </asp:UpdatePanel>
          
                </div>
              <div id="footer">
            <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
</div>    
    </form>
</body>
</html>
