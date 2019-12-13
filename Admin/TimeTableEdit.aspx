<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeTableEdit.aspx.cs" Inherits="Admin_TimeTableEdit" %>

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
               <li><a href="FacultyAdd.aspx">Add Faculty</a></li>
               <li><a href="DepartmentAdd.aspx">Add Department</a></li>
               <li><a href="#">Time Table</a></li>
                <li><a href="#">Password</a></li>
                  <li><a href="../Login.aspx?logout=1">Logout</a></li>
           </ul>
       </div>
              
             </div>
         <div id="username">
           <p class="main"><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Username"] %></p>
      </div>
          <div id="userarea">
         <div id="periodadd" style="float:left">
             <p class="main">Period Number <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtperiodnumber" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
             <asp:TextBox ID="txtperiodnumber" runat="server" CssClass="textbox"></asp:TextBox>

             <p class="main">Time(From) <asp:RequiredFieldValidator ID="Validator2" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txttimefrom" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
             <asp:TextBox ID="txttimefrom" runat="server" CssClass="textbox"></asp:TextBox>
             <p class="main">Time(To) <asp:RequiredFieldValidator ID="Validator3" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txttimeto" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
             <asp:TextBox ID="txttimeto" runat="server" CssClass="textbox"></asp:TextBox>
             <div id="period_save">
                 <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="aspbutton" OnClick="btnsave_Click"/>
             </div>
             
             </div>
  <div id="dataview" style="margin:2%;float:left;width:100%">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Period_Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:BoundField DataField="Period_Id" HeaderText="Period_Id" InsertVisible="False" ReadOnly="True" SortExpression="Period_Id" Visible="False" />
              <asp:BoundField DataField="Period_Name" HeaderText="Name" SortExpression="Period_Name" />
              <asp:BoundField DataField="Period_Time_From" HeaderText="Time_From" SortExpression="Period_Time_From" />
              <asp:BoundField DataField="Period_Time_To" HeaderText="Time_To" SortExpression="Period_Time_To" />
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
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Period_Name], [Period_Time_From], [Period_Time_To], [Period_Id] FROM [tbl_period_info]"></asp:SqlDataSource>
      </div>
                     </div>
         
           <div id="footer">
            <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
         </div>
    </form>
</body>
</html>
