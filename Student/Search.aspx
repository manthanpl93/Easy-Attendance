<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Student_Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../style.css" rel="stylesheet" />
    <script src="../Script/jquery.min.js"></script>
    <script src="../Script/Design.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="mainmenu">
        <div id="openmenu">
          <img src="../Images/hamenu.png" />
           <div id="menu">
           <ul>
         +      <li><a class="back">Back</a></li>
               <li><a href="Profile.aspx" class="submenu">Profile</a></li>
               <li><a href="#" class="submenu">Search</a></li>
                 <li><a href="#">Password</a></li>
                  <li><a href="../Login.aspx?logout=1">Logout</a></li>
           </ul>
       </div>

      </div>
       <div id="username">
          <p class="main"><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Student_Username"] %></p>
      </div>

        <div id="userarea">
       <div id="searchrecord">
           <p class="main">Choose Date</p>
        <asp:DropDownList ID="Date" runat="server" CssClass="textbox"></asp:DropDownList>
       </div>
            </div>

        <div id="footer">
         <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
       </div>
    </form>
</body>
</html>
