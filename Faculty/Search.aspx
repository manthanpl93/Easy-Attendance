<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Faculty_Search" %>

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
    <form id="form1" runat="server">
   <div id="mainmenu">
       <div id="openmenu">
          <img src="../Images/hamenu.png" />
       <div id="menu">
               <ul>
                   <li data-reactid=""><a class="back">Back</a></li>
                   <li><a href="TakeAttandance.aspx">Take Attenadnace</a></li>
                   <li><a href="Search.aspx">Search</a></li>
                   <li><a href="TimeTable.aspx">Time Table</a></li>
                   <li><a href="#">Change Password</a></li>
                   <li><a href="../Login.aspx?logout=1">Logout</a></li>
                  
               </ul>
           </div>
           </div>
  
       <div id="username">
          <p class="main"><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Faculty_Username"] %></p>
      </div>
             <div id="userarea">

       <div id="search">
           <p class="main" style="float:left">Choose Category</p>
        <asp:DropDownList ID="category" runat="server" CssClass="textbox">
            <asp:ListItem>Enrollment Number</asp:ListItem>
            <asp:ListItem>Student Name</asp:ListItem>
            <asp:ListItem>Attendance Above</asp:ListItem>
            <asp:ListItem>Attendance Below</asp:ListItem>
           </asp:DropDownList>

        <p class="main"   style="float:left">Search Terms <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtsearchterms" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtsearchterms" runat="server" CssClass="textbox"></asp:TextBox>
           <div id="searchbutton">
               <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="aspbutton" OnClick="btnsearch_Click"/>
           </div>
        

       </div>

       <div id="StudentData" style="margin-top:2%">
           <asp:GridView ID="StudentInfoGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="StudentInfoGridView_RowCommand">
               <AlternatingRowStyle BackColor="White" Width="100%" />
               <Columns>
                   <asp:BoundField DataField="Student_Name" HeaderText="Student_Name" SortExpression="Student_Name" />
                   <asp:BoundField DataField="Enrollment_Number" HeaderText="Enrollment_Number" SortExpression="Enrollment_Number" />
                   <asp:ButtonField CommandName="Cancel" Text="Open" />
               </Columns>
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
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 20 Student_Name, Enrollment_Number FROM tbl_student_info WHERE (College_id IN (SELECT College_Classes_Id FROM tbl_college_classes WHERE (College_Classes_Id IN (SELECT College_Classes_Id FROM tbl_time_table WHERE (Employee_Id = (SELECT Employee_Id FROM tbl_employee_info WHERE (Email = @Employee_Email))))))) ORDER BY Enrollment_Number">
               <SelectParameters>
                   <asp:SessionParameter Name="Employee_Email" SessionField="Faculty_Username" />
               </SelectParameters>
           </asp:SqlDataSource>
       </div>
            </div> 
        <div id="footer">
         <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
   
       </div>
    </form>
</body>
</html>
