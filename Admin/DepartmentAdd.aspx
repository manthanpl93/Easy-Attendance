<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentAdd.aspx.cs" Inherits="Admin_DepartmentAdd" %>

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
               <li><a class="back">Back</a></li>
               <li><a href="FacultyAdd.aspx" class="submenu">Add Faculty</a></li>
               <li><a href="#" class="submenu">Add Department</a></li>
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
          <div id="deptreg">
           <p class="main">Department Name <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtdepartmentname" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtdepartmentname" runat="server" CssClass="textbox"></asp:TextBox>
        <p class="main">Branch <asp:RequiredFieldValidator ID="Validator2" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtbranch" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtbranch" runat="server" CssClass="textbox"></asp:TextBox>
        <p class="main">Semster <asp:RequiredFieldValidator ID="Validator3" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtsemster" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtsemster" runat="server" CssClass="textbox"></asp:TextBox>
        <p class="main">Batch <asp:RequiredFieldValidator ID="Validator4" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtbatch" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtbatch" runat="server" CssClass="textbox"></asp:TextBox>
           <div id="deptregbutton">
               <asp:Button ID="btnregister" runat="server" Text="Register" CssClass="aspbutton" OnClick="btnregister_Click"/>
           </div>
        <div id="dataview" style="margin:2%">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Department_Name" HeaderText="Department" SortExpression="Department_Name" />
                    <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
                    <asp:BoundField DataField="Semester" HeaderText="Semester" SortExpression="Semester" />
                    <asp:BoundField DataField="Batch" HeaderText="Batch" SortExpression="Batch" />
                    <asp:ButtonField CommandName="Cancel" Text="Edit" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Department_Name], [Branch], [Semester], [Batch] FROM [tbl_college_classes]"></asp:SqlDataSource>
        </div>

       </div>
      </div>
       
         <div id="footer">
            <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
</div>    
    </form>
</body>
</html>
