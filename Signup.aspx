<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

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
                   <li><a href="Login.aspx">Login</a></li>
               </ul>
           </div>
           </div>


    <div id="userarea">
       <div id="studentreg" style="float:left;width: 100%;margin: 0;">
           <p>Student Name <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtstudentname" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtstudentname" runat="server" CssClass="textbox"></asp:TextBox>
        <p>Enrollment Number <asp:RequiredFieldValidator ID="Validator2" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtenrollmentnumber" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtenrollmentnumber" runat="server" CssClass="textbox"></asp:TextBox>
        <p>Email Address <asp:RequiredFieldValidator ID="Validator3" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtemailaddress" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
        <asp:TextBox ID="txtemailaddress" runat="server" CssClass="textbox"></asp:TextBox>
        <p>Department</p>
        <asp:DropDownList ID="department" runat="server" CssClass="textbox"></asp:DropDownList>
        <p>Branch</p>
        <asp:DropDownList ID="branch" runat="server" CssClass="textbox"></asp:DropDownList>
        <p>Semester</p>
        <asp:DropDownList ID="semester" runat="server" CssClass="textbox"></asp:DropDownList>
        <p>Batch</p>
        <asp:DropDownList ID="batch" runat="server" CssClass="textbox"></asp:DropDownList>
        <asp:Button ID="btnsignup" runat="server" Text="Signup" CssClass="aspbutton" OnClick="btnsignup_Click" />

       </div>
        
          <div id="footer">
            <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
        </div>
</div>    
    </form>
</body>
</html>
