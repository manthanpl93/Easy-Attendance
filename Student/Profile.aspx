<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Student_Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
    <link href="../screens.css" rel="stylesheet" />
     <link href="../style.css" rel="stylesheet" />
    <script src="../Script/jquery.min.js"></script>
    <script src="Scripts/JS_Code-01.js"></script>
    <script src="../Script/Design.js"></script>
    <link href="Scripts/style2.css" rel="stylesheet" />
  
    
</head>
<body>
    <form id="form1" runat="server">
       <div id="mainmenu">
            <div id="openmenu">
          <img src="../Images/hamenu.png" />
           <div id="menu">
           <ul>
               <li><a class="back">Back</a></li>
               <li><a href="#" class="submenu">Profile</a></li>
               <li><a href="Search.aspx" class="submenu">Search</a></li>
                 <li><a href="#">Password</a></li>
                  <li><a href="../Login.aspx?logout=1">Logout</a></li>
           </ul>
       </div>

      </div>
            <div id="username">
                <div id="u_n_01" data-seen="0" >
                    <img src="../Images/1388313637_1.png"/><b id="nf_n_00"><%= Notification_count %></b>
                </div>
                <div id="userid">
                    <p><img src="../Images/user-icon-1004131853.png" height="13" width="13" style="padding-right:3px"/> <% =Session["Student_Username"] %></p>
                </div>
          
      </div>
             <div id="userarea" style="position:relative">
           <div id="StudentProfile">
               <p class="main">Student Name <asp:RequiredFieldValidator ID="Validator1" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtstudentname" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
               <div class="maininfo">
                   <asp:Label ID="lblstudentname" runat="server" Text="Label" CssClass="lables"></asp:Label>
               </div>
               <div class="editinfo">
                   <asp:TextBox ID="txtstudentname" runat="server" CssClass="textbox"></asp:TextBox>
               </div>
               
               <p class="main">Enroll Number <asp:RequiredFieldValidator ID="Validator2" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtenrollnumber" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
           <div class="maininfo">
                   <asp:Label ID="lblenrollnumber" runat="server" Text="Label" CssClass="lables"></asp:Label>
              </div>
               <div class="editinfo">
                    <asp:TextBox ID="txtenrollnumber" runat="server" CssClass="textbox"></asp:TextBox>
               </div>
                   <p class="main">Email Address <asp:RequiredFieldValidator ID="Validator3" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtemailaddress" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
               <div class="maininfo">
                    <asp:Label ID="lblemailaddress" runat="server" Text="Label" CssClass="lables"></asp:Label>
               </div>
               <div class="editinfo">
                   <asp:TextBox ID="txtemailaddress" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox>
             </div>
                     <p class="main">Department <asp:RequiredFieldValidator ID="Validator4" runat="server" ErrorMessage="Must Enter Value" ControlToValidate="txtemailaddress" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></p>
               <div class="maininfo">
                    <asp:Label ID="lbldepartment" runat="server" Text="Label" CssClass="lables" ></asp:Label>
               </div>
               <div class="editinfo">
                    <asp:DropDownList ID="department" runat="server" CssClass="textbox"></asp:DropDownList>
               </div>
                   <p class="main">Branch</p>
               <div class="maininfo">
               <asp:Label ID="lblbranch" runat="server" Text="Label" CssClass="lables"></asp:Label>
               </div>
               <div class="editinfo">
                   <asp:DropDownList ID="branch" runat="server" CssClass="textbox"></asp:DropDownList>
                </div>
                   <p class="main">Semester</p>
               <div class="maininfo">
               <asp:Label ID="lblsemster" runat="server" Text="Label" CssClass="lables"></asp:Label>
                </div>
               <div class="editinfo">
                <asp:DropDownList ID="semester" runat="server" CssClass="textbox"></asp:DropDownList>
              </div>
                    <p class="main">Batch</p>
               <div class="maininfo">
               <asp:Label ID="lblbatch" runat="server" Text="Label" CssClass="lables"></asp:Label>
                </div>
               <div class="editinfo">
                   <asp:DropDownList ID="batch" runat="server" CssClass="textbox"></asp:DropDownList>
                   </div>
               <div id="btn" style="margin-top: 5%;margin-bottom: 5%;">
                   <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="aspbutton" OnClick="btnedit_Click" />
               </div>
             


           </div>

                 <div id="nf_corner" style="display:none">
                <%--     <div class="nt_row">
                         <div class="img">
                             <img src="Image/at.png" />
                         </div>
                         <div class="nf_desc">
                             Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.
                         </div>
                     </div>
                     <div class="nt_row">
                         <div class="img">
                             <img src="Image/news (1).png" />
                         </div>
                          <div class="nf_desc">
                             Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sit amet pretium risus. Suspendisse elementum ante nisl, ac consequat dolor scelerisque eget. Donec vel congue risus. Vestibulum non interdum tortor, eu egestas est. Nullam venenatis nisl arcu, vitae finibus ipsum efficitur pharetra. Phasellus ut nulla at metus dapibus tempor. Pellentesque neque nulla, semper in dapibus id, cursus vel urna. Nunc sodales, arcu a dapibus vehicula, arcu magna vehicula nunc, vel eleifend quam metus nec arcu. Vivamus pulvinar arcu nec elit gravida imperdiet. Mauris tempus leo et pretium fermentum. Nam laoreet pharetra lacus, ut venenatis diam congue ullamcorper. Ut molestie dui le
                         </div>
                     </div>

                       <div class="nt_row">
                         <div class="img">
                             <img src="Image/event (1).png" />
                         </div>
                            <div class="nf_desc">
                             uspendisse potenti. Donec eget ligula euismod, rutrum ligula sit amet, placerat turpis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Mauris fringilla eu nunc non convallis. Curabitur ac lobortis ex. Donec quis ipsum mauris. Fusce felis elit, malesuada ac mi at, congue molestie urna. Duis placerat sapien quis lacus tristique, ac elementum magna scelerisque
                         </div>

                     </div>--%>

                     <ul class="chat">
                                    <li class="left clearfix">
                                        <span class="chat-img pull-left">
                                            <img src="Image/at.png" alt="User Avatar" class="img-circle">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font "> Jack Sparrow </strong>
                                                <small class="pull-right text-muted label label-danger">
                                                    <i class="icon-time"></i> 12 mins ago
                                                </small>
                                            </div>
                                             <br>
                                            <p>
                                                Lorem ipsum dolor sit amet, bibendum ornare dolor, quis ullamcorper ligula sodales.
                                            </p>
                                        </div>
                                    </li>
                                    <li class="right clearfix">
                                        <span class="chat-img pull-right">
                                            <img src="Image/news (1).png" alt="User Avatar" class="img-circle">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <small class=" text-muted label label-info">
                                                    <i class="icon-time"></i> 13 mins ago</small>
                                                <strong class="pull-right primary-font"> Jhony Deen</strong>
                                            </div>
                                            <br>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur a dolor, quis ullamcorper ligula sodales.
                                            </p>
                                        </div>
                                    </li>
                                    <li class="left clearfix">
                                        <span class="chat-img pull-left">
                                            <img src="Image/at.png" alt="User Avatar" class="img-circle">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font"> Jack Sparrow </strong>
                                                <small class="pull-right text-muted label label-warning">
                                                    <i class="icon-time"></i> 12 mins ago
                                                </small>
                                            </div>
                                             <br>
                                            <p>
                                                Lorem ipsum dolor sit amet, bibendum ornare dolor, quis ullamcorper ligula sodales.
                                            </p>
                                        </div>
                                    </li>
                                    <li class="right clearfix">
                                        <span class="chat-img pull-right">
                                            <img src="Image/news (1).png" alt="User Avatar" class="img-circle">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <small class=" text-muted label label-primary">
                                                    <i class="icon-time"></i> 13 mins ago</small>
                                                <strong class="pull-right primary-font"> Jhony Deen</strong>
                                            </div>
                                            <br>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur a dolor, quis ullamcorper ligula sodales.
                                            </p>
                                        </div>
                                    </li>
                                </ul>







                 </div>
                 </div>
           <div id="footer">
         <p>Webdesigner & Devloper: <a href="#">Manthan Patel</a></p>
        </div>
         </div>
    </form>
</body>
</html>
