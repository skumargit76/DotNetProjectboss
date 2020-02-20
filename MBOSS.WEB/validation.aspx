<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="validation.aspx.cs" Inherits="MBOSS.WEB.validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <div><asp:Label runat="server" ID="user_name" Text=""></asp:Label>
       </div>
        <br />
    <span><asp:Button ID="user_ok" runat="server" Text="Valid User" OnClick="user_ok_Click" /></span> &nbsp; 
        <span>
            <asp:Button ID="user_false" runat="server" Text="Invalid User" OnClick="user_false_Click" /></span>
    </div>
    </form>
</body>
</html>
