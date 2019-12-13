<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Principle_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../style.css" rel="stylesheet" />
    <script src="../Script/jquery.min.js"></script>
    <script src="../Script/Design.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div id="mainmenu">
       <div id="openmenu">
          <img src="../Images/hamenu.png" />
       <div id="menu">
           <ul>
               <li><a class="back">Back</a></li>
               <li><a href="#">Add Faculty</a></li>
               <li><a href="DepartmentAdd.aspx">Add Department</a></li>
                 <li><a href="TimeTableEdit.aspx">Time Table</a></li>
                 <li><a href="#">Password</a></li>
                   <li><a href="#">Logout</a></li>
           </ul>
       </div>
            
           </div>
       <div id="username">
           <p><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["User_Principle"] %></p>
      </div>
        <div id="userarea">
   
             <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"/>
       <asp:UpdatePanel runat="server" id="UpdatePanel1" updatemode="Conditional">    
           <ContentTemplate>
             <div id="calender" style="float:left;width:100%;margin-bottom:5%"> 
                              <p style="margin-bottom:0">Date</p>
                              <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" Width="60%"></asp:TextBox>
                             <img id="cal" src="../Images/EventsCalendar_Icon.png" style="width:10%" runat="server" />
                         </div>
              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate" PopupButtonID="cal" DaysModeTitleFormat="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" Format="dd-MM-yyyy" />
       
               <div id="deptinfo" style="float:left;margin-left:10%;margin-right:10%;width:80%;">
                
                   <div class="dinfo" style="float:left;width:100%;">
                       <div class="studentsinfo" style="float:left;width:80%">
                           <div class="dept" style="padding:2px" itemprop="headline">
                       Department: Computer-IT Department
                 </div>
                    <div class="branch" style="padding:2px">
                       Branch: Information Technology
                    </div>
                           <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                     <table style="float:left;width:50%">
                       <thead>
                           <tr>
                               <th>Total</th>
                               <th>Present</th>
                               <th>Absent</th>
                           </tr>
                       </thead>
                  
                   <tr>
                       <td>100</td>
                       <td>20</td>
                       <td>80</td>
                   </tr>

               </table>

                       </div>
                       <div class="persentage" style="float:left;width:20%;font-size:1.4em">
                           <b>Total</b>
                           <b>50%</b>
                       </div>
                       
                   </div>

                 
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
