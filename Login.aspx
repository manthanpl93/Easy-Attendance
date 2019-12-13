<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../style.css" rel="stylesheet" />
      <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
    <link href="../screens.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="userarea">
        <div id="mainmenu">
        
        <div id="logo">
            <img src="Images/logobar (1).png" />
        </div>
        <div id="loginfrm">
            <div id="fields">
            <p class="main">Username <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtusername" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
            <asp:TextBox ID="txtusername" runat="server" CssClass="textbox"></asp:TextBox>

            <p class="main">Password <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtpassword" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
            <asp:TextBox ID="txtpassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>

           

            <div id="frgtpaswd">
                <p>Forget password ?</p>
            </div>
            
            <div id="login">
                 <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="aspbutton" OnClick="btnlogin_Click"/>
            </div>
        </div>

        <div id="signup">
            <p class="main" style="font-size: 0.95em;">Student can only register from here, for Faculty account contect website administrator</p>
            <p class="main">Not Account ? <a href="Signup.aspx">Signup</a> </p>



        </div>

        </div>
        

        <div id="footer">
            <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
            </div>
    </div>
    </form>
</body>
</html>
