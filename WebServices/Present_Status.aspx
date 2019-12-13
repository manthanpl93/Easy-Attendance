<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Present_Status.aspx.cs" Inherits="WebServices_Present_Status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function GetMessage() {
            PageMethods.Message(OnGetMessageSuccess, OnGetMessageFailure);
        }


        function OnGetMessageSuccess(result, userContext, methodName) {
            alert(result);
        }

        function OnGetMessageFailure(error, userContext, methodName) {
            alert(error.get_message());
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <a href="#" onclick="GetMessage()">manthan</a><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
   
        <input onclick="GetMessage()" type="submit" value="Get Message" />
        
         </div>
    </form>
</body>
</html>
