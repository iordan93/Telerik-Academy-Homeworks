<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3.LoginCookie.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login form</title>
</head>
<body>
    <form id="FormLogin" runat="server">
        Username:
        <asp:TextBox ID="TextBoxUsername" runat="server" /><br />
        Password:
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" /><br />
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
    </form>
</body>
</html>
