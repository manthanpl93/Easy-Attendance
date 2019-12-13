<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Password_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainmenu">
        <div id="changepassword">
            <p>Username</p>
        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
            <p>Current Password</p>
        <asp:TextBox ID="txtcurrentpassword" runat="server"></asp:TextBox>
            <p>New Password</p>
        <asp:TextBox ID="txtnewpassword" runat="server"></asp:TextBox>
            <p>Confirm Password</p>
        <asp:TextBox ID="txtconfirmpassword" runat="server"></asp:TextBox>
        <asp:Button ID="btnchange" runat="server" Text="Change" />
            
        </div>
</div>    
    </form>
</body>
</html>
