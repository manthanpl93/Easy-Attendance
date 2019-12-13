<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacultyAdd.aspx.cs" Inherits="Admin_facultyadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../style.css" rel="stylesheet" />
    <script src="../Script/jquery.min.js"></script>
    <script src="../Script/Design.js"></script>
    <script src="../Script/code-04.js"></script>
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
               <li><a class="back">Back</a></li>
               <li><a href="#">Add Faculty</a></li>
               <li><a href="DepartmentAdd.aspx">Add Department</a></li>
                 <li><a href="TimeTableEdit.aspx">Time Table</a></li>
                 <li><a href="#">Password</a></li>
      <li><a href="../Login.aspx?logout=1">Logout</a></li>
           </ul>
       </div>
            
           </div>
       <div id="username">
           <p class="main"><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Username"] %></p>
      </div>
        <div id="userarea">
       <div id="freg">
           <p class="main">Faculty Name <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtfacultyname" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtfacultyname" runat="server" CssClass="textbox"></asp:TextBox>

           <p class="main">Department</p>
        <asp:DropDownList ID="department" runat="server" CssClass="textbox"></asp:DropDownList>

           <p class="main">Category</p>
           <asp:DropDownList ID="Category" runat="server" CssClass="textbox">
               <asp:ListItem>Faculty</asp:ListItem>
               <asp:ListItem>Principle</asp:ListItem>
           </asp:DropDownList>
         <p class="main">Email <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtemail" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtemail" runat="server" CssClass="textbox"></asp:TextBox>
           <div id="registerbutton">
     <asp:Button ID="btn_Register" runat="server" Text="Register" CssClass="aspbutton" OnClick="btnregister_Click"/>
               
           </div>
       
      </div>
                  <div id="searchitem">
                <div id="s_t_00" style="display:none">
                     <p class="main">Search</p>

       

                   <input id="txtsearch" type="text" class="textbox" /> 
                </div>
     
                   <input id="f_btnsearch" type="button" value="Search" class="aspbutton" style="margin-top: 5%;" data-s="0" />
               </div>

           <div id="facultyinfo" style="margin:2%;float:left;">
              
               <asp:GridView ID="employees_info" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                   <Columns>
                       <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" SortExpression="Employee_Name" />
                       <asp:BoundField DataField="Department_Name" HeaderText="Department_Name" SortExpression="Department_Name" />
                       <asp:ButtonField CommandName="Cancel" Text="Open" />
                   </Columns>
                   <EditRowStyle BackColor="#999999" />
                   <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                   <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <SortedAscendingCellStyle BackColor="#E9E7E2" />
                   <SortedAscendingHeaderStyle BackColor="#506C8C" />
                   <SortedDescendingCellStyle BackColor="#FFFDF8" />
                   <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
               </asp:GridView>
               <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Employee_Name], [Department_Name], [Email] FROM [tbl_employee_info]"></asp:SqlDataSource>
               <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
           </div>
            </div>
           </div>
         <div id="footer">
             <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
   
    </form>
</body>
</html>
