<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeTable.aspx.cs" Inherits="Faculty_TimeTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../style.css" rel="stylesheet" />
     <script src="../Script/jquery.min.js"></script>
    <script src="../Script/Design.js"></script>
      <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
    <link href="../screens.css" rel="stylesheet" />
</head>
<body>
    <form id="main" runat="server">
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
                   <li><a href="../Login.aspx?logout=1">Logout</a></li>
               </ul>
           </div>
                </div>

            <div id="username">
          <p><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Faculty_Username"] %></p>
      </div>

             <div id="userarea">
                 
                 <div id="timetablecategory" style="margin:auto;width:100%;float:left">
                     
                     <ul style="list-style:none">
                         <li style="border-top-left-radius: 8px;border-bottom-left-radius: 8px;" class="1">New Entry</li>
                         <li style="border-top-right-radius: 8px;border-bottom-right-radius: 8px;" class="2">Show&Edit Entry</li>
                     </ul>
                 </div>
                 <div id="block1" style="float:left;width:100%">
                     
                                      <p>Select Day</p>
                 <asp:DropDownList ID="Day" runat="server" CssClass="textbox" AutoPostBack="True"></asp:DropDownList>

                 <p class="main">Select Period</p>
                 <asp:DropDownList ID="Period" runat="server" CssClass="textbox"></asp:DropDownList>
             
                 <p class="main">Department</p>
        <asp:DropDownList ID="department" runat="server" CssClass="textbox"></asp:DropDownList>
        <p class="main">Branch</p>
        <asp:DropDownList ID="branch" runat="server" CssClass="textbox"></asp:DropDownList>
        <p class="main">Semester</p>
        <asp:DropDownList ID="semester" runat="server" CssClass="textbox"></asp:DropDownList>
        <p class="main">Batch</p>
        <asp:DropDownList ID="batch" runat="server" CssClass="textbox"></asp:DropDownList>    
             <p class="main">Subject <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="Subject" ForeColor="Red" Font-Size="Small" ValidationGroup="Block1"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="Subject" runat="server" CssClass="textbox"></asp:TextBox>

        <div id="btn" style="margin-top: 5%;margin-bottom:5%;">
                   <asp:Button ID="btn_add_time_table" runat="server" Text="Add To Your Timetable" CssClass="aspbutton" OnClick="btn_add_time_table_Click" ValidationGroup="Block1" />
               </div>
      
                 </div>
                 
                 <div id="block2" style="float:left;width:100%;display:none;">
                     <asp:ScriptManager ID="ScriptManager1" runat="server" />
                     <asp:UpdatePanel runat="server" id="UpdatePanel1" updatemode="Conditional">    
                         <ContentTemplate>

                        
                                          <div id="cal_haders" style="float:left;margin-bottom:2%;margin-top:2%;width:100%">
                <div id="cal_days">
                     <asp:Button ID="Btn_MON" runat="server" Text="MON" CssClass="cal_button" OnClick="Btn_MON_Click"/>
                         <asp:Button ID="Btn_TUE" runat="server" Text="TUE" CssClass="cal_button" OnClick="Btn_TUE_Click"/>
                         <asp:Button ID="Btn_WED" runat="server" Text="WED" CssClass="cal_button" OnClick="Btn_WED_Click"/>
                        <asp:Button ID="Btn_THU" runat="server" Text="THU" CssClass="cal_button" OnClick="Btn_THU_Click"/>
                        <asp:Button ID="Btn_FRI" runat="server" Text="FRI" CssClass="cal_button" OnClick="Btn_FRI_Click"/>
                         <asp:Button ID="Btn_SAT" runat="server" Text="SAT" CssClass="cal_button" OnClick="Btn_SAT_Click"/>
                </div>
                          
                      </div>
                           
              
                          
                          
                     
                       <div id="day_info" style="  width: 40%;padding: 2%;background-color: skyblue;font-weight: bold;color: white;float:left" runat="server">
                              Monday
                          </div>
                     
                     <div id="timetable" style="float:left;width:100%" runat="server">
                        
                  
                     
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
